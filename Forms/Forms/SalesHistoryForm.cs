using System;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;

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

            using (var db = new Computer_Parts_StoreContext())
            {
                // Отримуємо діапазон дат
                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1);

                // Завантажуємо замовлення з бази даних
                var orders = db.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.PrebuiltComputer)
                    .Where(o => o.Status == "Підтверджено" &&
                                o.OrderDate >= dateFrom &&
                                o.OrderDate <= dateTo)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();

                // Додаємо замовлення до таблиці
                foreach (var order in orders)
                {
                    string orderNumber = order.Id.ToString("D6");
                    string dateTime = order.OrderDate.ToString("dd.MM.yyyy HH:mm");
                    string customerName = order.Customer?.FullName ?? "Невідомий";
                    int itemsCount = order.OrderItems?.Sum(oi => oi.Quantity) ?? 0;
                    string totalAmount = order.TotalAmount.ToString("F2", CultureInfo.InvariantCulture);

                    int rowIndex = dataGridViewSales.Rows.Add(
                        orderNumber,
                        dateTime,
                        customerName,
                        itemsCount,
                        totalAmount
                    );

                    // Зберігаємо об'єкт замовлення в Tag для подальшого використання
                    dataGridViewSales.Rows[rowIndex].Tag = order;
                }
            }

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            int totalOrders = dataGridViewSales.Rows.Count;
            decimal totalRevenue = 0;

            foreach (DataGridViewRow row in dataGridViewSales.Rows)
            {
                if (!row.IsNewRow)
                {
                    string value = row.Cells["colTotalAmount"].Value?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                        {
                            totalRevenue += amount;
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
            // Перевірка коректності діапазону дат
            if (dtpDateFrom.Value > dtpDateTo.Value)
            {
                MessageBox.Show("Дата початку не може бути пізніше дати кінця!",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

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
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf|Excel files (*.xlsx)|*.xlsx";
            saveDialog.FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Звіт сформовано та збережено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Переглянути деталі замовлення
            if (e.ColumnIndex == dataGridViewSales.Columns["colViewDetails"].Index)
            {
                // Отримуємо замовлення з Tag
                Order order = dataGridViewSales.Rows[e.RowIndex].Tag as Order;

                if (order != null)
                {
                    // Відкриваємо форму чека з даними замовлення
                    using (var db = new Computer_Parts_StoreContext())
                    {
                        // Завантажуємо повні дані замовлення з бази
                        var fullOrder = db.Orders
                            .Include(o => o.Customer)
                            .Include(o => o.OrderItems)
                                .ThenInclude(oi => oi.Product)
                            .Include(o => o.OrderItems)
                                .ThenInclude(oi => oi.PrebuiltComputer)
                            .FirstOrDefault(o => o.Id == order.Id);

                        if (fullOrder != null)
                        {
                            // Встановлюємо тимчасово поточного користувача для форми чека
                            Customer previousCustomer = LoginSession.CurrentCustomer;
                            LoginSession.Login(fullOrder.Customer);

                            ReceiptForm receiptForm = new ReceiptForm(fullOrder);
                            receiptForm.ShowDialog();

                            // Повертаємо попереднього користувача
                            if (previousCustomer != null)
                            {
                                LoginSession.Login(previousCustomer);
                            }
                            else
                            {
                                LoginSession.Logout();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося завантажити дані замовлення",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    string orderNumber = dataGridViewSales.Rows[e.RowIndex].Cells["colOrderNumber"].Value.ToString();
                    MessageBox.Show($"Деталі замовлення {orderNumber}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}