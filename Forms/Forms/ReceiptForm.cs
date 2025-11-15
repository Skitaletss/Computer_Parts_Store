using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Computer_Parts_Store.Forms
{
    public partial class ReceiptForm : Form
    {
        private PrintDocument _printDocument;

        public ReceiptForm()
        {
            InitializeComponent();
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += new PrintPageEventHandler(PrintReceipt);
            LoadReceiptData();
        }

        private void LoadReceiptData()
        {
            lblOrderNumber.Text = "Замовлення № 000001";
            lblOrderDate.Text = $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
            lblCustomer.Text = "Покупець: Іванов Іван Іванович";

            // Додаємо тестові дані
            dataGridViewItems.Rows.Add("Intel Core i5-12400F", "1", "8500.00", "8500.00");
            dataGridViewItems.Rows.Add("NVIDIA RTX 3060", "1", "12000.00", "12000.00");

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow && row.Cells["colTotal"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["colTotal"].Value.ToString(),
                        NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal rowTotal))
                    {
                        total += rowTotal;
                    }
                }
            }

            lblSubtotal.Text = $"Проміжна сума: {total:F2} грн";
            lblTotal.Text = $"ВСЬОГО: {total:F2} грн";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                    MessageBox.Show("Чек надіслано на друк!", "Успіх",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при друці: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовий файл (*.txt)|*.txt|Всі файли (*.*)|*.*";
            saveDialog.FileName = $"Чек_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveAsText(saveDialog.FileName);
            }
        }

        private void SaveAsText(string filePath)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);

                writer.WriteLine("          КОМП'ЮТЕРНИЙ МАГАЗИН");
                writer.WriteLine("        м. Київ, вул. Прикладна, 123");
                writer.WriteLine("          Тел: +380 (44) 123-45-67");
                writer.WriteLine("========================================");
                writer.WriteLine();

                // Інформація про замовлення
                writer.WriteLine($"ЧЕК №: RCP-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}");
                writer.WriteLine($"ДАТА: {DateTime.Now:dd.MM.yyyy}");
                writer.WriteLine($"ЧАС: {DateTime.Now:HH:mm:ss}");
                writer.WriteLine($"КАСИР: АДМІНІСТРАТОР");
                writer.WriteLine();

                // Інформація про клієнта
                writer.WriteLine("КЛІЄНТ:");
                writer.WriteLine("Іванов Іван Іванович");
                writer.WriteLine();

                writer.WriteLine("ПЕРЕЛІК ТОВАРІВ:");
                writer.WriteLine("----------------------------------------");

                decimal totalAmount = 0;
                int itemNumber = 1;

                // Додаємо товари
                foreach (DataGridViewRow row in dataGridViewItems.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string itemName = row.Cells["colName"].Value?.ToString() ?? "Невідомий товар";
                        string quantity = row.Cells["colQuantity"].Value?.ToString() ?? "1";
                        string price = row.Cells["colPrice"].Value?.ToString() ?? "0";

                        if (decimal.TryParse(price, out decimal itemPrice) &&
                            int.TryParse(quantity, out int itemQuantity))
                        {
                            decimal itemTotal = itemPrice * itemQuantity;
                            totalAmount += itemTotal;

                            writer.WriteLine($"{itemNumber}. {itemName}");
                            writer.WriteLine($"   {quantity} x {itemPrice:F2} грн = {itemTotal:F2} грн");
                            writer.WriteLine();

                            itemNumber++;
                        }
                    }
                }

                writer.WriteLine("----------------------------------------");

                // Підсумки
                decimal vatRate = 0.20m;
                decimal vatAmount = totalAmount * vatRate;

                writer.WriteLine($"К-СТЬ ТОВАРІВ: {itemNumber - 1} шт.");
                writer.WriteLine($"СУМА БЕЗ ПДВ: {totalAmount - vatAmount:F2} грн");
                writer.WriteLine($"ПДВ 20%: {vatAmount:F2} грн");
                writer.WriteLine("========================================");
                writer.WriteLine($"ВСЬОГО ДО СПЛАТИ: {totalAmount:F2} грн");
                writer.WriteLine("========================================");
                writer.WriteLine();
                writer.WriteLine("         ДЯКУЄМО ЗА ПОКУПКУ!");
                writer.WriteLine("           ГАРНОГО ДНЯ!");
                writer.WriteLine();
                writer.WriteLine("* Повернення протягом 14 днів");
                writer.WriteLine($"* Чек збережено: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                MessageBox.Show($"Чек успішно збережено: {Path.GetFileName(filePath)}",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні чека: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
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
            graphics.DrawString($"ЧЕК №: RCP-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}",
                fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ДАТА: {DateTime.Now:dd.MM.yyyy}", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"ЧАС: {DateTime.Now:HH:mm:ss}", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString($"КАСИР: АДМІНІСТРАТОР", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Інформація про клієнта
            graphics.DrawString("КЛІЄНТ:", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            graphics.DrawString("Іванов Іван Іванович", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Заголовок товарів
            graphics.DrawString("ПЕРЕЛІК ТОВАРІВ:", fontBold, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Товари
            decimal totalAmount = 0;
            int itemNumber = 1;

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemName = row.Cells["colName"].Value?.ToString() ?? "Невідомий товар";
                    string quantity = row.Cells["colQuantity"].Value?.ToString() ?? "1";
                    string price = row.Cells["colPrice"].Value?.ToString() ?? "0";

                    if (decimal.TryParse(price, out decimal itemPrice) &&
                        int.TryParse(quantity, out int itemQuantity))
                    {
                        decimal itemTotal = itemPrice * itemQuantity;
                        totalAmount += itemTotal;

                        // Обрізаємо довгі назви
                        if (itemName.Length > 25)
                            itemName = itemName.Substring(0, 25) + "...";

                        graphics.DrawString($"{itemNumber}. {itemName}", fontSmall, Brushes.Black, leftMargin, yPos);
                        graphics.DrawString($"{quantity} x {itemPrice:F2} = {itemTotal:F2}",
                            fontSmall, Brushes.Black, leftMargin + 200, yPos);
                        yPos += 15;
                        itemNumber++;
                    }
                }
            }

            yPos += 10;

            // Підсумки
            decimal vatRate = 0.20m;
            decimal vatAmount = totalAmount * vatRate;

            graphics.DrawString($"К-СТЬ ТОВАРІВ: {itemNumber - 1} шт.", font, Brushes.Black, leftMargin, yPos);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}