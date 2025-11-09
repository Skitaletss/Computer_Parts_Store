namespace Computer_Parts_Store.Forms
{
    partial class CheckoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckoutForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelCustomerInfo = new Panel();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtMiddleName = new TextBox();
            lblMiddleName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            lblCustomerInfo = new Label();
            panelOrderSummary = new Panel();
            btnCancel = new Button();
            btnConfirmOrder = new Button();
            lblOrderDateValue = new Label();
            lblOrderDate = new Label();
            lblTotalAmountValue = new Label();
            lblTotalAmount = new Label();
            dataGridViewOrder = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            lblOrderSummary = new Label();
            panelHeader.SuspendLayout();
            panelCustomerInfo.SuspendLayout();
            panelOrderSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).BeginInit();
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
            lblTitle.Size = new Size(362, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Оформлення замовлення";
            // 
            // panelCustomerInfo
            // 
            panelCustomerInfo.BackColor = Color.White;
            panelCustomerInfo.BorderStyle = BorderStyle.FixedSingle;
            panelCustomerInfo.Controls.Add(txtEmail);
            panelCustomerInfo.Controls.Add(lblEmail);
            panelCustomerInfo.Controls.Add(txtPhone);
            panelCustomerInfo.Controls.Add(lblPhone);
            panelCustomerInfo.Controls.Add(txtMiddleName);
            panelCustomerInfo.Controls.Add(lblMiddleName);
            panelCustomerInfo.Controls.Add(txtFirstName);
            panelCustomerInfo.Controls.Add(lblFirstName);
            panelCustomerInfo.Controls.Add(txtLastName);
            panelCustomerInfo.Controls.Add(lblLastName);
            panelCustomerInfo.Controls.Add(lblCustomerInfo);
            panelCustomerInfo.Location = new Point(20, 90);
            panelCustomerInfo.Name = "panelCustomerInfo";
            panelCustomerInfo.Size = new Size(650, 350);
            panelCustomerInfo.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(315, 280);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 27);
            txtEmail.TabIndex = 10;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F);
            lblEmail.Location = new Point(315, 255);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(121, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email (опційно):";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(15, 280);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(280, 27);
            txtPhone.TabIndex = 8;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 11F);
            lblPhone.Location = new Point(15, 255);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(144, 20);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Телефон (опційно):";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 11F);
            txtMiddleName.Location = new Point(15, 215);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(600, 27);
            txtMiddleName.TabIndex = 6;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 11F);
            lblMiddleName.Location = new Point(15, 190);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(95, 20);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "По батькові:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 11F);
            txtFirstName.Location = new Point(15, 150);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(600, 27);
            txtFirstName.TabIndex = 4;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 11F);
            lblFirstName.Location = new Point(15, 125);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(38, 20);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "Ім'я:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 11F);
            txtLastName.Location = new Point(15, 85);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(600, 27);
            txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 11F);
            lblLastName.Location = new Point(15, 60);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(80, 20);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Прізвище:";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCustomerInfo.Location = new Point(15, 15);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(196, 25);
            lblCustomerInfo.TabIndex = 0;
            lblCustomerInfo.Text = "Дані покупця (ПІБ):";
            // 
            // panelOrderSummary
            // 
            panelOrderSummary.BackColor = Color.White;
            panelOrderSummary.BorderStyle = BorderStyle.FixedSingle;
            panelOrderSummary.Controls.Add(btnCancel);
            panelOrderSummary.Controls.Add(btnConfirmOrder);
            panelOrderSummary.Controls.Add(lblOrderDateValue);
            panelOrderSummary.Controls.Add(lblOrderDate);
            panelOrderSummary.Controls.Add(lblTotalAmountValue);
            panelOrderSummary.Controls.Add(lblTotalAmount);
            panelOrderSummary.Controls.Add(dataGridViewOrder);
            panelOrderSummary.Controls.Add(lblOrderSummary);
            panelOrderSummary.Location = new Point(690, 90);
            panelOrderSummary.Name = "panelOrderSummary";
            panelOrderSummary.Size = new Size(690, 660);
            panelOrderSummary.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(350, 595);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(320, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "✗ Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirmOrder
            // 
            btnConfirmOrder.BackColor = Color.FromArgb(39, 174, 96);
            btnConfirmOrder.FlatAppearance.BorderSize = 0;
            btnConfirmOrder.FlatStyle = FlatStyle.Flat;
            btnConfirmOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirmOrder.ForeColor = Color.White;
            btnConfirmOrder.Location = new Point(15, 595);
            btnConfirmOrder.Name = "btnConfirmOrder";
            btnConfirmOrder.Size = new Size(320, 50);
            btnConfirmOrder.TabIndex = 6;
            btnConfirmOrder.Text = "✓ Підтвердити замовлення";
            btnConfirmOrder.UseVisualStyleBackColor = false;
            btnConfirmOrder.Click += btnConfirmOrder_Click;
            // 
            // lblOrderDateValue
            // 
            lblOrderDateValue.AutoSize = true;
            lblOrderDateValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrderDateValue.Location = new Point(140, 550);
            lblOrderDateValue.Name = "lblOrderDateValue";
            lblOrderDateValue.Size = new Size(81, 19);
            lblOrderDateValue.TabIndex = 5;
            lblOrderDateValue.Text = "01.01.2025";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI", 10F);
            lblOrderDate.Location = new Point(15, 550);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(121, 19);
            lblOrderDate.TabIndex = 4;
            lblOrderDate.Text = "Дата замовлення:";
            // 
            // lblTotalAmountValue
            // 
            lblTotalAmountValue.AutoSize = true;
            lblTotalAmountValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalAmountValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalAmountValue.Location = new Point(15, 500);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(63, 32);
            lblTotalAmountValue.TabIndex = 3;
            lblTotalAmountValue.Text = "0.00";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(15, 475);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(171, 21);
            lblTotalAmount.TabIndex = 2;
            lblTotalAmount.Text = "Загальна сума (грн):";
            // 
            // dataGridViewOrder
            // 
            dataGridViewOrder.AllowUserToAddRows = false;
            dataGridViewOrder.AllowUserToDeleteRows = false;
            dataGridViewOrder.BackgroundColor = Color.White;
            dataGridViewOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrder.Columns.AddRange(new DataGridViewColumn[] { colName, colQuantity, colPrice, colTotal });
            dataGridViewOrder.Location = new Point(15, 55);
            dataGridViewOrder.Name = "dataGridViewOrder";
            dataGridViewOrder.ReadOnly = true;
            dataGridViewOrder.RowTemplate.Height = 35;
            dataGridViewOrder.Size = new Size(655, 400);
            dataGridViewOrder.TabIndex = 1;
            // 
            // colName
            // 
            colName.HeaderText = "Назва";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 300;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "К-сть";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 80;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Ціна";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 120;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Сума";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 120;
            // 
            // lblOrderSummary
            // 
            lblOrderSummary.AutoSize = true;
            lblOrderSummary.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOrderSummary.Location = new Point(15, 15);
            lblOrderSummary.Name = "lblOrderSummary";
            lblOrderSummary.Size = new Size(195, 25);
            lblOrderSummary.TabIndex = 0;
            lblOrderSummary.Text = "Деталі замовлення:";
            // 
            // CheckoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(panelOrderSummary);
            Controls.Add(panelCustomerInfo);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CheckoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформлення замовлення";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCustomerInfo.ResumeLayout(false);
            panelCustomerInfo.PerformLayout();
            panelOrderSummary.ResumeLayout(false);
            panelOrderSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelCustomerInfo;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panelOrderSummary;
        private System.Windows.Forms.Label lblOrderSummary;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderDateValue;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.Button btnCancel;
    }
}