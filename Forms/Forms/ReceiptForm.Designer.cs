namespace Computer_Parts_Store.Forms

{

    partial class ReceiptForm

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            panelHeader = new Panel();
            lblTitle = new Label();
            panelReceipt = new Panel();
            lblThankYou = new Label();
            lblTotal = new Label();
            lblSubtotal = new Label();
            lblSeparator3 = new Label();
            dataGridViewItems = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            lblSeparator2 = new Label();
            lblCustomer = new Label();
            lblOrderDate = new Label();
            lblOrderNumber = new Label();
            lblSeparator1 = new Label();
            lblStoreInfo = new Label();
            lblStoreName = new Label();
            btnPrint = new Button();
            btnSave = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            panelReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(39, 174, 96);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(333, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✓ Замовлення успішне!";
            // 
            // panelReceipt
            // 
            panelReceipt.BackColor = Color.White;
            panelReceipt.BorderStyle = BorderStyle.FixedSingle;
            panelReceipt.Controls.Add(lblThankYou);
            panelReceipt.Controls.Add(lblTotal);
            panelReceipt.Controls.Add(lblSubtotal);
            panelReceipt.Controls.Add(lblSeparator3);
            panelReceipt.Controls.Add(dataGridViewItems);
            panelReceipt.Controls.Add(lblSeparator2);
            panelReceipt.Controls.Add(lblCustomer);
            panelReceipt.Controls.Add(lblOrderDate);
            panelReceipt.Controls.Add(lblOrderNumber);
            panelReceipt.Controls.Add(lblSeparator1);
            panelReceipt.Controls.Add(lblStoreInfo);
            panelReceipt.Controls.Add(lblStoreName);
            panelReceipt.Location = new Point(50, 100);
            panelReceipt.Name = "panelReceipt";
            panelReceipt.Size = new Size(800, 850);
            panelReceipt.TabIndex = 1;
            // 
            // lblThankYou
            // 
            lblThankYou.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblThankYou.ForeColor = Color.Gray;
            lblThankYou.Location = new Point(0, 800);
            lblThankYou.Name = "lblThankYou";
            lblThankYou.Size = new Size(800, 25);
            lblThankYou.TabIndex = 11;
            lblThankYou.Text = "Дякуємо за покупку! Гарного дня!";
            lblThankYou.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(500, 750);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(171, 25);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "ВСЬОГО: 0.00 грн";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 11F);
            lblSubtotal.Location = new Point(500, 720);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(180, 20);
            lblSubtotal.TabIndex = 9;
            lblSubtotal.Text = "Проміжна сума: 0.00 грн";
            // 
            // lblSeparator3
            // 
            lblSeparator3.BorderStyle = BorderStyle.Fixed3D;
            lblSeparator3.Location = new Point(50, 700);
            lblSeparator3.Name = "lblSeparator3";
            lblSeparator3.Size = new Size(700, 2);
            lblSeparator3.TabIndex = 8;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.BackgroundColor = Color.White;
            dataGridViewItems.BorderStyle = BorderStyle.None;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { colName, colQuantity, colPrice, colTotal });
            dataGridViewItems.Location = new Point(50, 240);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.RowTemplate.Height = 30;
            dataGridViewItems.Size = new Size(700, 450);
            dataGridViewItems.TabIndex = 7;
            // 
            // colName
            // 
            colName.HeaderText = "Найменування";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 350;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "К-сть";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 70;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Ціна";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 130;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Сума";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 130;
            // 
            // lblSeparator2
            // 
            lblSeparator2.BorderStyle = BorderStyle.Fixed3D;
            lblSeparator2.Location = new Point(50, 220);
            lblSeparator2.Name = "lblSeparator2";
            lblSeparator2.Size = new Size(700, 2);
            lblSeparator2.TabIndex = 6;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10F);
            lblCustomer.Location = new Point(50, 185);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(210, 19);
            lblCustomer.TabIndex = 5;
            lblCustomer.Text = "Покупець: Іванов Іван Іванович";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI", 10F);
            lblOrderDate.Location = new Point(50, 160);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(174, 19);
            lblOrderDate.TabIndex = 4;
            lblOrderDate.Text = "Дата: 01.01.2025 12:00:00";
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOrderNumber.Location = new Point(50, 130);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(188, 21);
            lblOrderNumber.TabIndex = 3;
            lblOrderNumber.Text = "Замовлення № 000001";
            // 
            // lblSeparator1
            // 
            lblSeparator1.BorderStyle = BorderStyle.Fixed3D;
            lblSeparator1.Location = new Point(50, 110);
            lblSeparator1.Name = "lblSeparator1";
            lblSeparator1.Size = new Size(700, 2);
            lblSeparator1.TabIndex = 2;
            // 
            // lblStoreInfo
            // 
            lblStoreInfo.Font = new Font("Segoe UI", 10F);
            lblStoreInfo.ForeColor = Color.Gray;
            lblStoreInfo.Location = new Point(0, 60);
            lblStoreInfo.Name = "lblStoreInfo";
            lblStoreInfo.Size = new Size(800, 40);
            lblStoreInfo.TabIndex = 1;
            lblStoreInfo.Text = "м. Київ, вул. Хрещатик 1\r\nТел: +380 (44) 123-45-67 | Email: shop@computerparts.ua";
            lblStoreInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStoreName
            // 
            lblStoreName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStoreName.Location = new Point(0, 20);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(800, 35);
            lblStoreName.TabIndex = 0;
            lblStoreName.Text = "МАГАЗИН КОМП'ЮТЕРНИХ КОМПЛЕКТУЮЧИХ";
            lblStoreName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(41, 128, 185);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(50, 970);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(250, 45);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "🖨️ Роздрукувати";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(39, 174, 96);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(325, 970);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 45);
            btnSave.TabIndex = 3;
            btnSave.Text = "💾 Зберегти як PDF";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(600, 970);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(250, 45);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(900, 1030);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnPrint);
            Controls.Add(panelReceipt);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Чек замовлення";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelReceipt.ResumeLayout(false);
            panelReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);

        }



        #endregion



        private System.Windows.Forms.Panel panelHeader;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel panelReceipt;

        private System.Windows.Forms.Label lblStoreName;

        private System.Windows.Forms.Label lblStoreInfo;

        private System.Windows.Forms.Label lblSeparator1;

        private System.Windows.Forms.Label lblOrderNumber;

        private System.Windows.Forms.Label lblOrderDate;

        private System.Windows.Forms.Label lblCustomer;

        private System.Windows.Forms.Label lblSeparator2;

        private System.Windows.Forms.DataGridView dataGridViewItems;

        private System.Windows.Forms.DataGridViewTextBoxColumn colName;

        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;

        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;

        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;

        private System.Windows.Forms.Label lblSeparator3;

        private System.Windows.Forms.Label lblSubtotal;

        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.Label lblThankYou;

        private System.Windows.Forms.Button btnPrint;

        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.Button btnClose;

    }

}