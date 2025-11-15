using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Computer_Parts_Store.Models;
using Computer_Parts_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class CheckoutForm : Form
    {
        private List<CartItem> _cartItems;
        public bool OrderCreated { get; private set; }

        public CheckoutForm(List<CartItem> cartItems)
        {
            InitializeComponent();
            _cartItems = cartItems;
            OrderCreated = false;
            LoadOrderDetails();
            lblOrderDateValue.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        private void LoadOrderDetails()
        {
            dataGridViewOrder.Rows.Clear();
            foreach (var item in _cartItems)
            {
                dataGridViewOrder.Rows.Add(
                    item.Name,
                    item.Quantity,
                    item.Price,
                    item.Total
                );
            }
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = _cartItems.Sum(item => item.Total);
            lblTotalAmountValue.Text = total.ToString("F2");
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введіть прізвище!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введіть ім'я!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
            {
                MessageBox.Show("Введіть по батькові!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMiddleName.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Підтвердити замовлення?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Збереження замовлення в базу даних
                    int orderId = SaveOrderToDatabase();

                    OrderCreated = true;
                    MessageBox.Show("Замовлення успішно оформлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Відкриваємо форму деталей замовлення
                    OrderDetailsForm orderDetailsForm = new OrderDetailsForm(orderId);
                    orderDetailsForm.ShowDialog();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні замовлення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int SaveOrderToDatabase()
        {
            using var context = new Computer_Parts_StoreContext();

            // Створення або пошук клієнта
            var customer = CreateOrFindCustomer(context);

            // Створення замовлення
            var order = new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now,
                Status = "Нове"
            };

            context.Orders.Add(order);
            context.SaveChanges(); // Зберігаємо, щоб отримати OrderId

            // Додавання товарів до замовлення
            foreach (var cartItem in _cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Price
                };

                context.OrderItems.Add(orderItem);

                // Оновлення залишків товару
                var product = context.Products.Find(cartItem.ProductId);
                if (product != null)
                {
                    if (product.StockQuantity >= cartItem.Quantity)
                    {
                        product.StockQuantity -= cartItem.Quantity;
                    }
                    else
                    {
                        throw new Exception($"Недостатньо товару на складі: {product.Name}");
                    }
                }
                else
                {
                    throw new Exception($"Товар не знайдено: {cartItem.Name}");
                }
            }

            context.SaveChanges();
            return order.Id;
        }

        private Customer CreateOrFindCustomer(Computer_Parts_StoreContext context)
        {
            // Спрощена логіка - завжди створюємо нового клієнта
            var customer = new Customer
            {
                FullName = $"{txtLastName.Text.Trim()} {txtFirstName.Text.Trim()} {txtMiddleName.Text.Trim()}",
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Скасувати оформлення замовлення?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}