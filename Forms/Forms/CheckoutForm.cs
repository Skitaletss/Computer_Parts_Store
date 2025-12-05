using Computer_Parts_Store.Data;
using System;
using System.Windows.Forms;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class CheckoutForm : Form
    {
        private Order? currentOrder;
        public CheckoutForm()
        {
            InitializeComponent();
            LoadOrderDetails();
            lblOrderDateValue.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        private void LoadOrderDetails()
        {
            using (var db = new Computer_Parts_StoreContext())
            {
                if (!LoginSession.IsLoggedIn) return;
                int userID = LoginSession.CurrentCustomer.Id;

                Order? order = db.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.PrebuiltComputer)
                    .ThenInclude(pc => pc.Products)
                    .FirstOrDefault(o => o.CustomerId == userID && o.Status == "Кошик");

                if (order == null) return;

                currentOrder = order;

                foreach (var item in order.OrderItems)
                {
                    switch (item.ProductId, item.PrebuiltComputerId)
                    {
                        case (not null, null):
                            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == item.ProductId);
                            if (product != null)
                            {
                                dataGridViewOrder.Rows.Add(product.Name, item.Quantity, item.UnitPrice, item.TotalPrice);
                            }
                            break;
                        case (null, not null):
                            var pc = db.PrebuiltComputers.FirstOrDefault(pc => pc.Id == item.PrebuiltComputerId);
                            if (pc != null)
                            {
                                dataGridViewOrder.Rows.Add(pc.Name, item.Quantity, item.UnitPrice, item.TotalPrice);
                            }
                            break;
                    }
                }

                lblTotalAmountValue.Text = order.TotalAmount.ToString("F2");
            }
        }

        private void btnConfirmOrder_Click(object? sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Підтвердити замовлення?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new Computer_Parts_StoreContext())
                {
                    Order? order = db.Orders
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.PrebuiltComputer)
                        .ThenInclude(pc => pc.Products)
                        .FirstOrDefault(o => o.Id == currentOrder.Id);
                    if (order != null)
                    {
                        order.Status = "Підтверджено";
                        order.OrderDate = DateTime.Now;
                        foreach (var item in order.OrderItems)
                        {
                            if (item.ProductId != null) item.Product.StockQuantity -= item.Quantity;
                            if (item.PrebuiltComputerId != null)
                            {
                                foreach (var product in item.PrebuiltComputer.Products)
                                {
                                    product.StockQuantity -= 1;
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    ReceiptForm receiptForm = new ReceiptForm(currentOrder);
                    receiptForm.ShowDialog();

                    var customPCs = db.PrebuiltComputers
                        .Where(pc => pc.Name.StartsWith(LoginSession.CurrentCustomer.FullName))
                        .ToList();
                    db.RemoveRange(customPCs);
                };
                Close();
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Скасувати оформлення замовлення?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}