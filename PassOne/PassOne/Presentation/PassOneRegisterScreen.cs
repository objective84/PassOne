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
        private PassOneLoginScreen _login;

        public PassOneRegisterScreen()
        {
        }

        public PassOneRegisterScreen(PassOneLoginScreen login)
        {
            InitializeComponent();
            _login = login;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Register();
            }
            catch (PasswordDoesNotMatchConfirmationException f)
            {
                MessageBox.Show(f.Message);
            }
            catch (MissingInformationException g)
            {
                MessageBox.Show(g.Message);
            }
        }

        private void Register()
        {
            if (passwordTextBox.Text != confirmTextBox.Text) throw new PasswordDoesNotMatchConfirmationException();
            UserManager.CreateUser(PassOneMainScreen.Path, firstNameTextBox.Text, lastNameTextBox.Text, usernameTextBox.Text, passwordTextBox.Text);
            _login.Login(usernameTextBox.Text, passwordTextBox.Text);
            Visible = false;
        }
    }

    
}
