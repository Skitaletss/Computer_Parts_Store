using System;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Computer_Parts_Store.Models;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Computer_Parts_Store.Forms
{
    public partial class ReceiptForm : Form
    {
        private Order _order;

        public ReceiptForm(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Замовлення не може бути null");
            }

            InitializeComponent();
            _order = order;
            LoadReceiptData();
        }

        private void LoadReceiptData()
        {
            lblOrderNumber.Text = $"Замовлення № {_order.Id:D6}";
            lblOrderDate.Text = $"Дата: {_order.OrderDate:dd.MM.yyyy HH:mm:ss}";
            lblCustomer.Text = $"Покупець: {_order.Customer?.FullName ?? "Невідомий покупець"}";

            dataGridViewItems.Rows.Clear();
            foreach (var orderItem in _order.OrderItems)
            {
                dataGridViewItems.Rows.Add(
                    orderItem.Product?.Name ?? "Невідомий товар",
                    orderItem.Quantity.ToString(),
                    orderItem.UnitPrice.ToString("F2"),
                    orderItem.TotalPrice.ToString("F2")
                );
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = _order.OrderItems.Sum(oi => oi.TotalPrice);

            lblSubtotal.Text = $"Проміжна сума: {total:F2} грн";
            lblTotal.Text = $"ВСЬОГО: {total:F2} грн";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функція друку буде реалізована пізніше", "Інформація",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF файли (*.pdf)|*.pdf|Всі файли (*.*)|*.*";
                saveDialog.FileName = $"Чек_Замовлення_{_order.Id:D6}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    SaveAsPdf(filePath);
                }
            }
        }

        private void SaveAsPdf(string filePath)
        {
            iTextSharp.text.Document document = null;
            PdfWriter writer = null;

            try
            {
                document = new iTextSharp.text.Document(PageSize.A4, 20, 20, 30, 30);
                writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(baseFont, 10);
                iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontSmall = new iTextSharp.text.Font(baseFont, 8);
                iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);

                Paragraph header = new Paragraph("КАСОВИЙ ЧЕК", fontHeader);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 10;
                document.Add(header);

                document.Add(new Paragraph("Магазин: \"Computer Parts Store\"", fontNormal));
                document.Add(new Paragraph("Адреса: вул. Комп'ютерна, 123", fontNormal));
                document.Add(new Paragraph("Телефон: +380 12 345 6789", fontNormal));

                var random = new Random();
                document.Add(new Paragraph($"Чек №: CHK-{DateTime.Now:yyyyMMdd}-{random.Next(1000, 9999)}", fontNormal));
                document.Add(new Paragraph($"Дата: {DateTime.Now:dd.MM.yyyy}", fontNormal));
                document.Add(new Paragraph($"Час: {DateTime.Now:HH:mm:ss}", fontNormal));
                document.Add(new Paragraph(new string('─', 50), fontNormal));

                document.Add(new Paragraph($"Замовлення №: {_order.Id:D6}", fontNormal));
                document.Add(new Paragraph($"Покупець: {_order.Customer?.FullName ?? "Невідомий покупець"}", fontNormal));
                if (!string.IsNullOrEmpty(_order.Customer?.Phone))
                {
                    document.Add(new Paragraph($"Телефон: {_order.Customer.Phone}", fontNormal));
                }
                if (!string.IsNullOrEmpty(_order.Customer?.Email))
                {
                    document.Add(new Paragraph($"Email: {_order.Customer.Email}", fontNormal));
                }

                document.Add(new Paragraph(new string('─', 50), fontNormal));

                document.Add(new Paragraph("ТОВАРИ:", fontNormal) { SpacingBefore = 10 });
                document.Add(new Paragraph(new string('─', 50), fontNormal));

                if (_order.OrderItems.Any())
                {
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 4f, 2f, 2f });

                    table.AddCell(new PdfPCell(new Phrase("#", fontNormal)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Товар", fontNormal)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Кількість", fontNormal)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Сума", fontNormal)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    int itemNumber = 1;
                    foreach (var orderItem in _order.OrderItems)
                    {
                        table.AddCell(new PdfPCell(new Phrase(itemNumber.ToString(), fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase(orderItem.Product?.Name ?? "Невідомий товар", fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase($"{orderItem.Quantity} x {orderItem.UnitPrice:F2}", fontNormal)));
                        table.AddCell(new PdfPCell(new Phrase($"{orderItem.TotalPrice:F2} грн", fontNormal)));
                        itemNumber++;
                    }

                    document.Add(table);
                    document.Add(new Paragraph(new string('─', 50), fontNormal));

                    document.Add(new Paragraph($"ЗАГАЛЬНА СУМА: {_order.TotalAmount:F2} грн", fontBold));

                    document.Add(new Paragraph(new string('─', 50), fontNormal));

                    document.Add(new Paragraph("ОПЛАТА: ГОТІВКА", fontNormal));
                    document.Add(new Paragraph("РЕШТА: 0.00 грн", fontNormal));
                }
                else
                {
                    Paragraph noItems = new Paragraph("Немає товарів у замовленні", fontNormal);
                    noItems.Alignment = Element.ALIGN_CENTER;
                    document.Add(noItems);
                }

                document.Add(new Paragraph("\n", fontNormal));

                Paragraph thanks = new Paragraph("Дякуємо за покупку!", fontNormal);
                thanks.Alignment = Element.ALIGN_CENTER;
                document.Add(thanks);

                Paragraph goodDay = new Paragraph("Гарного дня!", fontNormal);
                goodDay.Alignment = Element.ALIGN_CENTER;
                document.Add(goodDay);

                document.Add(new Paragraph("\n", fontNormal));
                document.Add(new Paragraph("* Чек може бути повернутий протягом 14 днів", fontSmall));
                document.Add(new Paragraph($"* Чек збережено: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", fontSmall));

                MessageBox.Show($"Чек успішно збережено у файл: {Path.GetFileName(filePath)}", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Помилка збереження PDF: {exception.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document?.Close();
                writer?.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}