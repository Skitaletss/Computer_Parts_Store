namespace Computer_Parts_Store.Forms
{
    partial class SalesHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesHistoryForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelFilters = new Panel();
            btnGenerateReport = new Button();
            btnClearFilter = new Button();
            btnApplyFilter = new Button();
            dtpDateTo = new DateTimePicker();
            lblDateTo = new Label();
            dtpDateFrom = new DateTimePicker();
            lblDateFrom = new Label();
            lblFilters = new Label();
            dataGridViewSales = new DataGridView();
            colOrderNumber = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colItemsCount = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colViewDetails = new DataGridViewButtonColumn();
            panelSummary = new Panel();
            lblAverageOrderValue = new Label();
            lblAverageOrder = new Label();
            lblTotalRevenueValue = new Label();
            lblTotalRevenue = new Label();
            lblTotalOrdersValue = new Label();
            lblTotalOrders = new Label();
            lblSummaryTitle = new Label();
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
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
            lblTitle.Size = new Size(245, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Історія продажів";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.White;
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(btnGenerateReport);
            panelFilters.Controls.Add(btnClearFilter);
            panelFilters.Controls.Add(btnApplyFilter);
            panelFilters.Controls.Add(dtpDateTo);
            panelFilters.Controls.Add(lblDateTo);
            panelFilters.Controls.Add(dtpDateFrom);
            panelFilters.Controls.Add(lblDateFrom);
            panelFilters.Controls.Add(lblFilters);
            panelFilters.Location = new Point(20, 90);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1000, 100);
            panelFilters.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(41, 128, 185);
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(820, 35);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(160, 40);
            btnGenerateReport.TabIndex = 7;
            btnGenerateReport.Text = "📊 Сформувати звіт";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(149, 165, 166);
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(640, 35);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(120, 40);
            btnClearFilter.TabIndex = 6;
            btnClearFilter.Text = "Очистити";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.BackColor = Color.FromArgb(39, 174, 96);
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApplyFilter.ForeColor = Color.White;
            btnApplyFilter.Location = new Point(510, 35);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(120, 40);
            btnApplyFilter.TabIndex = 5;
            btnApplyFilter.Text = "Застосувати";
            btnApplyFilter.UseVisualStyleBackColor = false;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // dtpDateTo
            // 
            dtpDateTo.Font = new Font("Segoe UI", 10F);
            dtpDateTo.Format = DateTimePickerFormat.Short;
            dtpDateTo.Location = new Point(340, 43);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(150, 25);
            dtpDateTo.TabIndex = 4;
            // 
            // lblDateTo
            // 
            lblDateTo.AutoSize = true;
            lblDateTo.Font = new Font("Segoe UI", 10F);
            lblDateTo.Location = new Point(260, 45);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(62, 19);
            lblDateTo.TabIndex = 3;
            lblDateTo.Text = "Дата по:";
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Font = new Font("Segoe UI", 10F);
            dtpDateFrom.Format = DateTimePickerFormat.Short;
            dtpDateFrom.Location = new Point(90, 43);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(150, 25);
            dtpDateFrom.TabIndex = 2;
            // 
            // lblDateFrom
            // 
            lblDateFrom.AutoSize = true;
            lblDateFrom.Font = new Font("Segoe UI", 10F);
            lblDateFrom.Location = new Point(15, 45);
            lblDateFrom.Name = "lblDateFrom";
            lblDateFrom.Size = new Size(52, 19);
            lblDateFrom.TabIndex = 1;
            lblDateFrom.Text = "Дата з:";
            // 
            // lblFilters
            // 
            lblFilters.AutoSize = true;
            lblFilters.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFilters.Location = new Point(15, 10);
            lblFilters.Name = "lblFilters";
            lblFilters.Size = new Size(126, 21);
            lblFilters.TabIndex = 0;
            lblFilters.Text = "Фільтр по даті:";
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.AllowUserToDeleteRows = false;
            dataGridViewSales.BackgroundColor = Color.White;
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Columns.AddRange(new DataGridViewColumn[] { colOrderNumber, colDate, colCustomer, colItemsCount, colTotalAmount, colViewDetails });
            dataGridViewSales.Location = new Point(20, 210);
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.ReadOnly = true;
            dataGridViewSales.RowTemplate.Height = 35;
            dataGridViewSales.Size = new Size(1000, 540);
            dataGridViewSales.TabIndex = 2;
            dataGridViewSales.CellContentClick += dataGridViewSales_CellContentClick;
            // 
            // colOrderNumber
            // 
            colOrderNumber.HeaderText = "№ Замовлення";
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.ReadOnly = true;
            colOrderNumber.Width = 120;
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 150;
            // 
            // colCustomer
            // 
            colCustomer.HeaderText = "Покупець";
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            colCustomer.Width = 300;
            // 
            // colItemsCount
            // 
            colItemsCount.HeaderText = "К-сть товарів";
            colItemsCount.Name = "colItemsCount";
            colItemsCount.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            colTotalAmount.HeaderText = "Сума (грн)";
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.ReadOnly = true;
            colTotalAmount.Width = 150;
            // 
            // colViewDetails
            // 
            colViewDetails.HeaderText = "Деталі";
            colViewDetails.Name = "colViewDetails";
            colViewDetails.ReadOnly = true;
            colViewDetails.Text = "Переглянути";
            colViewDetails.UseColumnTextForButtonValue = true;
            colViewDetails.Width = 120;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(lblAverageOrderValue);
            panelSummary.Controls.Add(lblAverageOrder);
            panelSummary.Controls.Add(lblTotalRevenueValue);
            panelSummary.Controls.Add(lblTotalRevenue);
            panelSummary.Controls.Add(lblTotalOrdersValue);
            panelSummary.Controls.Add(lblTotalOrders);
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Location = new Point(1040, 90);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(340, 660);
            panelSummary.TabIndex = 3;
            // 
            // lblAverageOrderValue
            // 
            lblAverageOrderValue.AutoSize = true;
            lblAverageOrderValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAverageOrderValue.ForeColor = Color.FromArgb(230, 126, 34);
            lblAverageOrderValue.Location = new Point(15, 285);
            lblAverageOrderValue.Name = "lblAverageOrderValue";
            lblAverageOrderValue.Size = new Size(63, 32);
            lblAverageOrderValue.TabIndex = 6;
            lblAverageOrderValue.Text = "0.00";
            // 
            // lblAverageOrder
            // 
            lblAverageOrder.AutoSize = true;
            lblAverageOrder.Font = new Font("Segoe UI", 11F);
            lblAverageOrder.Location = new Point(15, 260);
            lblAverageOrder.Name = "lblAverageOrder";
            lblAverageOrder.Size = new Size(230, 20);
            lblAverageOrder.TabIndex = 5;
            lblAverageOrder.Text = "Середній чек замовлення (грн):";
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.AutoSize = true;
            lblTotalRevenueValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalRevenueValue.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalRevenueValue.Location = new Point(15, 195);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(63, 32);
            lblTotalRevenueValue.TabIndex = 4;
            lblTotalRevenueValue.Text = "0.00";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 11F);
            lblTotalRevenue.Location = new Point(15, 170);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(163, 20);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "Загальний дохід (грн):";
            // 
            // lblTotalOrdersValue
            // 
            lblTotalOrdersValue.AutoSize = true;
            lblTotalOrdersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalOrdersValue.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalOrdersValue.Location = new Point(15, 105);
            lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            lblTotalOrdersValue.Size = new Size(28, 32);
            lblTotalOrdersValue.TabIndex = 2;
            lblTotalOrdersValue.Text = "0";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 11F);
            lblTotalOrders.Location = new Point(15, 80);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(140, 20);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "Всього замовлень:";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummaryTitle.Location = new Point(15, 20);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(115, 25);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Статистика";
            // 
            // SalesHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1400, 780);
            Controls.Add(panelSummary);
            Controls.Add(dataGridViewSales);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SalesHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Історія продажів";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colViewDetails;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblAverageOrder;
        private System.Windows.Forms.Label lblAverageOrderValue;
    }
}