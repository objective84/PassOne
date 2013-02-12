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
    public partial class PassOneMainScreen : Form
    {
        private PassOneApp _myApp;
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOne\\";

        public ListBox CredentialsListBox
        {
            get { return CredentialsList; }
        }

        public PassOneMainScreen() { }

        public PassOneMainScreen(User user)
        {
            InitializeComponent();
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

        private void SaveCredentials()
        {
            Credentials creds; 
            try
            {
              creds = new Credentials(websiteTextBox.Text, urlTextBox.Text, usernameTextBox.Text, passwordTextBox.Text,
                                            emailTextBox.Text);
              _myApp.CreateCredentials(creds);
              ClearDetails();
            }
            catch (MissingInformationException e)
            {
                MessageBox.Show(e.Message);
            }
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

        private void newEntry_Click(object sender, EventArgs e)
        {
            CredentialsList.SelectedItem = null;
            ClearDetails();
            SaveBtn.Text = "Save";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveCredentials();
        }

        private void PassOneMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void copyPasswordBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = _myApp.CreateRandomPassword(10);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCredentials();
        }

        private void deleteCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CredentialsList.SelectedItem == null) return;
            _myApp.DeleteEntry();
        }
    }
}
