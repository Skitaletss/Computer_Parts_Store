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
            panelHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelComponents = new Panel();
            cmbCooling = new ComboBox();
            lblCooling = new Label();
            cmbCase = new ComboBox();
            lblCase = new Label();
            cmbPSU = new ComboBox();
            lblPSU = new Label();
            cmbStorage = new ComboBox();
            lblStorage = new Label();
            cmbRAM = new ComboBox();
            lblRAM = new Label();
            cmbMotherboard = new ComboBox();
            lblMotherboard = new Label();
            cmbGPU = new ComboBox();
            lblGPU = new Label();
            cmbCPU = new ComboBox();
            lblCPU = new Label();
            lblComponents = new Label();
            panelSummary = new Panel();
            btnClearBuild = new Button();
            btnAddToCart = new Button();
            lblTotalPriceValue = new Label();
            lblTotalPrice = new Label();
            txtBuildSummary = new RichTextBox();
            lblSummary = new Label();
            panelHeader.SuspendLayout();
            panelComponents.SuspendLayout();
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
            panelComponents.Controls.Add(cmbCooling);
            panelComponents.Controls.Add(lblCooling);
            panelComponents.Controls.Add(cmbCase);
            panelComponents.Controls.Add(lblCase);
            panelComponents.Controls.Add(cmbPSU);
            panelComponents.Controls.Add(lblPSU);
            panelComponents.Controls.Add(cmbStorage);
            panelComponents.Controls.Add(lblStorage);
            panelComponents.Controls.Add(cmbRAM);
            panelComponents.Controls.Add(lblRAM);
            panelComponents.Controls.Add(cmbMotherboard);
            panelComponents.Controls.Add(lblMotherboard);
            panelComponents.Controls.Add(cmbGPU);
            panelComponents.Controls.Add(lblGPU);
            panelComponents.Controls.Add(cmbCPU);
            panelComponents.Controls.Add(lblCPU);
            panelComponents.Controls.Add(lblComponents);
            panelComponents.Location = new Point(20, 90);
            panelComponents.Name = "panelComponents";
            panelComponents.Size = new Size(900, 660);
            panelComponents.TabIndex = 1;
            // 
            // cmbCooling
            // 
            cmbCooling.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCooling.Font = new Font("Segoe UI", 10F);
            cmbCooling.FormattingEnabled = true;
            cmbCooling.Location = new Point(20, 540);
            cmbCooling.Name = "cmbCooling";
            cmbCooling.Size = new Size(850, 25);
            cmbCooling.TabIndex = 16;
            cmbCooling.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblCooling
            // 
            lblCooling.AutoSize = true;
            lblCooling.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCooling.Location = new Point(20, 515);
            lblCooling.Name = "lblCooling";
            lblCooling.Size = new Size(178, 20);
            lblCooling.TabIndex = 15;
            lblCooling.Text = "Система охолодження:";
            // 
            // cmbCase
            // 
            cmbCase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCase.Font = new Font("Segoe UI", 10F);
            cmbCase.FormattingEnabled = true;
            cmbCase.Location = new Point(20, 475);
            cmbCase.Name = "cmbCase";
            cmbCase.Size = new Size(850, 25);
            cmbCase.TabIndex = 14;
            cmbCase.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblCase
            // 
            lblCase.AutoSize = true;
            lblCase.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCase.Location = new Point(20, 450);
            lblCase.Name = "lblCase";
            lblCase.Size = new Size(65, 20);
            lblCase.TabIndex = 13;
            lblCase.Text = "Корпус:";
            // 
            // cmbPSU
            // 
            cmbPSU.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPSU.Font = new Font("Segoe UI", 10F);
            cmbPSU.FormattingEnabled = true;
            cmbPSU.Location = new Point(20, 410);
            cmbPSU.Name = "cmbPSU";
            cmbPSU.Size = new Size(850, 25);
            cmbPSU.TabIndex = 12;
            cmbPSU.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblPSU
            // 
            lblPSU.AutoSize = true;
            lblPSU.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPSU.Location = new Point(20, 385);
            lblPSU.Name = "lblPSU";
            lblPSU.Size = new Size(128, 20);
            lblPSU.TabIndex = 11;
            lblPSU.Text = "Блок живлення:";
            // 
            // cmbStorage
            // 
            cmbStorage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStorage.Font = new Font("Segoe UI", 10F);
            cmbStorage.FormattingEnabled = true;
            cmbStorage.Location = new Point(20, 345);
            cmbStorage.Name = "cmbStorage";
            cmbStorage.Size = new Size(850, 25);
            cmbStorage.TabIndex = 10;
            cmbStorage.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblStorage
            // 
            lblStorage.AutoSize = true;
            lblStorage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStorage.Location = new Point(20, 320);
            lblStorage.Name = "lblStorage";
            lblStorage.Size = new Size(110, 20);
            lblStorage.TabIndex = 9;
            lblStorage.Text = "Накопичувач:";
            // 
            // cmbRAM
            // 
            cmbRAM.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRAM.Font = new Font("Segoe UI", 10F);
            cmbRAM.FormattingEnabled = true;
            cmbRAM.Location = new Point(20, 280);
            cmbRAM.Name = "cmbRAM";
            cmbRAM.Size = new Size(850, 25);
            cmbRAM.TabIndex = 8;
            cmbRAM.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblRAM
            // 
            lblRAM.AutoSize = true;
            lblRAM.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRAM.Location = new Point(20, 255);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(161, 20);
            lblRAM.TabIndex = 7;
            lblRAM.Text = "Оперативна пам'ять:";
            // 
            // cmbMotherboard
            // 
            cmbMotherboard.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMotherboard.Font = new Font("Segoe UI", 10F);
            cmbMotherboard.FormattingEnabled = true;
            cmbMotherboard.Location = new Point(20, 215);
            cmbMotherboard.Name = "cmbMotherboard";
            cmbMotherboard.Size = new Size(850, 25);
            cmbMotherboard.TabIndex = 6;
            cmbMotherboard.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblMotherboard
            // 
            lblMotherboard.AutoSize = true;
            lblMotherboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMotherboard.Location = new Point(20, 190);
            lblMotherboard.Name = "lblMotherboard";
            lblMotherboard.Size = new Size(153, 20);
            lblMotherboard.TabIndex = 5;
            lblMotherboard.Text = "Материнська плата:";
            // 
            // cmbGPU
            // 
            cmbGPU.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGPU.Font = new Font("Segoe UI", 10F);
            cmbGPU.FormattingEnabled = true;
            cmbGPU.Location = new Point(20, 150);
            cmbGPU.Name = "cmbGPU";
            cmbGPU.Size = new Size(850, 25);
            cmbGPU.TabIndex = 4;
            cmbGPU.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblGPU
            // 
            lblGPU.AutoSize = true;
            lblGPU.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGPU.Location = new Point(20, 125);
            lblGPU.Name = "lblGPU";
            lblGPU.Size = new Size(93, 20);
            lblGPU.TabIndex = 3;
            lblGPU.Text = "Відеокарта:";
            // 
            // cmbCPU
            // 
            cmbCPU.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCPU.Font = new Font("Segoe UI", 10F);
            cmbCPU.FormattingEnabled = true;
            cmbCPU.Location = new Point(20, 85);
            cmbCPU.Name = "cmbCPU";
            cmbCPU.Size = new Size(850, 25);
            cmbCPU.TabIndex = 2;
            cmbCPU.SelectedIndexChanged += Component_SelectedIndexChanged;
            // 
            // lblCPU
            // 
            lblCPU.AutoSize = true;
            lblCPU.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCPU.Location = new Point(20, 60);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(85, 20);
            lblCPU.TabIndex = 1;
            lblCPU.Text = "Процесор:";
            // 
            // lblComponents
            // 
            lblComponents.AutoSize = true;
            lblComponents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblComponents.Location = new Point(15, 15);
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
            Controls.Add(panelSummary);
            Controls.Add(panelComponents);
            Controls.Add(panelHeader);
            MinimumSize = new Size(1000, 819);
            Name = "PCBuilderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Збірка комп'ютера";
            Resize += PCBuilderForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelComponents.ResumeLayout(false);
            panelComponents.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelComponents;
        private System.Windows.Forms.Label lblComponents;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.ComboBox cmbCPU;
        private System.Windows.Forms.Label lblGPU;
        private System.Windows.Forms.ComboBox cmbGPU;
        private System.Windows.Forms.Label lblMotherboard;
        private System.Windows.Forms.ComboBox cmbMotherboard;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.ComboBox cmbRAM;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.ComboBox cmbStorage;
        private System.Windows.Forms.Label lblPSU;
        private System.Windows.Forms.ComboBox cmbPSU;
        private System.Windows.Forms.Label lblCase;
        private System.Windows.Forms.ComboBox cmbCase;
        private System.Windows.Forms.Label lblCooling;
        private System.Windows.Forms.ComboBox cmbCooling;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.RichTextBox txtBuildSummary;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalPriceValue;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnClearBuild;
    }
}