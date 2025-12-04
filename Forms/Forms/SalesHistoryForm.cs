using System;
using System.Windows.Forms;
using System.Globalization;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class SalesHistoryForm : Form
    {
        private Computer_Parts_StoreContext _context;

        public SalesHistoryForm()
        {
            InitializeComponent();
            _context = new Computer_Parts_StoreContext();

            InitializeDateFilters();
            LoadAllSalesData();
        }

        private void InitializeDateFilters()
        {
            try
            {
                if (_context.Orders.Any())
                {
                    var minDate = _context.Orders.Min(o => o.OrderDate);
                    var maxDate = _context.Orders.Max(o => o.OrderDate);

                    // Встановлюємо мінімальну та максимальну дату для вибору
                    dtpDateFrom.MinDate = minDate;
                    dtpDateTo.MaxDate = maxDate;

                    // Встановлюємо діапазон за весь період
                    dtpDateFrom.Value = minDate;
                    dtpDateTo.Value = maxDate;

                    statusLabel.Text = $"Діапазон дат: {minDate:dd.MM.yyyy} - {maxDate:dd.MM.yyyy}";
                }
                else
                {
                    // Якщо немає даних, встановлюємо поточний рік
                    dtpDateFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
                    dtpDateTo.Value = DateTime.Now;
                    statusLabel.Text = "Немає даних для відображення";
                }
            }
            catch (Exception ex)
            {
                // Резервний варіант
                dtpDateFrom.Value = DateTime.Now.AddYears(-1);
                dtpDateTo.Value = DateTime.Now;
                statusLabel.Text = "Помилка ініціалізації фільтрів";
            }
        }

        private void LoadAllSalesData()
        {
            dataGridViewSales.Rows.Clear();

            try
            {
                statusLabel.Text = "Завантаження даних...";

                var orders = _context.Orders
                    .Include(order => order.Customer)
                    .Include(order => order.OrderItems)
                    .OrderByDescending(order => order.OrderDate)
                    .ToList();

                if (!orders.Any())
                {
                    statusLabel.Text = "Немає замовлень для відображення";
                    return;
                }

                foreach (var order in orders)
                {
                    dataGridViewSales.Rows.Add(
                        order.Id.ToString("D6"),
                        order.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        order.Customer?.FullName ?? "Невідомий покупець",
                        order.OrderItems.Count.ToString(),
                        order.TotalAmount.ToString("F2")
                    );
                }

                UpdateStatistics();
                statusLabel.Text = $"Завантажено {orders.Count} замовлень";
            }
            catch (Exception exception)
            {
                string errorMessage = $"Помилка завантаження даних: {exception.Message}";
                statusLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilteredSalesData()
        {
            dataGridViewSales.Rows.Clear();

            try
            {
                var startDate = dtpDateFrom.Value.Date;
                var endDate = dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1);

                statusLabel.Text = $"Пошук з {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";

                var orders = _context.Orders
                    .Include(order => order.Customer)
                    .Include(order => order.OrderItems)
                    .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate)
                    .OrderByDescending(order => order.OrderDate)
                    .ToList();

                if (!orders.Any())
                {
                    statusLabel.Text = "Не знайдено замовлень за обраним періодом";
                    return;
                }

                foreach (var order in orders)
                {
                    dataGridViewSales.Rows.Add(
                        order.Id.ToString("D6"),
                        order.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        order.Customer?.FullName ?? "Невідомий покупець",
                        order.OrderItems.Count.ToString(),
                        order.TotalAmount.ToString("F2")
                    );
                }

                UpdateStatistics();
                statusLabel.Text = $"Знайдено {orders.Count} замовлень";
            }
            catch (Exception exception)
            {
                string errorMessage = $"Помилка завантаження даних: {exception.Message}";
                statusLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string value = row.Cells["colTotalAmount"].Value?.ToString() ?? "0";
                    if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                    {
                        totalRevenue += amount;
                    }
                }
            }

            decimal averageOrder = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            lblTotalOrdersValue.Text = totalOrders.ToString();
            lblTotalRevenueValue.Text = totalRevenue.ToString("F2");
            lblAverageOrderValue.Text = averageOrder.ToString("F2");

            UpdateStatisticsColors(totalOrders);
        }

        private void UpdateStatisticsColors(int totalOrders)
        {
            if (totalOrders == 0)
            {
                lblTotalOrdersValue.ForeColor = Color.Gray;
                lblTotalRevenueValue.ForeColor = Color.Gray;
                lblAverageOrderValue.ForeColor = Color.Gray;
            }
            else
            {
                lblTotalOrdersValue.ForeColor = Color.FromArgb(41, 128, 185);
                lblTotalRevenueValue.ForeColor = Color.FromArgb(39, 174, 96);
                lblAverageOrderValue.ForeColor = Color.FromArgb(230, 126, 34);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (dtpDateFrom.Value > dtpDateTo.Value)
            {
                MessageBox.Show("Дата 'З' не може бути більшою за дату 'По'!",
                    "Помилка дат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateFrom.Focus();
                return;
            }

            LoadFilteredSalesData();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            InitializeDateFilters();
            LoadAllSalesData();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSales.Rows.Count == 0 || (dataGridViewSales.Rows.Count == 1 && dataGridViewSales.Rows[0].IsNewRow))
                {
                    MessageBox.Show("Немає даних для формування звіту!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файли (*.pdf)|*.pdf";
                saveDialog.FileName = $"Звіт_Продажів_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"Звіт збережено:\n{saveDialog.FileName}",
                        "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusLabel.Text = $"Звіт збережено: {System.IO.Path.GetFileName(saveDialog.FileName)}";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Помилка генерації звіту: {exception.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Помилка при збереженні звіту";
            }
        }

        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewSales.Columns["colViewDetails"].Index)
            {
                string orderNumber = dataGridViewSales.Rows[e.RowIndex].Cells["colOrderNumber"].Value?.ToString() ?? "";

                if (int.TryParse(orderNumber, out int orderId))
                {
                    ShowOrderDetails(orderId);
                }
                else
                {
                    MessageBox.Show("Невірний номер замовлення",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowOrderDetails(int orderId)
        {
            try
            {
                var order = _context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    ReceiptForm receiptForm = new ReceiptForm(order);
                    receiptForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Замовлення не знайдено в базі даних",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Помилка завантаження деталей замовлення: {exception.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _context?.Dispose();
            this.Close();
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            statusLabel.Text = $"Діапазон: {dtpDateFrom.Value:dd.MM.yyyy} - {dtpDateTo.Value:dd.MM.yyyy}";
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            statusLabel.Text = $"Діапазон: {dtpDateFrom.Value:dd.MM.yyyy} - {dtpDateTo.Value:dd.MM.yyyy}";
        }
    }
}