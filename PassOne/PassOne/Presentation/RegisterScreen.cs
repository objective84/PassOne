using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Business;

namespace PassOne.Presentation
{
    public partial class RegisterScreen : Form
    {
        private LoginScreen _login;
        public RegisterScreen(LoginScreen login)
        {
            InitializeComponent();
            _login = login;
        }

        private void RegisterScreen_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            UserManager.CreateUser(firstNameTextBox.Text, lastNameTextBox.Text, usernameTextBox.Text, passwordTextBox.Text);
            _login.Login(usernameTextBox.Text, passwordTextBox.Text);
            Visible = false;
        }
    }
}
