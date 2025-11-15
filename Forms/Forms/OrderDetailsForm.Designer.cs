namespace Computer_Parts_Store.Forms
{
    partial class OrderDetailsForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelOrderInfo = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.panelCustomerInfo = new System.Windows.Forms.Panel();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.lblVat = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.btnSaveReceipt = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelOrderInfo.SuspendLayout();
            this.panelCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(900, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(278, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Деталі замовлення";
            // 
            // panelOrderInfo
            // 
            this.panelOrderInfo.BackColor = System.Drawing.Color.White;
            this.panelOrderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderInfo.Controls.Add(this.lblStatus);
            this.panelOrderInfo.Controls.Add(this.lblOrderDate);
            this.panelOrderInfo.Controls.Add(this.lblOrderNumber);
            this.panelOrderInfo.Location = new System.Drawing.Point(20, 90);
            this.panelOrderInfo.Name = "panelOrderInfo";
            this.panelOrderInfo.Size = new System.Drawing.Size(480, 120);
            this.panelOrderInfo.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblStatus.Location = new System.Drawing.Point(15, 85);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOrderDate.Location = new System.Drawing.Point(15, 55);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(47, 20);
            this.lblOrderDate.TabIndex = 1;
            this.lblOrderDate.Text = "Дата:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrderNumber.Location = new System.Drawing.Point(15, 20);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(175, 25);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Замовлення № ...";
            // 
            // panelCustomerInfo
            // 
            this.panelCustomerInfo.BackColor = System.Drawing.Color.White;
            this.panelCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomerInfo.Controls.Add(this.lblCustomerEmail);
            this.panelCustomerInfo.Controls.Add(this.lblCustomerPhone);
            this.panelCustomerInfo.Controls.Add(this.lblCustomerName);
            this.panelCustomerInfo.Controls.Add(this.label1);
            this.panelCustomerInfo.Location = new System.Drawing.Point(520, 90);
            this.panelCustomerInfo.Name = "panelCustomerInfo";
            this.panelCustomerInfo.Size = new System.Drawing.Size(460, 120);
            this.panelCustomerInfo.TabIndex = 2;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCustomerEmail.Location = new System.Drawing.Point(200, 80);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(49, 20);
            this.lblCustomerEmail.TabIndex = 3;
            this.lblCustomerEmail.Text = "Email:";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(15, 80);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(71, 20);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "Телефон:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCustomerName.Location = new System.Drawing.Point(15, 55);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(79, 20);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Покупець:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Покупець";
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.AllowUserToAddRows = false;
            this.dataGridViewOrderItems.AllowUserToDeleteRows = false;
            this.dataGridViewOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colArticle,
            this.colCategory,
            this.colQuantity,
            this.colPrice,
            this.colTotal});
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(20, 230);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.ReadOnly = true;
            this.dataGridViewOrderItems.RowTemplate.Height = 30;
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(960, 400);
            this.dataGridViewOrderItems.TabIndex = 3;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Товар";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 300;
            // 
            // colArticle
            // 
            this.colArticle.HeaderText = "Артикул";
            this.colArticle.Name = "colArticle";
            this.colArticle.ReadOnly = true;
            this.colArticle.Width = 150;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Категорія";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Кількість";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Ціна (грн)";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 120;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Сума (грн)";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 120;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 650);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(234, 30);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Загальна сума: 0.00";
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPrintReceipt.FlatAppearance.BorderSize = 0;
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Location = new System.Drawing.Point(600, 645);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(180, 40);
            this.btnPrintReceipt.TabIndex = 5;
            this.btnPrintReceipt.Text = "🖨️ Друк чека";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVat.ForeColor = System.Drawing.Color.Blue;
            this.lblVat.Location = new System.Drawing.Point(20, 630);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(85, 20);
            this.lblVat.TabIndex = 6;
            this.lblVat.Text = "ПДВ: 0.00";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalItems.Location = new System.Drawing.Point(20, 610);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(180, 20);
            this.lblTotalItems.TabIndex = 7;
            this.lblTotalItems.Text = "Кількість товарів: 0 шт";
            // 
            // btnSaveReceipt
            // 
            this.btnSaveReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSaveReceipt.FlatAppearance.BorderSize = 0;
            this.btnSaveReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveReceipt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveReceipt.ForeColor = System.Drawing.Color.White;
            this.btnSaveReceipt.Location = new System.Drawing.Point(800, 645);
            this.btnSaveReceipt.Name = "btnSaveReceipt";
            this.btnSaveReceipt.Size = new System.Drawing.Size(180, 40);
            this.btnSaveReceipt.TabIndex = 8;
            this.btnSaveReceipt.Text = "💾 Зберегти чек";
            this.btnSaveReceipt.UseVisualStyleBackColor = false;
            this.btnSaveReceipt.Click += new System.EventHandler(this.btnSaveReceipt_Click);
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnSaveReceipt);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.lblVat);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.panelCustomerInfo);
            this.Controls.Add(this.panelOrderInfo);
            this.Controls.Add(this.panelHeader);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Деталі замовлення";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelOrderInfo.ResumeLayout(false);
            this.panelOrderInfo.PerformLayout();
            this.panelCustomerInfo.ResumeLayout(false);
            this.panelCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelOrderInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Panel panelCustomerInfo;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Button btnSaveReceipt;
    }
}