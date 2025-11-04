using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Computer_Parts_Store.Forms
{
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
            LoadReceiptData();
        }

        private void LoadReceiptData()
        {
            lblOrderNumber.Text = "Замовлення № 000001";
            lblOrderDate.Text = $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
            lblCustomer.Text = "Покупець: Іванов Іван Іванович";

            dataGridViewItems.Rows.Add("Intel Core i5-12400F", "1", "8500.00", "8500.00");
            dataGridViewItems.Rows.Add("NVIDIA RTX 3060", "1", "12000.00", "12000.00");

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    total += Convert.ToDecimal(row.Cells["colTotal"].Value, CultureInfo.InvariantCulture);
                }
            }

            lblSubtotal.Text = $"Проміжна сума: {total:F2} грн";
            lblTotal.Text = $"ВСЬОГО: {total:F2} грн";
        }

        private void btnPrint_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Функція друку буде реалізована пізніше", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveDialog.FileName = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                SaveAsPdf(filePath);
            }
        }

        private void SaveAsPdf(string filePath)
        {
            iTextSharp.text.Document document = null;
            PdfWriter writer = null;

            try
            {
                // Create PDF document
                document = new iTextSharp.text.Document(PageSize.A4, 20, 20, 30, 30);
                writer = PdfWriter.GetInstance(document, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
                document.Open();

                // Font setup
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font font = new(baseFont, 10);
                iTextSharp.text.Font headerFont = new(baseFont, 14);
                iTextSharp.text.Font smallFont = new(baseFont, 8);

                // Header section
                Paragraph header = new Paragraph("FISCAL RECEIPT", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 10;
                document.Add(header);

                // Store information
                document.Add(new Paragraph("Store: \"Your Store Name\"", font));
                document.Add(new Paragraph("Address: Your Address", font));
                document.Add(new Paragraph("Phone: +380 XX XXX XX XX", font));

                // Use thread-safe random for receipt number
                var random = new Random();
                document.Add(new Paragraph($"Receipt No: RCP-{DateTime.Now:yyyyMMdd}-{random.Next(1000, 9999)}", font));
                document.Add(new Paragraph($"Date: {DateTime.Now:dd.MM.yyyy}", font));
                document.Add(new Paragraph($"Time: {DateTime.Now:HH:mm:ss}", font));
                document.Add(new Paragraph(new string('─', 50), font));

                // Items section header
                document.Add(new Paragraph("ITEMS:", font) { SpacingBefore = 10 });
                document.Add(new Paragraph(new string('─', 50), font));

                // Check if there are any items to save
                if (dataGridViewItems.Rows.Count == 0 || (dataGridViewItems.Rows.Count == 1 && dataGridViewItems.Rows[0].IsNewRow))
                {
                    Paragraph noItems = new Paragraph("No items to display", font);
                    noItems.Alignment = Element.ALIGN_CENTER;
                    document.Add(noItems);
                }
                else
                {
                    // Create table for items
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths([1f, 4f, 2f, 2f]);

                    // Table headers
                    table.AddCell(new PdfPCell(new Phrase("#", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Product", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Quantity", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Amount", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    decimal totalAmount = 0;
                    int itemNumber = 1;

                    // Add items to table
                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                            string itemName = row.Cells["colName"].Value?.ToString() ?? "Unknown product";
                            string quantity = row.Cells["colQuantity"].Value?.ToString() ?? "1";
                            string price = row.Cells["colPrice"].Value?.ToString() ?? "0";

                            if (decimal.TryParse(price, out decimal itemPrice) &&
                                int.TryParse(quantity, out int itemQuantity))
                            {
                                decimal itemTotal = itemPrice * itemQuantity;
                                totalAmount += itemTotal;

                                table.AddCell(new PdfPCell(new Phrase(itemNumber.ToString(), font)));
                                table.AddCell(new PdfPCell(new Phrase(itemName, font)));
                                table.AddCell(new PdfPCell(new Phrase($"{quantity} x {itemPrice:F2}", font)));
                                table.AddCell(new PdfPCell(new Phrase($"{itemTotal:F2} UAH", font)));

                                itemNumber++;
                            }
                        
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new string('─', 50), font));

                    // Totals section
                    document.Add(new Paragraph($"TOTAL AMOUNT: {totalAmount:F2} UAH", font));

                    document.Add(new Paragraph(new string('─', 50), font));

                    // Payment info
                    document.Add(new Paragraph("PAYMENT: CASH", font));
                    document.Add(new Paragraph("CHANGE: 0.00 UAH", font));
                }

                document.Add(new Paragraph("\n", font));

                // Footer section
                Paragraph thanks = new Paragraph("Thank you for your purchase!", font);
                thanks.Alignment = Element.ALIGN_CENTER;
                document.Add(thanks);

                Paragraph goodDay = new Paragraph("Have a nice day!", font);
                goodDay.Alignment = Element.ALIGN_CENTER;
                document.Add(goodDay);

                document.Add(new Paragraph("\n", font));
                document.Add(new Paragraph("* Receipt can be returned within 14 days", smallFont));
                document.Add(new Paragraph($"* Receipt saved: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont));

                MessageBox.Show($"Receipt successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document?.Close();
                writer?.Close();
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}