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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {
            int contentWidth = panelContent.ClientSize.Width;

            float scale = 1.0f;

            if (contentWidth < 600)
            {
                scale = 0.7f;
            }
            else if (contentWidth > 1500)
            {
                scale = 1.3f;
            }
            else
            {
                scale = 1f + (contentWidth - 600) / 900f * 0.6f;
            }

            lblWelcome.Font = new Font("Segoe UI", 20f * scale, FontStyle.Bold);
            lblInfo.Font = new Font("Segoe UI", 14f * scale);
            lblWelcome.Margin = new Padding((int)(20 * scale));
            lblInfo.Margin = new Padding((int)(20 * scale), 0, (int)(20 * scale), (int)(20 * scale));

            if (panelContent.ClientSize.Height > 450)
            {
                btnExit.Location = new Point(
                    btnExit.Location.X,
                    panelMenu.ClientSize.Height - btnExit.Height - 20
                );
            }

        }
    }
}