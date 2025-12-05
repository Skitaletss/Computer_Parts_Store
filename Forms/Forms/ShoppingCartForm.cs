using System;
using System.Windows.Forms;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;

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
            dataGridViewCart.Rows.Clear();

            using (var db = new Computer_Parts_StoreContext())
            {
                if (!LoginSession.IsLoggedIn) return;
                int userID = LoginSession.CurrentCustomer.Id;

                var order = db.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefault(o => o.CustomerId == userID && o.Status == "Кошик");

                if (order == null) return;

                foreach (var item in order.OrderItems)
                {
                    string name = "Unknown";

                    if (item.ProductId != null)
                    {
                        var p = db.Products.FirstOrDefault(x => x.Id == item.ProductId);
                        if (p != null) name = p.Name;
                    }
                    else if (item.PrebuiltComputerId != null)
                    {
                        var pc = db.PrebuiltComputers.FirstOrDefault(x => x.Id == item.PrebuiltComputerId);
                        if (pc != null) name = pc.Name;
                    }

                    int rowIndex = dataGridViewCart.Rows.Add(name, item.UnitPrice, item.Quantity, item.TotalPrice);

                    dataGridViewCart.Rows[rowIndex].Tag = item;
                }
            }
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

            var item = dataGridViewCart.Rows[e.RowIndex].Tag as OrderItem;

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
                    using(var db = new Computer_Parts_StoreContext())
                    {
                        var orderItem = db.OrderItems
                            .Include(oi => oi.Order)
                            .FirstOrDefault(oi => oi.Order.CustomerId == LoginSession.CurrentCustomer.Id &&
                                                  oi.Order.Status == "Кошик" &&
                                                  (oi.Product != null && oi.Product.Id == item.ProductId ||
                                                   oi.PrebuiltComputer != null && oi.PrebuiltComputer.Id == item.PrebuiltComputerId));
                        if (orderItem != null)
                            {
                            db.OrderItems.Remove(orderItem);
                            db.SaveChanges();
                        }
                    }
                    UpdateSummary();
                    MessageBox.Show("Товар видалено з кошика", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (e.ColumnIndex == dataGridViewCart.Columns["colDetails"]?.Index)
            {
                using (var db = new Computer_Parts_StoreContext())
                {
                    var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == item.ProductId);
                    if (product != null)
                    {
                        ProductDetailsForm detailsForm = new ProductDetailsForm(product);
                        detailsForm.ShowDialog();
                        LoadCartItems();
                    }

                    var pc = db.PrebuiltComputers.FirstOrDefault(pc => pc.Id == item.PrebuiltComputerId);
                    if (pc != null)
                    {

                        PCBuilderForm pcDetailsForm = new PCBuilderForm(pc);
                        pcDetailsForm.ShowDialog();
                        LoadCartItems();
                    }
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
            Close();
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
                using (var db = new Computer_Parts_StoreContext())
                {
                    if(!LoginSession.IsLoggedIn) return;
                    int userID = LoginSession.CurrentCustomer.Id;
                    var order = db.Orders
                        .Include(o => o.OrderItems)
                        .FirstOrDefault(o => o.CustomerId == userID && o.Status == "Кошик");
                    if (order != null)
                    {
                        db.OrderItems.RemoveRange(order.OrderItems);
                        db.SaveChanges();
                    }
                }   
                UpdateSummary();
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