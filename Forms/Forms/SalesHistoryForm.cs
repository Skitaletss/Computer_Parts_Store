using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Computer_Parts_Store.Data;

namespace Computer_Parts_Store.Forms
{
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
            InitializeDateFilters();
            LoadSalesData();
        }

        private void InitializeDateFilters()
        {
            // Встановити діапазон за останній місяць
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;
        }

        private void LoadSalesData()
        {
            // Завантаження даних з бази даних
            dataGridViewSales.Rows.Clear();

            try
            {
                using var context = new Computer_Parts_StoreContext();

                var orders = context.Orders
                    .Where(o => o.OrderDate >= dtpDateFrom.Value.Date && o.OrderDate <= dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1))
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();

                foreach (var order in orders)
                {
                    var customer = context.Customers.Find(order.CustomerId);
                    var itemsCount = context.OrderItems.Count(oi => oi.OrderId == order.Id);
                    var totalAmount = context.OrderItems
                        .Where(oi => oi.OrderId == order.Id)
                        .Sum(oi => oi.Quantity * oi.UnitPrice);

                    dataGridViewSales.Rows.Add(
                        order.Id.ToString("D6"),
                        order.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        customer?.FullName ?? "Невідомий клієнт",
                        itemsCount,
                        totalAmount.ToString("F2")
                    );
                }

                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            int totalOrders = 0;
            decimal totalRevenue = 0;

            foreach (DataGridViewRow row in dataGridViewSales.Rows)
            {
                if (!row.IsNewRow)
                {
                    totalOrders++;

                    string? value = row.Cells["colTotalAmount"].Value?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                        {
                            totalRevenue += amount;
                        }
                        else
                        {
                            // Логування помилки або обробка некоректних даних
                            MessageBox.Show($"Некоректне значення суми: {value}", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

            decimal averageOrder = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            lblTotalOrdersValue.Text = totalOrders.ToString();
            lblTotalRevenueValue.Text = totalRevenue.ToString("F2");
            lblAverageOrderValue.Text = averageOrder.ToString("F2");
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            // Застосувати фільтр по датах
            LoadSalesData();
            MessageBox.Show("Фільтр застосовано", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            InitializeDateFilters();
            LoadSalesData();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveDialog.FileName = $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                GeneratePdfReport(filePath);
            }
        }

        private void GeneratePdfReport(string filePath)
        {
            iTextSharp.text.Document? document = null;
            PdfWriter? writer = null;

            try
            {
                // Create PDF document
                document = new iTextSharp.text.Document(PageSize.A4, 20, 20, 30, 30);
                writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Font setup
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                // Header section
                Paragraph header = new Paragraph("ЗВІТ ПРО ПРОДАЖІ", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 10;
                document.Add(header);

                // Period information
                document.Add(new Paragraph($"Період: з {dtpDateFrom.Value:dd.MM.yyyy} по {dtpDateTo.Value:dd.MM.yyyy}", font));
                document.Add(new Paragraph($"Дата формування звіту: {DateTime.Now:dd.MM.yyyy HH:mm}", font));
                document.Add(new Paragraph(new string('─', 50), font));

                // Statistics
                document.Add(new Paragraph("СТАТИСТИКА:", titleFont) { SpacingBefore = 10 });
                document.Add(new Paragraph($"Всього замовлень: {lblTotalOrdersValue.Text}", font));
                document.Add(new Paragraph($"Загальний дохід: {lblTotalRevenueValue.Text} грн", font));
                document.Add(new Paragraph($"Середній чек: {lblAverageOrderValue.Text} грн", font));
                document.Add(new Paragraph(new string('─', 50), font));

                // Sales data
                document.Add(new Paragraph("ДЕТАЛЬНИЙ ПЕРЕЛІК ЗАМОВЛЕНЬ:", titleFont) { SpacingBefore = 10 });

                if (dataGridViewSales.Rows.Count == 0 || (dataGridViewSales.Rows.Count == 1 && dataGridViewSales.Rows[0].IsNewRow))
                {
                    Paragraph noData = new Paragraph("Немає даних для відображення", font);
                    noData.Alignment = Element.ALIGN_CENTER;
                    document.Add(noData);
                }
                else
                {
                    // Create table for sales data
                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1.5f, 2f, 3f, 1.5f, 2f });

                    // Table headers
                    table.AddCell(new PdfPCell(new Phrase("№ Замовлення", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Дата", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Покупець", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("К-сть товарів", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Сума (грн)", font)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    // Add data to table
                    foreach (DataGridViewRow row in dataGridViewSales.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["colOrderNumber"].Value?.ToString() ?? "", font)));
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["colDate"].Value?.ToString() ?? "", font)));
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["colCustomer"].Value?.ToString() ?? "", font)));
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["colItemsCount"].Value?.ToString() ?? "", font)));
                            table.AddCell(new PdfPCell(new Phrase(row.Cells["colTotalAmount"].Value?.ToString() ?? "", font)));
                        }
                    }

                    document.Add(table);
                }

                document.Add(new Paragraph("\n", font));
                document.Add(new Paragraph("Звіт сформовано автоматично.", font));
                document.Add(new Paragraph($"Комп'ютерний магазин - {DateTime.Now:yyyy}", font));

                MessageBox.Show($"Звіт успішно збережено: {Path.GetFileName(filePath)}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні звіту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document?.Close();
                writer?.Close();
            }
        }

        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Переглянути деталі замовлення
            if (e.ColumnIndex == dataGridViewSales.Columns["colViewDetails"].Index)
            {
                string? orderNumber = dataGridViewSales.Rows[e.RowIndex].Cells["colOrderNumber"].Value?.ToString();
                if (!string.IsNullOrEmpty(orderNumber) && int.TryParse(orderNumber, out int orderId))
                {
                    OrderDetailsForm detailsForm = new OrderDetailsForm(orderId);
                    detailsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Не вдалося отримати номер замовлення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}