namespace Computer_Parts_Store.Forms
{
    partial class CatalogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelFilters = new Panel();
            txtSearch = new TextBox();
            priceMax = new NumericUpDown();
            priceMin = new NumericUpDown();
            btnCompare = new Button();
            btnClearFilter = new Button();
            lblPriceTo = new Label();
            lblPriceFrom = new Label();
            lblSearch = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            lblFilters = new Label();
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priceMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceMin).BeginInit();
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
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(229, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Каталог товарів";
            // 
            // panelFilters
            // 
            panelFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFilters.BackColor = Color.White;
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(priceMax);
            panelFilters.Controls.Add(priceMin);
            panelFilters.Controls.Add(btnCompare);
            panelFilters.Controls.Add(btnClearFilter);
            panelFilters.Controls.Add(lblPriceTo);
            panelFilters.Controls.Add(lblPriceFrom);
            panelFilters.Controls.Add(lblSearch);
            panelFilters.Controls.Add(cmbCategory);
            panelFilters.Controls.Add(lblCategory);
            panelFilters.Controls.Add(lblFilters);
            panelFilters.Location = new Point(20, 90);
            panelFilters.Margin = new Padding(20, 20, 60, 10);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1283, 120);
            panelFilters.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(250, 72);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(418, 23);
            txtSearch.TabIndex = 14;
            // 
            // priceMax
            // 
            priceMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceMax.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            priceMax.Location = new Point(863, 72);
            priceMax.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceMax.Name = "priceMax";
            priceMax.Size = new Size(120, 23);
            priceMax.TabIndex = 13;
            priceMax.ThousandsSeparator = true;
            priceMax.ValueChanged += PriceChanged;
            // 
            // priceMin
            // 
            priceMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceMin.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            priceMin.Location = new Point(723, 72);
            priceMin.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            priceMin.Name = "priceMin";
            priceMin.Size = new Size(120, 23);
            priceMin.TabIndex = 12;
            priceMin.ThousandsSeparator = true;
            priceMin.ValueChanged += PriceChanged;
            // 
            // btnCompare
            // 
            btnCompare.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCompare.BackColor = Color.FromArgb(41, 128, 185);
            btnCompare.FlatAppearance.BorderSize = 0;
            btnCompare.FlatStyle = FlatStyle.Flat;
            btnCompare.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCompare.ForeColor = Color.White;
            btnCompare.Location = new Point(1113, 55);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(140, 40);
            btnCompare.TabIndex = 11;
            btnCompare.Text = "⚖️ Порівняти";
            btnCompare.UseVisualStyleBackColor = false;
            btnCompare.Click += btnCompare_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearFilter.BackColor = Color.FromArgb(149, 165, 166);
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(1007, 55);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(100, 40);
            btnClearFilter.TabIndex = 10;
            btnClearFilter.Text = "Очистити";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // lblPriceTo
            // 
            lblPriceTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPriceTo.AutoSize = true;
            lblPriceTo.Font = new Font("Segoe UI", 10F);
            lblPriceTo.Location = new Point(863, 45);
            lblPriceTo.Name = "lblPriceTo";
            lblPriceTo.Size = new Size(60, 19);
            lblPriceTo.TabIndex = 7;
            lblPriceTo.Text = "Ціна до:";
            // 
            // lblPriceFrom
            // 
            lblPriceFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPriceFrom.AutoSize = true;
            lblPriceFrom.Font = new Font("Segoe UI", 10F);
            lblPriceFrom.Location = new Point(723, 45);
            lblPriceFrom.Name = "lblPriceFrom";
            lblPriceFrom.Size = new Size(62, 19);
            lblPriceFrom.TabIndex = 5;
            lblPriceFrom.Text = "Ціна від:";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(250, 45);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(131, 19);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Пошук (назва/арт.):";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(20, 70);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 25);
            cmbCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(20, 45);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(71, 19);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Категорія:";
            // 
            // lblFilters
            // 
            lblFilters.AutoSize = true;
            lblFilters.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFilters.Location = new Point(20, 10);
            lblFilters.Name = "lblFilters";
            lblFilters.Size = new Size(154, 21);
            lblFilters.TabIndex = 0;
            lblFilters.Text = "Фільтри та пошук:";
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(20, 232);
            listView1.Margin = new Padding(20, 10, 60, 20);
            listView1.Name = "listView1";
            listView1.Size = new Size(1320, 528);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(41, 128, 185);
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(1310, 90);
            button1.Margin = new Padding(0, 0, 20, 0);
            button1.Name = "button1";
            button1.Size = new Size(30, 54);
            button1.TabIndex = 3;
            button1.Text = "☰";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(41, 128, 185);
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(1310, 156);
            button2.Margin = new Padding(0, 0, 20, 0);
            button2.Name = "button2";
            button2.Size = new Size(30, 54);
            button2.TabIndex = 4;
            button2.Text = "≡";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // CatalogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 500);
            Name = "CatalogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог товарів";
            Load += CatalogForm_Load;
            Resize += CatalogForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priceMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceMin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblPriceFrom;
        private System.Windows.Forms.Label lblPriceTo;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnCompare;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private NumericUpDown priceMax;
        private NumericUpDown priceMin;
        private TextBox txtSearch;
    }
}