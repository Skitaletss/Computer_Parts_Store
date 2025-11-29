namespace Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            lblPassword = new Label();
            lblLogin = new Label();
            btnRegister = new Button();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            panelHeader = new Panel();
            button1 = new Button();
            close = new Button();
            btnClose = new Button();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtPhone = new TextBox();
            label3 = new Label();
            txtConfirmPassword = new TextBox();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassword.Location = new Point(20, 185);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(224, 21);
            lblPassword.TabIndex = 21;
            lblPassword.Text = "Введіть електронну пошту:";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogin.Location = new Point(20, 109);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(207, 21);
            lblLogin.TabIndex = 20;
            lblLogin.Text = "Введіть ім'я та прізвище:";
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(41, 128, 185);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(119, 516);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(157, 53);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Зареєструватися";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(20, 209);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 23);
            txtEmail.TabIndex = 18;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(20, 133);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 23);
            txtUsername.TabIndex = 17;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(button1);
            panelHeader.Controls.Add(close);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(405, 70);
            panelHeader.TabIndex = 16;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(192, 57, 43);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(303, 17);
            button1.Name = "button1";
            button1.Size = new Size(80, 40);
            button1.TabIndex = 29;
            button1.Text = "Закрити";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnClose_Click;
            // 
            // close
            // 
            close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            close.BackColor = Color.FromArgb(192, 57, 43);
            close.FlatAppearance.BorderSize = 0;
            close.FlatStyle = FlatStyle.Flat;
            close.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            close.ForeColor = Color.White;
            close.Location = new Point(510, 17);
            close.Name = "close";
            close.Size = new Size(80, 40);
            close.TabIndex = 2;
            close.Text = "Закрити";
            close.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1702, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Увійти";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(20, 340);
            label1.Name = "label1";
            label1.Size = new Size(135, 21);
            label1.TabIndex = 26;
            label1.Text = "Введіть пароль:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(20, 264);
            label2.Name = "label2";
            label2.Size = new Size(209, 21);
            label2.TabIndex = 25;
            label2.Text = "Введіть номер телефону:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(20, 364);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(360, 23);
            txtPassword.TabIndex = 24;
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Location = new Point(20, 288);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 23);
            txtPhone.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(20, 420);
            label3.Name = "label3";
            label3.Size = new Size(155, 21);
            label3.TabIndex = 28;
            label3.Text = "Повторіть пароль:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(20, 444);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(360, 23);
            txtConfirmPassword.TabIndex = 27;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 588);
            Controls.Add(label3);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            Text = "Реєстрація";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPassword;
        private Label lblLogin;
        private Button btnRegister;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private Panel panelHeader;
        private Button close;
        private Button btnClose;
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtPhone;
        private Label label3;
        private TextBox txtConfirmPassword;
        private Button button1;
    }
}