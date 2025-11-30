using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computer_Parts_Store.Models;
using Computer_Parts_Store.Data;

namespace Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Заповніть усі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Паролі не збігаюються", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var db = new Computer_Parts_StoreContext())
            {
                var repeatCheck = db.Customers.FirstOrDefault(u => u.FullName == txtUsername.Text);
                if (repeatCheck != null)
                {
                    MessageBox.Show("Користувач з таким логіном уже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var customer = new Customer
                {
                    FullName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Password = txtPassword.Text
                };
                db.Customers.Add(customer);
                db.SaveChanges();
                LoginSession.Login(customer);
                MessageBox.Show("Реєстрація успішна", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
