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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new Computer_Parts_StoreContext())
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.FullName.Contains(txtLogin.Text) || c.Email.Contains(txtLogin.Text) || c.Phone.Contains(txtLogin.Text) || c.Password == txtPassword.Text);
                if (customer != null)
                {
                    LoginSession.Login(customer);
                    MessageBox.Show("Вхід успішний", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильний логін або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Close();
        }

    }
}
