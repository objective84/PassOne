using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Domain;
using PassOne.Business;

namespace PassOne.Presentation
{
    public partial class PassOneLoginScreen : Form
    {
        private PassOneMainScreen _form;
        private PassOneRegisterScreen _register;

        public PassOneLoginScreen()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login(usernameTextBox.Text, passwordTextBox.Text);
        }

        public void Login(string username, string password)
        {
            try
            {
                var user = UserManager.Authenticate(username, password, PassOneMainScreen.Path);
                _form = new PassOneMainScreen(user);
                Visible = false;
                _form.Visible = true;
            }
            catch (InvalidLoginException)
            {
                MessageBox.Show("Invalid username or password");
                usernameTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            _register = new PassOneRegisterScreen(this);
            _register.Visible = true;
        }

        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
                Login(usernameTextBox.Text, passwordTextBox.Text);
        }
    }
}
