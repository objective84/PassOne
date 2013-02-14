using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Domain;

namespace PassOne.Presentation
{
    public enum GuiElements
    {

    }

    public class PassOneView
    {
        public PassOneLoginScreen LoginForm { get; private set; }
        public PassOneRegisterScreen RegisterForm { get; private set; }
        public PassOneMainScreen MainForm { get; private set; }

        private PassOneController _controller;

        public PassOneController PassOneController
        {
            private get { return _controller; }
            set
            {
                if (_controller == null)
                {
                    _controller = value;
                }
            }
        }

        public PassOneView()
        {
            LoginForm = new PassOneLoginScreen();
            RegisterForm = new PassOneRegisterScreen();
            MainForm = new PassOneMainScreen();
        }

        public void ConnectEventHandlers(PassOneController controller)
        {
            MainForm.ConnectEventHandlers(controller);
            RegisterForm.ConnectEventHandlers(this);
            LoginForm.ConnectEventHandlers(this);
        }

        public void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                PassOneController.Login(LoginForm.UsernameTextBox.Text, LoginForm.PasswordTextBox.Text);
        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            PassOneController.Login(LoginForm.UsernameTextBox.Text, LoginForm.PasswordTextBox.Text);
        }

        public void registerBtn_Click(object sender, EventArgs e)
        {
            PassOneController.ModelState = ModelStates.Register;
        }

        public void registerUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PassOneController.RegisterUser(RegisterForm.FirstNameTextBox.Text, RegisterForm.LastNameTextBox.Text,
                                        RegisterForm.UsernameTextBox.Text, RegisterForm.PasswordTextBox.Text, RegisterForm.ConfirmTextBox.Text);
            }
            catch (PasswordDoesNotMatchConfirmationException)
            {
            }
            catch (MissingInformationException)
            {
                RegisterForm.MissingInformation();
            }
        }

        public void cancelUserRegistrationBtn_Click(object sender, EventArgs e)
        {
            PassOneController.ModelState = ModelStates.Login;
        }
    }
}
