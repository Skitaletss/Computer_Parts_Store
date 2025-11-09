namespace Computer_Parts_Store.Forms
{
    partial class ShoppingCartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingCartForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            dataGridViewCart = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colArticle = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            panelSummary = new Panel();
            btnClearCart = new Button();
            btnCheckout = new Button();
            lblTotalPriceValue = new Label();
            lblTotalPrice = new Label();
            lblItemsCountValue = new Label();
            lblItemsCount = new Label();
            lblSummaryTitle = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
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
            lblTitle.Size = new Size(107, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Кошик";
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCart.BackgroundColor = Color.White;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Columns.AddRange(new DataGridViewColumn[] { colName, colArticle, colPrice, colQuantity, colTotal, colRemove });
            dataGridViewCart.Location = new Point(20, 90);
            dataGridViewCart.MinimumSize = new Size(500, 660);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowTemplate.Height = 40;
            dataGridViewCart.Size = new Size(1000, 660);
            dataGridViewCart.TabIndex = 1;
            dataGridViewCart.CellContentClick += dataGridViewCart_CellContentClick;
            dataGridViewCart.CellValueChanged += dataGridViewCart_CellValueChanged;
            // 
            // colName
            // 
            colName.HeaderText = "Назва товару";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 350;
            // 
            // colArticle
            // 
            colArticle.HeaderText = "Артикул";
            colArticle.Name = "colArticle";
            colArticle.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Ціна (грн)";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 120;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Кількість";
            colQuantity.Name = "colQuantity";
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Сума (грн)";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 120;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "Видалити";
            colRemove.Name = "colRemove";
            colRemove.Text = "Видалити";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 110;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(btnClearCart);
            panelSummary.Controls.Add(btnCheckout);
            panelSummary.Controls.Add(lblTotalPriceValue);
            panelSummary.Controls.Add(lblTotalPrice);
            panelSummary.Controls.Add(lblItemsCountValue);
            panelSummary.Controls.Add(lblItemsCount);
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Location = new Point(1040, 90);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(340, 660);
            panelSummary.TabIndex = 2;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(192, 57, 43);
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(15, 605);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(300, 40);
            btnClearCart.TabIndex = 6;
            btnClearCart.Text = "🗑️ Очистити кошик";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(39, 174, 96);
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(15, 550);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(300, 50);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "✓ Оформити замовлення";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // lblTotalPriceValue
            // 
            lblTotalPriceValue.AutoSize = true;
            lblTotalPriceValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalPriceValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalPriceValue.Location = new Point(15, 165);
            lblTotalPriceValue.Name = "lblTotalPriceValue";
            lblTotalPriceValue.Size = new Size(63, 32);
            lblTotalPriceValue.TabIndex = 4;
            lblTotalPriceValue.Text = "0.00";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 11F);
            lblTotalPrice.Location = new Point(15, 140);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(120, 20);
            lblTotalPrice.TabIndex = 3;
            lblTotalPrice.Text = "До сплати (грн):";
            // 
            // lblItemsCountValue
            // 
            lblItemsCountValue.AutoSize = true;
            lblItemsCountValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblItemsCountValue.Location = new Point(15, 95);
            lblItemsCountValue.Name = "lblItemsCountValue";
            lblItemsCountValue.Size = new Size(19, 21);
            lblItemsCountValue.TabIndex = 2;
            lblItemsCountValue.Text = "0";
            // 
            // lblItemsCount
            // 
            lblItemsCount.AutoSize = true;
            lblItemsCount.Font = new Font("Segoe UI", 11F);
            lblItemsCount.Location = new Point(15, 70);
            lblItemsCount.Name = "lblItemsCount";
            lblItemsCount.Size = new Size(129, 20);
            lblItemsCount.TabIndex = 1;
            lblItemsCount.Text = "Кількість товарів:";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummaryTitle.Location = new Point(15, 20);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(219, 25);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Підсумок замовлення";
            // 
            // ShoppingCartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(panelSummary);
            Controls.Add(dataGridViewCart);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(780, 819);
            Name = "ShoppingCartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Кошик покупок";
            Resize += ShoppingCartForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label lblItemsCountValue;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalPriceValue;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}