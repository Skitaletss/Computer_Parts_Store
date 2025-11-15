using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Computer_Parts_Store.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private Order? _order;
        private PrintDocument _printDocument;

        public OrderDetailsForm(int orderId)
        {
            InitializeComponent();
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += new PrintPageEventHandler(PrintReceipt);

            LoadOrderDetails(orderId);
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                using var context = new Computer_Parts_StoreContext();

                _order = context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                            .ThenInclude(p => p.Category)
                    .FirstOrDefault(o => o.Id == orderId);

                if (_order == null)
                {
                    MessageBox.Show("Замовлення не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUI()
        {
            if (_order == null) return;

            // Оновлення інформації про замовлення
            lblOrderNumber.Text = $"Замовлення № {_order.Id:D6}";
            lblOrderDate.Text = $"Дата: {_order.OrderDate:dd.MM.yyyy HH:mm:ss}";
            lblStatus.Text = $"Статус: {_order.Status}";

            // Оновлення інформації про клієнта
            if (_order.Customer != null)
            {
                lblCustomerName.Text = $"Покупець: {_order.Customer.FullName}";
                lblCustomerPhone.Text = $"Телефон: {_order.Customer.Phone ?? "Не вказано"}";
                lblCustomerEmail.Text = $"Email: {_order.Customer.Email ?? "Не вказано"}";
            }

            // Оновлення таблиці товарів
            UpdateOrderItemsGrid();
        }

        private void UpdateOrderItemsGrid()
        {
            dataGridViewOrderItems.Rows.Clear();
            if (_order?.OrderItems == null) return;

            decimal totalAmount = 0;
            int totalItems = 0;

            foreach (var item in _order.OrderItems)
            {
                var product = item.Product;
                var category = product?.Category;

                dataGridViewOrderItems.Rows.Add(
                    product?.Name ?? "Невідомий товар",
                    product?.Article ?? "N/A",
                    category?.Name ?? "Без категорії",
                    item.Quantity,
                    item.UnitPrice,
                    item.TotalPrice
                );

                totalAmount += item.TotalPrice;
                totalItems += item.Quantity;
            }

            // Оновлення підсумків
            decimal vatRate = 0.20m;
            decimal vatAmount = totalAmount * vatRate;

            lblTotalAmount.Text = $"Загальна сума: {totalAmount:F2} грн";
            lblVat.Text = $"ПДВ (20%): {vatAmount:F2} грн";
            lblTotalItems.Text = $"Кількість товарів: {totalItems} шт";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                    MessageBox.Show("Чек надіслано на друк!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при друці: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            if (_order == null) return;

            Graphics graphics = e.Graphics!;
            Font font = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 8);
            Font fontTitle = new Font("Arial", 12, FontStyle.Bold);

            float yPos = 50;
            float leftMargin = 50;

            // Заголовок
            graphics.DrawString("КОМП'ЮТЕРНИЙ МАГАЗИН", fontTitle, Brushes.Black, leftMargin, yPos);
            yPos += 30;
            graphics.DrawString("м. Київ, вул. Прикладна, 123", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString("Тел: +380 (44) 123-45-67", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Інформація про замовлення
            graphics.DrawString($"ЧЕК №: {_order.Id:D6}", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ДАТА: {_order.OrderDate:dd.MM.yyyy}", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ЧАС: {_order.OrderDate:HH:mm:ss}", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"КАСИР: АДМІНІСТРАТОР", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Інформація про клієнта
            if (_order.Customer != null)
            {
                graphics.DrawString("КЛІЄНТ:", fontBold, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                graphics.DrawString(_order.Customer.FullName, font, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                if (!string.IsNullOrEmpty(_order.Customer.Phone))
                {
                    graphics.DrawString($"Тел: {_order.Customer.Phone}", font, Brushes.Black, leftMargin, yPos);
                    yPos += 20;
                }
            }

            // Заголовок товарів
            graphics.DrawString("ПЕРЕЛІК ТОВАРІВ:", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Товари
            decimal totalAmount = 0;
            int totalItems = 0;

            if (_order.OrderItems != null)
            {
                foreach (var item in _order.OrderItems)
                {
                    var product = item.Product;
                    string itemName = product?.Name ?? "Невідомий товар";

                    if (itemName.Length > 25)
                        itemName = itemName.Substring(0, 25) + "...";

                    decimal itemTotal = item.UnitPrice * item.Quantity;
                    totalAmount += itemTotal;
                    totalItems += item.Quantity;

                    graphics.DrawString($"{itemName}", fontSmall, Brushes.Black, leftMargin, yPos);
                    graphics.DrawString($"{item.Quantity} x {item.UnitPrice:F2} = {itemTotal:F2}", fontSmall, Brushes.Black, leftMargin + 200, yPos);
                    yPos += 15;
                }
            }

            yPos += 10;

            // Підсумки
            decimal vatRate = 0.20m;
            decimal vatAmount = totalAmount * vatRate;

            graphics.DrawString($"К-СТЬ ТОВАРІВ: {totalItems} шт.", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"СУМА БЕЗ ПДВ: {totalAmount - vatAmount:F2} грн", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ПДВ 20%: {vatAmount:F2} грн", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ВСЬОГО ДО СПЛАТИ: {totalAmount:F2} грн", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Футер
            graphics.DrawString("ДЯКУЄМО ЗА ПОКУПКУ!", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString("ГАРНОГО ДНЯ!", font, Brushes.Black, leftMargin, yPos);
        }

        private void btnSaveReceipt_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовий файл (*.txt)|*.txt|Всі файли (*.*)|*.*";
            saveDialog.FileName = $"Чек_Замовлення_{_order?.Id:D6}.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveReceiptAsText(saveDialog.FileName);
            }
        }

        private void SaveReceiptAsText(string filePath)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);

                writer.WriteLine("КОМП'ЮТЕРНИЙ МАГАЗИН");
                writer.WriteLine("м. Київ, вул. Прикладна, 123");
                writer.WriteLine("Тел: +380 (44) 123-45-67");
                writer.WriteLine(new string('=', 40));
                writer.WriteLine($"ЧЕК №: {_order?.Id:D6}");
                writer.WriteLine($"ДАТА: {_order?.OrderDate:dd.MM.yyyy}");
                writer.WriteLine($"ЧАС: {_order?.OrderDate:HH:mm:ss}");
                writer.WriteLine($"КАСИР: АДМІНІСТРАТОР");
                writer.WriteLine();

                if (_order?.Customer != null)
                {
                    writer.WriteLine("КЛІЄНТ:");
                    writer.WriteLine(_order.Customer.FullName);
                    if (!string.IsNullOrEmpty(_order.Customer.Phone))
                        writer.WriteLine($"Тел: {_order.Customer.Phone}");
                    writer.WriteLine();
                }

                writer.WriteLine("ПЕРЕЛІК ТОВАРІВ:");
                writer.WriteLine(new string('-', 40));

                decimal totalAmount = 0;
                int totalItems = 0;

                if (_order?.OrderItems != null)
                {
                    foreach (var item in _order.OrderItems)
                    {
                        var product = item.Product;
                        string itemName = product?.Name ?? "Невідомий товар";
                        decimal itemTotal = item.UnitPrice * item.Quantity;

                        writer.WriteLine($"{itemName}");
                        writer.WriteLine($"{item.Quantity} x {item.UnitPrice:F2} = {itemTotal:F2} грн");
                        writer.WriteLine();

                        totalAmount += itemTotal;
                        totalItems += item.Quantity;
                    }
                }

                writer.WriteLine(new string('-', 40));
                decimal vatRate = 0.20m;
                decimal vatAmount = totalAmount * vatRate;

                writer.WriteLine($"К-СТЬ ТОВАРІВ: {totalItems} шт.");
                writer.WriteLine($"СУМА БЕЗ ПДВ: {totalAmount - vatAmount:F2} грн");
                writer.WriteLine($"ПДВ 20%: {vatAmount:F2} грн");
                writer.WriteLine(new string('=', 40));
                writer.WriteLine($"ВСЬОГО ДО СПЛАТИ: {totalAmount:F2} грн");
                writer.WriteLine(new string('=', 40));
                writer.WriteLine();
                writer.WriteLine("ДЯКУЄМО ЗА ПОКУПКУ!");
                writer.WriteLine("ГАРНОГО ДНЯ!");

                MessageBox.Show($"Чек успішно збережено: {Path.GetFileName(filePath)}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні чека: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}