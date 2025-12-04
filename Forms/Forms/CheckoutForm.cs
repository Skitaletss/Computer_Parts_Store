using System;
using System.Windows.Forms;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Computer_Parts_Store.Forms
{
    public partial class CheckoutForm : Form
    {
        private Computer_Parts_StoreContext _context;
        private List<CartItem> _cartItems;
        private decimal _totalAmount;

        public CheckoutForm(List<CartItem> cartItems)
        {
            InitializeComponent();
            _context = new Computer_Parts_StoreContext();
            _cartItems = cartItems ?? new List<CartItem>();

            // Перевіряємо чи кошик не порожній
            if (!_cartItems.Any())
            {
                MessageBox.Show("Кошик порожній. Додайте товари перед оформленням замовлення.", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            LoadOrderDetails();
            lblOrderDateValue.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // Конструктор без параметрів для зворотної сумісності
        public CheckoutForm() : this(new List<CartItem>())
        {
        }

        private void LoadOrderDetails()
        {
            dataGridViewOrder.Rows.Clear();
            _totalAmount = 0;

            // Завантаження товарів з кошика з бази даних
            foreach (var cartItem in _cartItems)
            {
                // Отримуємо інформацію про товар з бази
                var product = _context.Products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                if (product != null)
                {
                    decimal itemTotal = product.Price * cartItem.Quantity;
                    dataGridViewOrder.Rows.Add(
                        product.Name,
                        cartItem.Quantity,
                        product.Price,
                        itemTotal
                    );
                    _totalAmount += itemTotal;
                }
            }

            lblTotalAmountValue.Text = _totalAmount.ToString("F2");
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            // Додаткова перевірка на випадок порожнього кошика
            if (!_cartItems.Any())
            {
                MessageBox.Show("Кошик порожній. Неможливо оформити замовлення.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                $"Підтвердити замовлення на суму {_totalAmount:F2} грн?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Створюємо або знаходимо покупця в базі
                    var customerFullName = $"{txtLastName.Text} {txtFirstName.Text} {txtMiddleName.Text}";
                    var customer = _context.Customers.FirstOrDefault(c => c.FullName == customerFullName);

                    if (customer == null)
                    {
                        customer = new Customer
                        {
                            FullName = customerFullName,
                            Phone = txtPhone.Text,
                            Email = txtEmail.Text
                        };
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                    }

                    // Створюємо замовлення
                    var order = new Order
                    {
                        CustomerId = customer.Id,
                        OrderDate = DateTime.Now,
                        Status = "Оформлено"
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    // Додаємо товари до замовлення
                    var orderItems = new List<OrderItem>();

                    foreach (var cartItem in _cartItems)
                    {
                        var product = _context.Products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                        if (product != null)
                        {
                            // Перевіряємо чи є достатня кількість товару на складі
                            if (product.StockQuantity < cartItem.Quantity)
                            {
                                MessageBox.Show($"Недостатня кількість товару '{product.Name}' на складі. Доступно: {product.StockQuantity}",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var orderItem = new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = product.Id,
                                Quantity = cartItem.Quantity,
                                UnitPrice = product.Price
                            };
                            orderItems.Add(orderItem);

                            // Оновлюємо кількість товару на складі
                            product.StockQuantity -= cartItem.Quantity;
                        }
                    }

                    _context.OrderItems.AddRange(orderItems);
                    _context.SaveChanges();

                    // Завантажуємо повну інформацію про замовлення для чека
                    var fullOrder = _context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                        .FirstOrDefault(o => o.Id == order.Id);

                    MessageBox.Show($"Замовлення №{order.Id:D6} успішно оформлено!", "Успіх",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Відкриваємо чек з реальним замовленням
                    ReceiptForm receiptForm = new ReceiptForm(fullOrder);
                    receiptForm.ShowDialog();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при оформленні замовлення: {ex.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

    // Допоміжний клас для елементів кошика
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}