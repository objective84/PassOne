using System.Windows.Forms;

namespace PassOne.Presentation
{
    partial class PassOneRegisterScreen
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmTextBox = new System.Windows.Forms.TextBox();
            this.informationMissingNotifier = new System.Windows.Forms.Label();
            this.firstNameMissingNotifier = new System.Windows.Forms.Label();
            this.lastNameMissingNotifier = new System.Windows.Forms.Label();
            this.usernameMissingNotifier = new System.Windows.Forms.Label();
            this.passwordMissingNotifier = new System.Windows.Forms.Label();
            this.confirmMissingNotifier = new System.Windows.Forms.Label();
            this.passwordsDoNotMatchLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(197, 227);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(115, 26);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(115, 63);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(115, 105);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(115, 143);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Confirm Password";
            // 
            // confirmTextBox
            // 
            this.confirmTextBox.Location = new System.Drawing.Point(115, 178);
            this.confirmTextBox.Name = "confirmTextBox";
            this.confirmTextBox.Size = new System.Drawing.Size(100, 20);
            this.confirmTextBox.TabIndex = 5;
            this.confirmTextBox.UseSystemPasswordChar = true;
            this.confirmTextBox.TextChanged += new System.EventHandler(this.confirmTextBox_TextChanged);
            // 
            // informationMissingNotifier
            // 
            this.informationMissingNotifier.AutoSize = true;
            this.informationMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.informationMissingNotifier.Location = new System.Drawing.Point(34, 6);
            this.informationMissingNotifier.Name = "informationMissingNotifier";
            this.informationMissingNotifier.Size = new System.Drawing.Size(236, 13);
            this.informationMissingNotifier.TabIndex = 11;
            this.informationMissingNotifier.Text = "*Please provide the missing information indicated";
            this.informationMissingNotifier.Visible = false;
            // 
            // firstNameMissingNotifier
            // 
            this.firstNameMissingNotifier.AutoSize = true;
            this.firstNameMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.firstNameMissingNotifier.Location = new System.Drawing.Point(221, 29);
            this.firstNameMissingNotifier.Name = "firstNameMissingNotifier";
            this.firstNameMissingNotifier.Size = new System.Drawing.Size(11, 13);
            this.firstNameMissingNotifier.TabIndex = 12;
            this.firstNameMissingNotifier.Text = "*";
            this.firstNameMissingNotifier.Visible = false;
            // 
            // lastNameMissingNotifier
            // 
            this.lastNameMissingNotifier.AutoSize = true;
            this.lastNameMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.lastNameMissingNotifier.Location = new System.Drawing.Point(221, 66);
            this.lastNameMissingNotifier.Name = "lastNameMissingNotifier";
            this.lastNameMissingNotifier.Size = new System.Drawing.Size(11, 13);
            this.lastNameMissingNotifier.TabIndex = 13;
            this.lastNameMissingNotifier.Text = "*";
            this.lastNameMissingNotifier.Visible = false;
            // 
            // usernameMissingNotifier
            // 
            this.usernameMissingNotifier.AutoSize = true;
            this.usernameMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.usernameMissingNotifier.Location = new System.Drawing.Point(221, 108);
            this.usernameMissingNotifier.Name = "usernameMissingNotifier";
            this.usernameMissingNotifier.Size = new System.Drawing.Size(11, 13);
            this.usernameMissingNotifier.TabIndex = 14;
            this.usernameMissingNotifier.Text = "*";
            this.usernameMissingNotifier.Visible = false;
            // 
            // passwordMissingNotifier
            // 
            this.passwordMissingNotifier.AutoSize = true;
            this.passwordMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.passwordMissingNotifier.Location = new System.Drawing.Point(221, 146);
            this.passwordMissingNotifier.Name = "passwordMissingNotifier";
            this.passwordMissingNotifier.Size = new System.Drawing.Size(11, 13);
            this.passwordMissingNotifier.TabIndex = 15;
            this.passwordMissingNotifier.Text = "*";
            this.passwordMissingNotifier.Visible = false;
            // 
            // confirmMissingNotifier
            // 
            this.confirmMissingNotifier.AutoSize = true;
            this.confirmMissingNotifier.ForeColor = System.Drawing.Color.Red;
            this.confirmMissingNotifier.Location = new System.Drawing.Point(221, 181);
            this.confirmMissingNotifier.Name = "confirmMissingNotifier";
            this.confirmMissingNotifier.Size = new System.Drawing.Size(11, 13);
            this.confirmMissingNotifier.TabIndex = 16;
            this.confirmMissingNotifier.Text = "*";
            this.confirmMissingNotifier.Visible = false;
            // 
            // passwordsDoNotMatchLabel
            // 
            this.passwordsDoNotMatchLabel.AutoSize = true;
            this.passwordsDoNotMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordsDoNotMatchLabel.Location = new System.Drawing.Point(99, 201);
            this.passwordsDoNotMatchLabel.Name = "passwordsDoNotMatchLabel";
            this.passwordsDoNotMatchLabel.Size = new System.Drawing.Size(127, 13);
            this.passwordsDoNotMatchLabel.TabIndex = 17;
            this.passwordsDoNotMatchLabel.Text = "*Passwords do not match";
            this.passwordsDoNotMatchLabel.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(12, 227);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // PassOneRegisterScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.passwordsDoNotMatchLabel);
            this.Controls.Add(this.confirmMissingNotifier);
            this.Controls.Add(this.passwordMissingNotifier);
            this.Controls.Add(this.usernameMissingNotifier);
            this.Controls.Add(this.lastNameMissingNotifier);
            this.Controls.Add(this.firstNameMissingNotifier);
            this.Controls.Add(this.informationMissingNotifier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.confirmTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.registerBtn);
            this.Name = "PassOneRegisterScreen";
            this.Text = "Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PassOneRegisterScreen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox confirmTextBox;

        public System.Windows.Forms.Button RegisterBtn
        {
            get { return registerBtn; }
            set { throw new System.NotImplementedException(); }
        }

        public System.Windows.Forms.TextBox FirstNameTextBox
        {
            get { return firstNameTextBox; }
            set { firstNameTextBox = value; }
        }

        public System.Windows.Forms.TextBox LastNameTextBox
        {
            get { return lastNameTextBox; }
            set { lastNameTextBox = value; }
        }

        public System.Windows.Forms.TextBox UsernameTextBox
        {
            get { return usernameTextBox; }
            set { usernameTextBox = value; }
        }

        public System.Windows.Forms.TextBox PasswordTextBox
        {
            get { return passwordTextBox; }
            set { passwordTextBox = value; }
        }

        public System.Windows.Forms.TextBox ConfirmTextBox
        {
            get { return confirmTextBox; }
            set { confirmTextBox = value; }
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Label informationMissingNotifier;
        private Label firstNameMissingNotifier;
        private Label lastNameMissingNotifier;
        private Label usernameMissingNotifier;
        private Label passwordMissingNotifier;
        private Label confirmMissingNotifier;
        private Label passwordsDoNotMatchLabel;
        private Button cancelBtn;
    }
}