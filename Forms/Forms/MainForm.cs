using System;
using System.Drawing;
using System.Windows.Forms;

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
            // Создание каталога
            CatalogForm catalogForm = new CatalogForm();
            catalogForm.ShowDialog();
        }

        private void btnPCBuilder_Click(object? sender, EventArgs e)
        {
            PCBuilderForm pcBuilderForm = new PCBuilderForm();
            pcBuilderForm.ShowDialog();
        }

        private void btnPrebuilt_Click(object? sender, EventArgs e)
        {
            PrebuiltComputersForm prebuiltForm = new PrebuiltComputersForm();
            prebuiltForm.ShowDialog();
        }

        private void btnCart_Click(object? sender, EventArgs e)
        {
            ShoppingCartForm cartForm = new ShoppingCartForm();
            cartForm.ShowDialog();
        }

        private void btnSalesHistory_Click(object? sender, EventArgs e)
        {
            SalesHistoryForm salesForm = new SalesHistoryForm();
            salesForm.ShowDialog();
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