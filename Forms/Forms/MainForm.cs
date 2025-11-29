using Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Computer_Parts_Store.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCatalog_Click(object? sender, EventArgs e)
        {
            Hide();
            CatalogForm catalogForm = new CatalogForm();
            catalogForm.ShowDialog();
            Show();
        }

        private void btnPCBuilder_Click(object? sender, EventArgs e)
        {
            Hide();
            PCBuilderForm pcBuilderForm = new PCBuilderForm();
            pcBuilderForm.ShowDialog();
            Show();
        }

        private void btnPrebuilt_Click(object? sender, EventArgs e)
        {
            Hide();
            PrebuiltComputersForm prebuiltForm = new PrebuiltComputersForm();
            prebuiltForm.ShowDialog();
            Show();
        }

        private void btnCart_Click(object? sender, EventArgs e)
        {
            Hide();
            ShoppingCartForm cartForm = new ShoppingCartForm();
            cartForm.ShowDialog();
            Show();
        }

        private void btnSalesHistory_Click(object? sender, EventArgs e)
        {
            Hide();
            SalesHistoryForm salesForm = new SalesHistoryForm();
            salesForm.ShowDialog();
            Show();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            Show();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            Show();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете вийти?",
                "Підтвердження виходу",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuButton_MouseEnter(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void MenuButton_MouseLeave(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(52, 73, 94);
            }
        }

    }
}