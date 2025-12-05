using System;
using System.Windows.Forms;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class ProductDetailsForm : Form
    {
        private readonly Product product;
        public ProductDetailsForm(Product p)
        {
            InitializeComponent();
            product = p;
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            lblProductName.Text = product.Name;
            lblArticleValue.Text = product.Article;
            lblCategoryValue.Text = product.Category.Name;
            lblPriceValue.Text = product.Price.ToString();
            lblQuantityValue.Text = product.StockQuantity.ToString();
            lblColorValue.Text = product.Color;
            lblManufacturerValue.Text = product.Manufacturer;
            lblModelValue.Text = product.Model;
            lblSizeValue.Text = product.Dimensions;
            lblWeightValue.Text = product.Weight?.ToString();
            lblWarrantyValue.Text = product.WarrantyMonths?.ToString();
            lblSpecValue.Text = product.Specification;
            txtDescription.Text = product.Description;

            // Встановити максимальну кількість
            numericQuantity.Maximum = product.StockQuantity;
            numericQuantity.Minimum = 1;
            numericQuantity.Value = 1;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericQuantity.Value;

            if (!LoginSession.IsLoggedIn)
            {
                MessageBox.Show("Спочатку увійдіть у свій акаунт", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Перевірка наявності на складі
            if (quantity > product.StockQuantity)
            {
                MessageBox.Show("Недостатня кількість товару на складі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userID = LoginSession.CurrentCustomer.Id;
            using (var db = new Computer_Parts_StoreContext())
            {
                var cartOrder = db.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefault(o => o.CustomerId == userID && o.Status == "Кошик");

                if (cartOrder == null)
                {
                    cartOrder = new Order
                    {
                        CustomerId = userID,
                        Status = "Кошик",
                        OrderDate = DateTime.Now
                    };
                    db.Orders.Add(cartOrder);
                }

                OrderItem? cartItem = cartOrder.OrderItems.FirstOrDefault(i => i.ProductId == product.Id);

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {

                    if (cartOrder.OrderItems == null)
                    {
                        cartOrder.OrderItems = new List<OrderItem>();
                    }

                    var trackedProduct = db.Products.Find(product.Id);

                    cartOrder.OrderItems.Add(
                        new OrderItem
                        {
                            Product = trackedProduct,
                            Quantity = quantity,
                            UnitPrice = trackedProduct.Price
                        }
                    );
                }

                db.SaveChanges();
            }

            MessageBox.Show($"Додано {quantity} од. товару до кошика", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}