namespace PassOne
{
    partial class PassOne
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
            this.SplitScreenPanels = new System.Windows.Forms.SplitContainer();
            this.CredentialsList = new System.Windows.Forms.ListBox();
            this.copyPasswordBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.showPasswordBtn = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.websiteLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.websiteTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitScreenPanels)).BeginInit();
            this.SplitScreenPanels.Panel1.SuspendLayout();
            this.SplitScreenPanels.Panel2.SuspendLayout();
            this.SplitScreenPanels.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitScreenPanels
            // 
            this.SplitScreenPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitScreenPanels.Location = new System.Drawing.Point(0, 0);
            this.SplitScreenPanels.Name = "SplitScreenPanels";
            // 
            // SplitScreenPanels.Panel1
            // 
            this.SplitScreenPanels.Panel1.Controls.Add(this.CredentialsList);
            // 
            // SplitScreenPanels.Panel2
            // 
            this.SplitScreenPanels.Panel2.Controls.Add(this.generateButton);
            this.SplitScreenPanels.Panel2.Controls.Add(this.copyPasswordBtn);
            this.SplitScreenPanels.Panel2.Controls.Add(this.SaveBtn);
            this.SplitScreenPanels.Panel2.Controls.Add(this.showPasswordBtn);
            this.SplitScreenPanels.Panel2.Controls.Add(this.emailLabel);
            this.SplitScreenPanels.Panel2.Controls.Add(this.passwordLabel);
            this.SplitScreenPanels.Panel2.Controls.Add(this.usernameLabel);
            this.SplitScreenPanels.Panel2.Controls.Add(this.urlLabel);
            this.SplitScreenPanels.Panel2.Controls.Add(this.websiteLabel);
            this.SplitScreenPanels.Panel2.Controls.Add(this.emailTextBox);
            this.SplitScreenPanels.Panel2.Controls.Add(this.passwordTextBox);
            this.SplitScreenPanels.Panel2.Controls.Add(this.usernameTextBox);
            this.SplitScreenPanels.Panel2.Controls.Add(this.urlTextBox);
            this.SplitScreenPanels.Panel2.Controls.Add(this.websiteTextBox);
            this.SplitScreenPanels.Size = new System.Drawing.Size(496, 287);
            this.SplitScreenPanels.SplitterDistance = 124;
            this.SplitScreenPanels.TabIndex = 0;
            // 
            // CredentialsList
            // 
            this.CredentialsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialsList.FormattingEnabled = true;
            this.CredentialsList.Location = new System.Drawing.Point(0, 0);
            this.CredentialsList.Name = "CredentialsList";
            this.CredentialsList.Size = new System.Drawing.Size(124, 287);
            this.CredentialsList.TabIndex = 0;
            this.CredentialsList.SelectedIndexChanged += new System.EventHandler(this.CredentialsList_SelectedIndexChanged);
            // 
            // copyPasswordBtn
            // 
            this.copyPasswordBtn.Location = new System.Drawing.Point(190, 182);
            this.copyPasswordBtn.Name = "copyPasswordBtn";
            this.copyPasswordBtn.Size = new System.Drawing.Size(91, 23);
            this.copyPasswordBtn.TabIndex = 12;
            this.copyPasswordBtn.Text = "Copy Password";
            this.copyPasswordBtn.UseVisualStyleBackColor = true;
            this.copyPasswordBtn.Click += new System.EventHandler(this.copyPasswordBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(283, 251);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 11;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // showPasswordBtn
            // 
            this.showPasswordBtn.Location = new System.Drawing.Point(93, 182);
            this.showPasswordBtn.Name = "showPasswordBtn";
            this.showPasswordBtn.Size = new System.Drawing.Size(91, 23);
            this.showPasswordBtn.TabIndex = 10;
            this.showPasswordBtn.Text = "Show Password";
            this.showPasswordBtn.UseVisualStyleBackColor = true;
            this.showPasswordBtn.Click += new System.EventHandler(this.showPasswordBtn_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(176, 108);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(73, 13);
            this.emailLabel.TabIndex = 9;
            this.emailLabel.Text = "Email Address";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(90, 159);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(5, 108);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(176, 18);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(29, 13);
            this.urlLabel.TabIndex = 6;
            this.urlLabel.Text = "URL";
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Location = new System.Drawing.Point(7, 15);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(46, 13);
            this.websiteLabel.TabIndex = 5;
            this.websiteLabel.Text = "Website";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(255, 105);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(107, 20);
            this.emailTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(149, 156);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(66, 105);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(93, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(211, 15);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(151, 20);
            this.urlTextBox.TabIndex = 1;
            // 
            // websiteTextBox
            // 
            this.websiteTextBox.Location = new System.Drawing.Point(59, 12);
            this.websiteTextBox.Name = "websiteTextBox";
            this.websiteTextBox.Size = new System.Drawing.Size(100, 20);
            this.websiteTextBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SplitScreenPanels);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 287);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEntryToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newEntryToolStripMenuItem
            // 
            this.newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
            this.newEntryToolStripMenuItem.Size = new System.Drawing.Size(489, 19);
            this.newEntryToolStripMenuItem.Text = "New Credentials";
            this.newEntryToolStripMenuItem.Click += new System.EventHandler(this.newEntryToolStripMenuItem_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(118, 211);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(131, 23);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "Generate Password";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // PassOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 316);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PassOne";
            this.Text = "PassOne";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PassOne_FormClosed);
            this.Load += new System.EventHandler(this.PassOne_Load);
            this.SplitScreenPanels.Panel1.ResumeLayout(false);
            this.SplitScreenPanels.Panel2.ResumeLayout(false);
            this.SplitScreenPanels.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitScreenPanels)).EndInit();
            this.SplitScreenPanels.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitScreenPanels;
        private System.Windows.Forms.ListBox CredentialsList;
        private System.Windows.Forms.Label websiteLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.TextBox websiteTextBox;
        private System.Windows.Forms.Button showPasswordBtn;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button copyPasswordBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newEntryToolStripMenuItem;
        private System.Windows.Forms.Button generateButton;
    }
}

