namespace Computer_Parts_Store.Forms
{
    partial class ProductDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDetailsForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelProductInfo = new Panel();
            lblWarrantyValue = new Label();
            label10 = new Label();
            lblWeightValue = new Label();
            label12 = new Label();
            lblSizeValue = new Label();
            label14 = new Label();
            lblColorValue = new Label();
            label2 = new Label();
            lblSpecValue = new Label();
            label6 = new Label();
            lblModelValue = new Label();
            label8 = new Label();
            lblManufacturerValue = new Label();
            label4 = new Label();
            btnAddToCart = new Button();
            lblSelectQuantity = new Label();
            numericQuantity = new NumericUpDown();
            txtDescription = new RichTextBox();
            lblDescription = new Label();
            lblQuantityValue = new Label();
            lblQuantity = new Label();
            lblPriceValue = new Label();
            lblPrice = new Label();
            lblCategoryValue = new Label();
            lblCategory = new Label();
            lblArticleValue = new Label();
            lblArticle = new Label();
            lblProductName = new Label();
            panelHeader.SuspendLayout();
            panelProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
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
            panelHeader.Size = new Size(800, 70);
            panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(700, 15);
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
            lblTitle.Size = new Size(203, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Деталі товару";
            // 
            // panelProductInfo
            // 
            panelProductInfo.BackColor = Color.White;
            panelProductInfo.BorderStyle = BorderStyle.FixedSingle;
            panelProductInfo.Controls.Add(lblWarrantyValue);
            panelProductInfo.Controls.Add(label10);
            panelProductInfo.Controls.Add(lblWeightValue);
            panelProductInfo.Controls.Add(label12);
            panelProductInfo.Controls.Add(lblSizeValue);
            panelProductInfo.Controls.Add(label14);
            panelProductInfo.Controls.Add(lblColorValue);
            panelProductInfo.Controls.Add(label2);
            panelProductInfo.Controls.Add(lblSpecValue);
            panelProductInfo.Controls.Add(label6);
            panelProductInfo.Controls.Add(lblModelValue);
            panelProductInfo.Controls.Add(label8);
            panelProductInfo.Controls.Add(lblManufacturerValue);
            panelProductInfo.Controls.Add(label4);
            panelProductInfo.Controls.Add(btnAddToCart);
            panelProductInfo.Controls.Add(lblSelectQuantity);
            panelProductInfo.Controls.Add(numericQuantity);
            panelProductInfo.Controls.Add(txtDescription);
            panelProductInfo.Controls.Add(lblDescription);
            panelProductInfo.Controls.Add(lblQuantityValue);
            panelProductInfo.Controls.Add(lblQuantity);
            panelProductInfo.Controls.Add(lblPriceValue);
            panelProductInfo.Controls.Add(lblPrice);
            panelProductInfo.Controls.Add(lblCategoryValue);
            panelProductInfo.Controls.Add(lblCategory);
            panelProductInfo.Controls.Add(lblArticleValue);
            panelProductInfo.Controls.Add(lblArticle);
            panelProductInfo.Controls.Add(lblProductName);
            panelProductInfo.Location = new Point(30, 100);
            panelProductInfo.Name = "panelProductInfo";
            panelProductInfo.Size = new Size(740, 688);
            panelProductInfo.TabIndex = 1;
            // 
            // lblWarrantyValue
            // 
            lblWarrantyValue.AutoSize = true;
            lblWarrantyValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWarrantyValue.Location = new Point(337, 148);
            lblWarrantyValue.Name = "lblWarrantyValue";
            lblWarrantyValue.Size = new Size(39, 20);
            lblWarrantyValue.TabIndex = 27;
            lblWarrantyValue.Text = "N/A";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(257, 148);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 26;
            label10.Text = "Гарантія:";
            // 
            // lblWeightValue
            // 
            lblWeightValue.AutoSize = true;
            lblWeightValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWeightValue.Location = new Point(604, 111);
            lblWeightValue.Name = "lblWeightValue";
            lblWeightValue.Size = new Size(39, 20);
            lblWeightValue.TabIndex = 25;
            lblWeightValue.Text = "N/A";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F);
            label12.ForeColor = Color.Gray;
            label12.Location = new Point(519, 111);
            label12.Name = "label12";
            label12.Size = new Size(43, 20);
            label12.TabIndex = 24;
            label12.Text = "Вага:";
            // 
            // lblSizeValue
            // 
            lblSizeValue.AutoSize = true;
            lblSizeValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSizeValue.Location = new Point(599, 75);
            lblSizeValue.Name = "lblSizeValue";
            lblSizeValue.Size = new Size(39, 20);
            lblSizeValue.TabIndex = 23;
            lblSizeValue.Text = "N/A";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(519, 75);
            label14.Name = "label14";
            label14.Size = new Size(60, 20);
            label14.TabIndex = 22;
            label14.Text = "Розмір:";
            // 
            // lblColorValue
            // 
            lblColorValue.AutoSize = true;
            lblColorValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblColorValue.Location = new Point(599, 148);
            lblColorValue.Name = "lblColorValue";
            lblColorValue.Size = new Size(39, 20);
            lblColorValue.TabIndex = 21;
            lblColorValue.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(519, 148);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 20;
            label2.Text = "Колір:";
            // 
            // lblSpecValue
            // 
            lblSpecValue.AutoSize = true;
            lblSpecValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSpecValue.Location = new Point(369, 111);
            lblSpecValue.Name = "lblSpecValue";
            lblSpecValue.Size = new Size(39, 20);
            lblSpecValue.TabIndex = 19;
            lblSpecValue.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(257, 111);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 18;
            label6.Text = "Специфікація:";
            // 
            // lblModelValue
            // 
            lblModelValue.AutoSize = true;
            lblModelValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblModelValue.Location = new Point(337, 75);
            lblModelValue.Name = "lblModelValue";
            lblModelValue.Size = new Size(39, 20);
            lblModelValue.TabIndex = 17;
            lblModelValue.Text = "N/A";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(257, 75);
            label8.Name = "label8";
            label8.Size = new Size(66, 20);
            label8.TabIndex = 16;
            label8.Text = "Модель:";
            // 
            // lblManufacturerValue
            // 
            lblManufacturerValue.AutoSize = true;
            lblManufacturerValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblManufacturerValue.Location = new Point(108, 148);
            lblManufacturerValue.Name = "lblManufacturerValue";
            lblManufacturerValue.Size = new Size(39, 20);
            lblManufacturerValue.TabIndex = 15;
            lblManufacturerValue.Text = "N/A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(20, 148);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 14;
            label4.Text = "Виробник:";
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(39, 174, 96);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(20, 621);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(700, 50);
            btnAddToCart.TabIndex = 13;
            btnAddToCart.Text = "\U0001f6d2 Додати до кошика";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lblSelectQuantity
            // 
            lblSelectQuantity.AutoSize = true;
            lblSelectQuantity.Font = new Font("Segoe UI", 11F);
            lblSelectQuantity.Location = new Point(20, 576);
            lblSelectQuantity.Name = "lblSelectQuantity";
            lblSelectQuantity.Size = new Size(137, 20);
            lblSelectQuantity.TabIndex = 12;
            lblSelectQuantity.Text = "Виберіть кількість:";
            // 
            // numericQuantity
            // 
            numericQuantity.Font = new Font("Segoe UI", 12F);
            numericQuantity.Location = new Point(170, 571);
            numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(100, 29);
            numericQuantity.TabIndex = 11;
            numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(20, 351);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(700, 200);
            txtDescription.TabIndex = 10;
            txtDescription.Text = "";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescription.Location = new Point(20, 321);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(54, 21);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Опис:";
            // 
            // lblQuantityValue
            // 
            lblQuantityValue.AutoSize = true;
            lblQuantityValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuantityValue.Location = new Point(110, 276);
            lblQuantityValue.Name = "lblQuantityValue";
            lblQuantityValue.Size = new Size(46, 20);
            lblQuantityValue.TabIndex = 8;
            lblQuantityValue.Text = "0 шт.";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 11F);
            lblQuantity.ForeColor = Color.Gray;
            lblQuantity.Location = new Point(20, 276);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(77, 20);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "На складі:";
            // 
            // lblPriceValue
            // 
            lblPriceValue.AutoSize = true;
            lblPriceValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPriceValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblPriceValue.Location = new Point(20, 221);
            lblPriceValue.Name = "lblPriceValue";
            lblPriceValue.Size = new Size(124, 37);
            lblPriceValue.TabIndex = 6;
            lblPriceValue.Text = "0.00 грн";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 14F);
            lblPrice.ForeColor = Color.Gray;
            lblPrice.Location = new Point(20, 191);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(56, 25);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Ціна:";
            // 
            // lblCategoryValue
            // 
            lblCategoryValue.AutoSize = true;
            lblCategoryValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCategoryValue.Location = new Point(105, 111);
            lblCategoryValue.Name = "lblCategoryValue";
            lblCategoryValue.Size = new Size(39, 20);
            lblCategoryValue.TabIndex = 4;
            lblCategoryValue.Text = "N/A";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 11F);
            lblCategory.ForeColor = Color.Gray;
            lblCategory.Location = new Point(20, 111);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Категорія:";
            // 
            // lblArticleValue
            // 
            lblArticleValue.AutoSize = true;
            lblArticleValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblArticleValue.Location = new Point(94, 75);
            lblArticleValue.Name = "lblArticleValue";
            lblArticleValue.Size = new Size(39, 20);
            lblArticleValue.TabIndex = 2;
            lblArticleValue.Text = "N/A";
            // 
            // lblArticle
            // 
            lblArticle.AutoSize = true;
            lblArticle.Font = new Font("Segoe UI", 11F);
            lblArticle.ForeColor = Color.Gray;
            lblArticle.Location = new Point(20, 75);
            lblArticle.Name = "lblArticle";
            lblArticle.Size = new Size(68, 20);
            lblArticle.TabIndex = 1;
            lblArticle.Text = "Артикул:";
            // 
            // lblProductName
            // 
            lblProductName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblProductName.Location = new Point(20, 20);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(700, 40);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Назва товару";
            // 
            // ProductDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(800, 800);
            Controls.Add(panelProductInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Деталі товару";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelProductInfo.ResumeLayout(false);
            panelProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelProductInfo;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label lblArticleValue;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCategoryValue;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblQuantityValue;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label lblSelectQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private Label lblManufacturerValue;
        private Label label4;
        private Label lblWarrantyValue;
        private Label label10;
        private Label lblWeightValue;
        private Label label12;
        private Label lblSizeValue;
        private Label label14;
        private Label lblColorValue;
        private Label label2;
        private Label lblSpecValue;
        private Label label6;
        private Label lblModelValue;
        private Label label8;
    }
}