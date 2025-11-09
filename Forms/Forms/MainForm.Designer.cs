namespace Computer_Parts_Store.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelMenu = new Panel();
            btnExit = new Button();
            btnSalesHistory = new Button();
            btnCart = new Button();
            btnPrebuilt = new Button();
            btnPCBuilder = new Button();
            btnCatalog = new Button();
            panelContent = new Panel();
            lblInfo = new Label();
            lblWelcome = new Label();
            panelHeader.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(25, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(346, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Підберіть ідеальну конфігурацію для вашого ПК";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(653, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Магазин комп'ютерних комплектуючих";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(52, 73, 94);
            panelMenu.Controls.Add(btnExit);
            panelMenu.Controls.Add(btnSalesHistory);
            panelMenu.Controls.Add(btnCart);
            panelMenu.Controls.Add(btnPrebuilt);
            panelMenu.Controls.Add(btnPCBuilder);
            panelMenu.Controls.Add(btnCatalog);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 100);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(250, 600);
            panelMenu.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(192, 57, 43);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(25, 530);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 50);
            btnExit.TabIndex = 5;
            btnExit.Text = "🚪 Вихід";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnSalesHistory
            // 
            btnSalesHistory.BackColor = Color.FromArgb(52, 73, 94);
            btnSalesHistory.FlatAppearance.BorderSize = 0;
            btnSalesHistory.FlatStyle = FlatStyle.Flat;
            btnSalesHistory.Font = new Font("Segoe UI", 12F);
            btnSalesHistory.ForeColor = Color.White;
            btnSalesHistory.Location = new Point(0, 300);
            btnSalesHistory.Name = "btnSalesHistory";
            btnSalesHistory.Size = new Size(250, 60);
            btnSalesHistory.TabIndex = 4;
            btnSalesHistory.Text = "📊 Історія продажів";
            btnSalesHistory.UseVisualStyleBackColor = false;
            btnSalesHistory.Click += btnSalesHistory_Click;
            btnSalesHistory.MouseEnter += MenuButton_MouseEnter;
            btnSalesHistory.MouseLeave += MenuButton_MouseLeave;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(52, 73, 94);
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 12F);
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(0, 230);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(250, 60);
            btnCart.TabIndex = 3;
            btnCart.Text = "\U0001f6d2 Кошик";
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += btnCart_Click;
            btnCart.MouseEnter += MenuButton_MouseEnter;
            btnCart.MouseLeave += MenuButton_MouseLeave;
            // 
            // btnPrebuilt
            // 
            btnPrebuilt.BackColor = Color.FromArgb(52, 73, 94);
            btnPrebuilt.FlatAppearance.BorderSize = 0;
            btnPrebuilt.FlatStyle = FlatStyle.Flat;
            btnPrebuilt.Font = new Font("Segoe UI", 12F);
            btnPrebuilt.ForeColor = Color.White;
            btnPrebuilt.Location = new Point(0, 160);
            btnPrebuilt.Name = "btnPrebuilt";
            btnPrebuilt.Size = new Size(250, 60);
            btnPrebuilt.TabIndex = 2;
            btnPrebuilt.Text = "💻 Готові ПК";
            btnPrebuilt.UseVisualStyleBackColor = false;
            btnPrebuilt.Click += btnPrebuilt_Click;
            btnPrebuilt.MouseEnter += MenuButton_MouseEnter;
            btnPrebuilt.MouseLeave += MenuButton_MouseLeave;
            // 
            // btnPCBuilder
            // 
            btnPCBuilder.BackColor = Color.FromArgb(52, 73, 94);
            btnPCBuilder.FlatAppearance.BorderSize = 0;
            btnPCBuilder.FlatStyle = FlatStyle.Flat;
            btnPCBuilder.Font = new Font("Segoe UI", 12F);
            btnPCBuilder.ForeColor = Color.White;
            btnPCBuilder.Location = new Point(0, 90);
            btnPCBuilder.Name = "btnPCBuilder";
            btnPCBuilder.Size = new Size(250, 60);
            btnPCBuilder.TabIndex = 1;
            btnPCBuilder.Text = "🔧 Збірка ПК";
            btnPCBuilder.UseVisualStyleBackColor = false;
            btnPCBuilder.Click += btnPCBuilder_Click;
            btnPCBuilder.MouseEnter += MenuButton_MouseEnter;
            btnPCBuilder.MouseLeave += MenuButton_MouseLeave;
            // 
            // btnCatalog
            // 
            btnCatalog.BackColor = Color.FromArgb(52, 73, 94);
            btnCatalog.FlatAppearance.BorderSize = 0;
            btnCatalog.FlatStyle = FlatStyle.Flat;
            btnCatalog.Font = new Font("Segoe UI", 12F);
            btnCatalog.ForeColor = Color.White;
            btnCatalog.Location = new Point(0, 20);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Size = new Size(250, 60);
            btnCatalog.TabIndex = 0;
            btnCatalog.Text = "📦 Каталог товарів";
            btnCatalog.UseVisualStyleBackColor = false;
            btnCatalog.Click += btnCatalog_Click;
            btnCatalog.MouseEnter += MenuButton_MouseEnter;
            btnCatalog.MouseLeave += MenuButton_MouseLeave;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(236, 240, 241);
            panelContent.Controls.Add(lblInfo);
            panelContent.Controls.Add(lblWelcome);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(250, 100);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(950, 600);
            panelContent.TabIndex = 2;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfo.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.World, 204);
            lblInfo.ForeColor = Color.FromArgb(52, 73, 94);
            lblInfo.Location = new Point(50, 128);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(850, 398);
            lblInfo.TabIndex = 1;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(52, 73, 94);
            lblWelcome.Location = new Point(50, 27);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(850, 53);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Ласкаво просимо!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelHeader);
            MinimumSize = new Size(800, 650);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Магазин комп'ютерних комплектуючих";
            Resize += MainForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnPCBuilder;
        private System.Windows.Forms.Button btnPrebuilt;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnSalesHistory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInfo;
    }
}