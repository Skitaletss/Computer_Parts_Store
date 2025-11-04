namespace Computer_Parts_Store.Forms
{
    partial class PrebuiltComputersForm
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
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            colAddToCart = new DataGridViewButtonColumn();
            colViewDetails = new DataGridViewButtonColumn();
            colAvailability = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            dataGridViewPrebuilt = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrebuilt).BeginInit();
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
            lblTitle.Size = new Size(322, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Готові конфігурації ПК";
            // 
            // colAddToCart
            // 
            colAddToCart.HeaderText = "Додати";
            colAddToCart.Name = "colAddToCart";
            colAddToCart.ReadOnly = true;
            colAddToCart.Text = "У кошик";
            colAddToCart.UseColumnTextForButtonValue = true;
            colAddToCart.Width = 130;
            // 
            // colViewDetails
            // 
            colViewDetails.HeaderText = "Деталі";
            colViewDetails.Name = "colViewDetails";
            colViewDetails.ReadOnly = true;
            colViewDetails.Text = "Переглянути";
            colViewDetails.UseColumnTextForButtonValue = true;
            colViewDetails.Width = 130;
            // 
            // colAvailability
            // 
            colAvailability.HeaderText = "Наявність";
            colAvailability.Name = "colAvailability";
            colAvailability.ReadOnly = true;
            colAvailability.Width = 120;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Ціна (грн)";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 120;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Опис";
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            colDescription.Width = 550;
            // 
            // colName
            // 
            colName.HeaderText = "Назва конфігурації";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 250;
            // 
            // dataGridViewPrebuilt
            // 
            dataGridViewPrebuilt.AllowUserToAddRows = false;
            dataGridViewPrebuilt.AllowUserToDeleteRows = false;
            dataGridViewPrebuilt.BackgroundColor = Color.White;
            dataGridViewPrebuilt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrebuilt.Columns.AddRange(new DataGridViewColumn[] { colName, colDescription, colPrice, colAvailability, colViewDetails, colAddToCart });
            dataGridViewPrebuilt.Location = new Point(20, 90);
            dataGridViewPrebuilt.Name = "dataGridViewPrebuilt";
            dataGridViewPrebuilt.ReadOnly = true;
            dataGridViewPrebuilt.RowTemplate.Height = 50;
            dataGridViewPrebuilt.Size = new Size(1360, 660);
            dataGridViewPrebuilt.TabIndex = 1;
            dataGridViewPrebuilt.CellContentClick += dataGridViewPrebuilt_CellContentClick;
            // 
            // PrebuiltComputersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(dataGridViewPrebuilt);
            Controls.Add(panelHeader);
            MaximumSize = new Size(1416, 1028);
            MinimumSize = new Size(1416, 408);
            Name = "PrebuiltComputersForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Готові конфігурації ПК";
            Resize += PrebuiltComputersForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrebuilt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private DataGridViewButtonColumn colAddToCart;
        private DataGridViewButtonColumn colViewDetails;
        private DataGridViewTextBoxColumn colAvailability;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colName;
        private DataGridView dataGridViewPrebuilt;
    }
}