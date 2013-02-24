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
        public PassOneMainScreen()
        {
            InitializeComponent();
        }

        private void PassOneMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ConnectEventHandlers(PassOneController controller)
        {
            ShowPasswordBtn.Click += controller.showPasswordBtn_Click;
            CopyPasswordBtn.Click += controller.copyPasswordBtn_Click;
            GenerateButton.Click += controller.generateButton_Click;
            SaveBtn.Click += controller.SaveBtn_Click;
            CredentialsListBox.SelectedIndexChanged += controller.CredentialsList_SelectedIndexChanged;
            newToolStripButton.Click += controller.newEntry_Click;
            newToolStripMenuItem.Click += controller.newEntry_Click;
            saveToolStripButton.Click += controller.SaveBtn_Click;
            saveToolStripMenuItem.Click += controller.SaveBtn_Click;
            deleteCredentialsToolStripMenuItem.Click += controller.deleteCredentials_Click;
            logOutToolStripMenuItem.Click += controller.logoutBtn_Click;
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
