namespace Computer_Parts_Store.Forms
{
    partial class PCBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCBuilderForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelComponents = new Panel();
            lblComponents = new Label();
            panelSummary = new Panel();
            btnClearBuild = new Button();
            btnAddToCart = new Button();
            lblTotalPriceValue = new Label();
            lblTotalPrice = new Label();
            txtBuildSummary = new RichTextBox();
            lblSummary = new Label();
            panelHeader.SuspendLayout();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1400, 70);
            panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1300, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(448, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Конструктор збірки комп'ютера";
            // 
            // panelComponents
            // 
            panelComponents.BackColor = Color.White;
            panelComponents.BorderStyle = BorderStyle.FixedSingle;
            panelComponents.Location = new Point(20, 127);
            panelComponents.Name = "panelComponents";
            panelComponents.Size = new Size(900, 623);
            panelComponents.TabIndex = 1;
            // 
            // lblComponents
            // 
            lblComponents.AutoSize = true;
            lblComponents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblComponents.Location = new Point(20, 90);
            lblComponents.Name = "lblComponents";
            lblComponents.Size = new Size(239, 25);
            lblComponents.TabIndex = 0;
            lblComponents.Text = "Виберіть комплектуючі:";
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(btnClearBuild);
            panelSummary.Controls.Add(btnAddToCart);
            panelSummary.Controls.Add(lblTotalPriceValue);
            panelSummary.Controls.Add(lblTotalPrice);
            panelSummary.Controls.Add(txtBuildSummary);
            panelSummary.Controls.Add(lblSummary);
            panelSummary.Location = new Point(940, 90);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(440, 660);
            panelSummary.TabIndex = 2;
            // 
            // btnClearBuild
            // 
            btnClearBuild.BackColor = Color.FromArgb(149, 165, 166);
            btnClearBuild.FlatAppearance.BorderSize = 0;
            btnClearBuild.FlatStyle = FlatStyle.Flat;
            btnClearBuild.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClearBuild.ForeColor = Color.White;
            btnClearBuild.Location = new Point(225, 595);
            btnClearBuild.Name = "btnClearBuild";
            btnClearBuild.Size = new Size(200, 45);
            btnClearBuild.TabIndex = 5;
            btnClearBuild.Text = "🗑️ Очистити збірку";
            btnClearBuild.UseVisualStyleBackColor = false;
            btnClearBuild.Click += btnClearBuild_Click;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(39, 174, 96);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(15, 595);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(200, 45);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "\U0001f6d2 Додати до кошика";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lblTotalPriceValue
            // 
            lblTotalPriceValue.AutoSize = true;
            lblTotalPriceValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalPriceValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalPriceValue.Location = new Point(15, 550);
            lblTotalPriceValue.Name = "lblTotalPriceValue";
            lblTotalPriceValue.Size = new Size(100, 30);
            lblTotalPriceValue.TabIndex = 3;
            lblTotalPriceValue.Text = "0.00 грн";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalPrice.Location = new Point(15, 520);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(144, 25);
            lblTotalPrice.TabIndex = 2;
            lblTotalPrice.Text = "Загальна ціна:";
            // 
            // txtBuildSummary
            // 
            txtBuildSummary.BorderStyle = BorderStyle.FixedSingle;
            txtBuildSummary.Font = new Font("Segoe UI", 10F);
            txtBuildSummary.Location = new Point(15, 55);
            txtBuildSummary.Name = "txtBuildSummary";
            txtBuildSummary.ReadOnly = true;
            txtBuildSummary.Size = new Size(410, 450);
            txtBuildSummary.TabIndex = 1;
            txtBuildSummary.Text = "";
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummary.Location = new Point(15, 15);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(193, 25);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Ваша конфігурація:";
            // 
            // PCBuilderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(lblComponents);
            Controls.Add(panelSummary);
            Controls.Add(panelComponents);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 819);
            Name = "PCBuilderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Збірка комп'ютера";
            Resize += PCBuilderForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelComponents;
        private System.Windows.Forms.Label lblComponents;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.RichTextBox txtBuildSummary;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalPriceValue;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnClearBuild;
    }
}