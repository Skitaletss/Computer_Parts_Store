using System;
using System.Windows.Forms;

namespace Computer_Parts_Store.Forms
{
    public partial class ShoppingCartForm : Form
    {
        public ShoppingCartForm()
        {
            InitializeComponent();
            LoadCartItems();
            UpdateSummary();
        }

        private void LoadCartItems()
        {
            // Додаємо дані як числа, а не як рядки
            dataGridViewCart.Rows.Add("Intel Core i5-12400F", "ART001", 8500.00m, 1, 8500.00m);
            dataGridViewCart.Rows.Add("NVIDIA RTX 3060", "ART002", 12000.00m, 1, 12000.00m);
        }

        private void UpdateSummary()
        {
            int itemsCount = 0;
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (!row.IsNewRow && row.Cells["colQuantity"].Value != null && row.Cells["colTotal"].Value != null)
                {
                    try
                    {
                        // Безпечна конвертація кількості
                        itemsCount += Convert.ToInt32(row.Cells["colQuantity"].Value);

                        // Безпечна конвертація суми
                        totalPrice += Convert.ToDecimal(row.Cells["colTotal"].Value);
                    }
                    catch
                    {
                        // Ігноруємо помилки конвертації
                        continue;
                    }
                }
            }

            lblItemsCountValue.Text = itemsCount.ToString();
            lblTotalPriceValue.Text = totalPrice.ToString("F2");
        }

        private void dataGridViewCart_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colRemove"]?.Index)
            {
                DialogResult result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цей товар?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dataGridViewCart.Rows.RemoveAt(e.RowIndex);
                    UpdateSummary();
                    MessageBox.Show("Товар видалено з кошика", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewCart_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colQuantity"]?.Index)
            {
                try
                {
                    DataGridViewRow row = dataGridViewCart.Rows[e.RowIndex];

                    if (row.Cells["colPrice"].Value != null && row.Cells["colQuantity"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);
                        row.Cells["colTotal"].Value = price * quantity;
                        UpdateSummary();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при оновленні кількості: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheckout_Click(object? sender, EventArgs e)
        {
            if (dataGridViewCart.Rows.Count == 0 || (dataGridViewCart.Rows.Count == 1 && dataGridViewCart.Rows[0].IsNewRow))
            {
                MessageBox.Show("Кошик порожній!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CheckoutForm checkoutForm = new CheckoutForm();
            checkoutForm.ShowDialog();
        }

        private void btnClearCart_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете очистити кошик?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dataGridViewCart.Rows.Clear();
                UpdateSummary();
                MessageBox.Show("Кошик очищено", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ShoppingCartForm_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {
            panelSummary.Location = new Point(
                ClientSize.Width - panelSummary.Width - 20,
                panelSummary.Location.Y);
            dataGridViewCart.Size = new Size(
                ClientSize.Width - panelSummary.Width - 60,
                dataGridViewCart.Height);
            btnClose.Location = new Point(
                ClientSize.Width - btnClose.Width - 20,
                btnClose.Location.Y);
        }
    }
}