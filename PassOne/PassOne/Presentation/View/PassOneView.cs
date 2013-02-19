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
        /// <summary>
        /// Controller isntance, can only be set once.
        /// </summary>
        public PassOneController Controller
        {
            get { return _controller; }
            set
            {
                if (_controller == null)
                {
                    _controller = value;
                }
            }
        }

        //Constructors
        public PassOneView()
        {
            LoginForm = new PassOneLoginScreen();
            RegisterForm = new PassOneRegisterScreen();
            MainForm = new PassOneMainScreen();
        }

        /// <summary>
        /// Attaches the controller's event handlers to the view's GUI elements
        /// </summary>
        /// <param name="controller">An instance of the controller which will contain the event handlers</param>
        public void ConnectEventHandlers(PassOneController controller)
        {
            MainForm.ConnectEventHandlers(controller);
            RegisterForm.ConnectEventHandlers(this);
            LoginForm.ConnectEventHandlers(this);
        }

        /// <summary>
        /// Event handler for when the user presses the Enter key while on the password textbox in the login form
        /// </summary>
        /// <param name="sender">The GUI element currently selected</param>
        /// <param name="e">Not used</param>
        public void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Controller.Login(LoginForm.UsernameTextBox.Text, LoginForm.PasswordTextBox.Text);
        }

        /// <summary>
        /// Event handler for when the user clicks the Login button on the login form
        /// </summary>
        /// <param name="sender">The GUI element clicked</param>
        /// <param name="e">Not used</param>
        public void loginButton_Click(object sender, EventArgs e)
        {
            Controller.Login(LoginForm.UsernameTextBox.Text, LoginForm.PasswordTextBox.Text);
        }

        /// <summary>
        /// Event handler for when the user clicks the Register button on the login form
        /// </summary>
        /// <param name="sender">The GUI element clicked</param>
        /// <param name="e">Not used</param>
        public void registerBtn_Click(object sender, EventArgs e)
        {
            Controller.ModelState = ModelStates.Register;
        }

        /// <summary>
        /// Event handler for when the user clicks the Register button to complete registration of a new user account on the Register form
        /// </summary>
        /// <param name="sender">The GUI element clicked</param>
        /// <param name="e">Not used</param>
        public void registerUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.RegisterUser(RegisterForm.FirstNameTextBox.Text, RegisterForm.LastNameTextBox.Text,
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

        /// <summary>
        /// Event handler for when the user clicks the Cancel button on the register form
        /// </summary>
        /// <param name="sender">The GUI element clicked</param>
        /// <param name="e">Not used</param>
        public void cancelUserRegistrationBtn_Click(object sender, EventArgs e)
        {
            Controller.ModelState = ModelStates.Login;
        }
    }
}
