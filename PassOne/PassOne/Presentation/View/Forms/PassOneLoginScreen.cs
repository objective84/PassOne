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
        public PassOneLoginScreen()
        {
            InitializeComponent();
        }

        public void ConnectEventHandlers(PassOneView view)
        {
            registerButton.Click += view.registerBtn_Click;
            loginButton.Click += view.loginButton_Click;
        }

        private void PassOneLoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
