using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using PassOne.Business;
using PassOne.Domain;
using PassOne.Presentation;

namespace PassOne
{
    public partial class PassOne : Form
    {
        private PassOneApp _myApp;

        public ListBox CredentialsListBox
        {
            get { return CredentialsList; }
        }

        public PassOne(User user)
        {
            InitializeComponent();
            //UserManager.CreateUser("Peter", "Varner-Howland", "pvarnerhowland", "testPass321");
            //var user = UserManager.Authenticate("pvarnerhowland", "testPass321");
            _myApp = new PassOneApp(this, user);
        }

        private void ShowHidePassword()
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
            showPasswordBtn.Text = passwordTextBox.UseSystemPasswordChar ? "Show Password" : "Hide Password";
        }

        private void ClearDetails()
        {
            websiteTextBox.Text = string.Empty;
            urlTextBox.Text = string.Empty;
            usernameTextBox.Text = string.Empty;
            if (!passwordTextBox.UseSystemPasswordChar) ShowHidePassword();
            passwordTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
        }

        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void showPasswordBtn_Click(object sender, EventArgs e)
        {
            ShowHidePassword();
        }

        private void CredentialsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox) sender).SelectedItem == null) return;
            var creds = _myApp.GetCredentials(((ListBox)sender).SelectedItem.ToString());
            websiteTextBox.Text = creds.Website;
            urlTextBox.Text = creds.Url;
            usernameTextBox.Text = creds.Username;
            if(!passwordTextBox.UseSystemPasswordChar)ShowHidePassword();
            passwordTextBox.Text = creds.Password;
            emailTextBox.Text = creds.EmailAddress;
            SaveBtn.Text = "Update";
        }

        private void PassOne_Load(object sender, EventArgs e)
        {

        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialsList.SelectedItem = null;
            ClearDetails();
            SaveBtn.Text = "Save";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var creds = new Credentials(websiteTextBox.Text, urlTextBox.Text, usernameTextBox.Text, passwordTextBox.Text,
                                        emailTextBox.Text);
            _myApp.CreateCredentials(creds);
            ClearDetails();
        }

        private void PassOne_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void copyPasswordBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = CreateRandomPassword(12);
        }

    }
}
