using Computer_Parts_Store.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Computer_Parts_Store.Forms
{
    public partial class ShoppingCartForm : Form
    {
        public List<CartItem> CartItems { get; private set; }

        public ShoppingCartForm()
        {
            InitializeComponent();
            CartItems = new List<CartItem>();
            LoadCartItems();
            UpdateSummary();
        }

        private void LoadCartItems()
        {
            // Додаємо тестові дані - замініть на реальні дані з вашої логіки
            CartItems.Add(new CartItem
            {
                ProductId = 1,
                Name = "Intel Core i5-12400F",
                Article = "ART001",
                Price = 8500.00m,
                Quantity = 1
            });
            CartItems.Add(new CartItem
            {
                ProductId = 2,
                Name = "NVIDIA RTX 3060",
                Article = "ART002",
                Price = 12000.00m,
                Quantity = 1
            });

            RefreshCartGrid();
        }

        private void RefreshCartGrid()
        {
            dataGridViewCart.Rows.Clear();
            foreach (var item in CartItems)
            {
                dataGridViewCart.Rows.Add(
                    item.Name,
                    item.Article,
                    item.Price,
                    item.Quantity,
                    item.Total
                );
            }
        }

        private void UpdateSummary()
        {
            int itemsCount = 0;
            decimal totalPrice = 0;

            foreach (var item in CartItems)
            {
                itemsCount += item.Quantity;
                totalPrice += item.Total;
            }

            lblItemsCountValue.Text = itemsCount.ToString();
            lblTotalPriceValue.Text = totalPrice.ToString("F2");
        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colRemove"].Index)
            {
                DialogResult result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цей товар?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CartItems.RemoveAt(e.RowIndex);
                    RefreshCartGrid();
                    UpdateSummary();
                    MessageBox.Show("Товар видалено з кошика", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colQuantity"].Index)
            {
                try
                {
                    DataGridViewRow row = dataGridViewCart.Rows[e.RowIndex];

                    if (row.Cells["colPrice"].Value != null && row.Cells["colQuantity"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);

                        // Оновлюємо дані в списку CartItems
                        if (e.RowIndex < CartItems.Count)
                        {
                            CartItems[e.RowIndex].Quantity = quantity;
                        }

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

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (CartItems.Count == 0)
            {
                MessageBox.Show("Кошик порожній!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CheckoutForm checkoutForm = new CheckoutForm(CartItems);
            checkoutForm.ShowDialog();

            // Очистити кошик після успішного замовлення
            if (checkoutForm.OrderCreated)
            {
                CartItems.Clear();
                RefreshCartGrid();
                UpdateSummary();
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете очистити кошик?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CartItems.Clear();
                RefreshCartGrid();
                UpdateSummary();
                MessageBox.Show("Кошик очищено", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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