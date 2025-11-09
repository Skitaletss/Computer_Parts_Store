namespace Computer_Parts_Store.Forms
{
    partial class ProductCompareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCompareForm));
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            comparisonGrid = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comparisonGrid).BeginInit();
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
            panelHeader.Size = new Size(1200, 70);
            panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1100, 15);
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
            lblTitle.Size = new Size(285, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Порівняння товарів";
            // 
            // comparisonGrid
            // 
            comparisonGrid.AllowUserToAddRows = false;
            comparisonGrid.AllowUserToDeleteRows = false;
            comparisonGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comparisonGrid.BackgroundColor = SystemColors.ButtonHighlight;
            comparisonGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            comparisonGrid.Dock = DockStyle.Fill;
            comparisonGrid.Location = new Point(0, 70);
            comparisonGrid.Name = "comparisonGrid";
            comparisonGrid.ReadOnly = true;
            comparisonGrid.RowHeadersVisible = false;
            comparisonGrid.Size = new Size(1200, 547);
            comparisonGrid.TabIndex = 0;
            // 
            // ProductCompareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 617);
            Controls.Add(comparisonGrid);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductCompareForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Порівняння товарів";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comparisonGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private DataGridView comparisonGrid;
    }
}