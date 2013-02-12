using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Domain;
using PassOne.Business;

namespace PassOne.Presentation
{
    class PassOneApp
    {
        private User _myUser;
        private IList<string> _credentialsList;
        private PassOneMainScreen _app;

        public PassOneApp(){}

        public PassOneApp(PassOneMainScreen app)
        {
            _credentialsList = new List<string>();
            _myUser = new User();
            _app = app;
        }

        public PassOneApp(PassOneMainScreen app, User user)
        {
            _myUser = user;
            _app = app;
            BuildCredentialsList(_myUser);
        }

        public void BuildCredentialsList(User user)
        {
            _credentialsList = user.GetCredentialsList(PassOneMainScreen.Path);
            foreach (var cred in _credentialsList)
                _app.CredentialsListBox.Items.Add(cred);
        }

        public void CreateCredentials(Credentials creds)
        {
            if (!_credentialsList.Contains(creds.Website))
            {

                _app.CredentialsListBox.Items.Add(creds.Website);
                _myUser.Create(creds, PassOneMainScreen.Path);
            }
            else
            {
                creds.Id = (int) _myUser.CredentialsList[creds.Website];
                creds.Update(_myUser, PassOneMainScreen.Path);
            }
        }

        public Credentials GetCredentials(string name)
        {
            return _myUser.FindCredentials((int)_myUser.CredentialsList[name], PassOneMainScreen.Path);
        }

        public string CreateRandomPassword(int passwordLength)
        {
            string allowedCharsLowerCase = "abcdefghijkmnopqrstuvwxyz";
            string allowedCharsUpperCase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            string allowedNums = "0123456789";
            string allowedSymbols = "!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                var selected = string.Empty;
                switch (rd.Next(1, 6))
                {
                    case 1:
                        selected = allowedCharsLowerCase;
                        break;
                    case 2:
                        selected = allowedCharsUpperCase;
                        break;
                    case 3:
                        selected = allowedNums;
                        break;
                    case 4:
                        selected = allowedSymbols;
                        break;
                    case 5:
                        selected = allowedSymbols;
                        break;
                }
                chars[i] = selected[rd.Next(0, selected.Length)];
            }

            return new string(chars);
        }

        public void DeleteEntry()
        {

            if (MessageBox.Show("Are you sure you want to delete this credentials entry?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                GetCredentials(_app.CredentialsListBox.SelectedItem.ToString()).Delete(_myUser, PassOneMainScreen.Path);
            }
        }
    }
}
