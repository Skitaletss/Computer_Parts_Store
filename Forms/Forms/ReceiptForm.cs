using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;

namespace Computer_Parts_Store.Forms
{
    public partial class ReceiptForm : Form
    {
        private readonly Order? Order;
        public ReceiptForm()
        {
            InitializeComponent();
            LoadReceiptData();
        }

        public ReceiptForm(Order o)
        {
            InitializeComponent();
            Order = o;
            LoadReceiptData();
        }

        private void LoadReceiptData()
        {
            lblCustomerValue.Text = LoginSession.CurrentCustomer.FullName;
            lblOrderDateValue.Text = DateTime.Now.ToString("dd.MM.yyyy");

            using (var db = new Computer_Parts_StoreContext())
            {
                if (Order == null) return;
                var orderItems = db.OrderItems
                    .Where(oi => oi.OrderId == Order.Id)
                    .ToList();
                foreach (var item in orderItems)
                {
                    string itemName = "N/A";
                    if (item.ProductId != null)
                    {
                        var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            itemName = product.Name;
                            dataGridViewItems.Rows.Add(itemName, item.Quantity, item.UnitPrice.ToString("F2"), item.TotalPrice.ToString("F2", CultureInfo.InvariantCulture));
                        }
                    }
                    else if (item.PrebuiltComputerId != null)
                    {
                        var pc = db.PrebuiltComputers.FirstOrDefault(pc => pc.Id == item.PrebuiltComputerId);
                        if (pc != null)
                        {
                            itemName = pc.Name;
                            dataGridViewItems.Rows.Add(itemName, item.Quantity, item.UnitPrice, item.TotalPrice.ToString("F2", CultureInfo.InvariantCulture));
                        }
                    }
                }
            }

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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Document document = null;
            PdfWriter writer = null;

            try
            {
                document = new Document(PageSize.A4, 20, 20, 30, 30);
                writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font smallFont = new iTextSharp.text.Font(baseFont, 8);

                Paragraph header = new Paragraph("ФІСКАЛЬНИЙ ЧЕК", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 10;
                document.Add(header);

                document.Add(new Paragraph($"Магазин: \"{lblStoreName.Text}\"", font));
                document.Add(new Paragraph($"Адреса: {lblStoreAddress.Text}", font));
                document.Add(new Paragraph($"{lblStorePhone.Text}", font));
                document.Add(new Paragraph($"{lblStoreEmail.Text}", font));

                document.Add(new Paragraph(new string('─', 50), font));

                document.Add(new Paragraph($"Клієнт: {lblCustomerValue.Text}", font));
                document.Add(new Paragraph($"Тел: {LoginSession.CurrentCustomer.Phone}", font));

                var random = new Random();
                document.Add(new Paragraph($"Чек №: RCP-{DateTime.Now:yyyyMMdd}-{random.Next(1000, 99999)}", font));
                document.Add(new Paragraph($"Дата: {DateTime.Now:dd.MM.yyyy}", font));
                document.Add(new Paragraph($"Час: {DateTime.Now:HH:mm:ss}", font));
                document.Add(new Paragraph(new string('─', 50), font));

                document.Add(new Paragraph("ТОВАРИ:", font) { SpacingBefore = 10 });
                document.Add(new Paragraph(new string('─', 50), font));

                if (dataGridViewItems.Rows.Count == 0 || (dataGridViewItems.Rows.Count == 1 && dataGridViewItems.Rows[0].IsNewRow))
                {
                    Paragraph noItems = new Paragraph("Немає товарів", font);
                    noItems.Alignment = Element.ALIGN_CENTER;
                    document.Add(noItems);
                }
                else
                {
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 4f, 2f, 2f });

                    table.AddCell(new PdfPCell(new Phrase("#", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Товар", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("К-сть", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Сума", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    decimal totalAmount = 0;
                    int itemNumber = 1;

                    foreach (DataGridViewRow row in dataGridViewItems.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string productName = row.Cells["colName"].Value?.ToString() ?? "N/A";

                        int quantity = 0;
                        if (row.Cells["colQuantity"].Value != null)
                            int.TryParse(row.Cells["colQuantity"].Value.ToString(), out quantity);

                        decimal amount = Convert.ToDecimal(row.Cells["colTotal"].Value, CultureInfo.InvariantCulture);

                        table.AddCell(new PdfPCell(new Phrase(itemNumber.ToString(), font)));
                        table.AddCell(new PdfPCell(new Phrase(productName, font)));
                        table.AddCell(new PdfPCell(new Phrase(quantity.ToString(), font)));
                        table.AddCell(new PdfPCell(new Phrase($"{amount:F2} грн", font)));

                        totalAmount += amount;
                        itemNumber++;
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new string('─', 50), font));

                    document.Add(new Paragraph($"ВСЬОГО: {totalAmount:F2} грн", headerFont));
                    document.Add(new Paragraph(new string('─', 50), font));
                    document.Add(new Paragraph("РЕШТА: 0.00 грн", font));
                }

                document.Add(new Paragraph("\n", font));

                Paragraph thanks = new Paragraph("Дякуємо за покупку!", font);
                thanks.Alignment = Element.ALIGN_CENTER;
                document.Add(thanks);

                Paragraph bye = new Paragraph("Гарного дня!", font);
                bye.Alignment = Element.ALIGN_CENTER;
                document.Add(bye);

                document.Add(new Paragraph("\n", font));
                document.Add(new Paragraph("* Чек дійсний для повернення протягом 14 днів", smallFont));
                document.Add(new Paragraph($"* Збережено: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont));

                MessageBox.Show($"Чек збережено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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