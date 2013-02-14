using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Business;
using PassOne.Domain;

namespace PassOne.Presentation
{
    public partial class PassOneRegisterScreen : Form
    {
        public PassOneRegisterScreen()
        {
            InitializeComponent();
        }

        public void ConnectEventHandlers(PassOneView view)
        {
            RegisterBtn.Click += view.registerUserBtn_Click;
            cancelBtn.Click += view.cancelUserRegistrationBtn_Click;
        }

        private void PassOneRegisterScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void MissingInformation()
        {
            ClearNotifications();
            informationMissingNotifier.Visible = true;
            if (firstNameTextBox.Text == string.Empty) firstNameMissingNotifier.Visible = true;
            if (lastNameTextBox.Text == string.Empty) lastNameMissingNotifier.Visible = true;
            if (usernameTextBox.Text == string.Empty) usernameMissingNotifier.Visible = true;
            if (passwordTextBox.Text == string.Empty) passwordMissingNotifier.Visible = true;
            if (confirmTextBox.Text == string.Empty) confirmMissingNotifier.Visible = true;
        }

        private void confirmTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordsDoNotMatchLabel.Visible = confirmTextBox.Text != passwordTextBox.Text;
        }

        public void ClearNotifications()
        {
            informationMissingNotifier.Visible = false;
            firstNameMissingNotifier.Visible = false;
            lastNameMissingNotifier.Visible = false;
            usernameMissingNotifier.Visible = false;
            passwordMissingNotifier.Visible = false;
            confirmMissingNotifier.Visible = false;
            passwordsDoNotMatchLabel.Visible = false;
        }
    }
}
