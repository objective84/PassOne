using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Business;

namespace PassOne.Presentation
{
    class PassOneApp
    {
        private User _myUser;
        private IList<string> _credentialsList;
        private PassOne _app;

        public event EventHandler OnCredentialsListUpdated;

        public PassOneApp(PassOne app)
        {
            OnCredentialsListUpdated += PassOneApp_OnCredentialsListUpdated;
            _credentialsList = new List<string>();
            _myUser = new User();
            _app = app;
        }

        public PassOneApp(PassOne app, User user)
        {
            OnCredentialsListUpdated += PassOneApp_OnCredentialsListUpdated;
            _myUser = user;
            _app = app;
            //Test Code
            //_myUser.CreateUser(new Credentials("Regis WorldClass", "https://worldclass.regis.edu/",
            //                                                 "pvarnerhowland",
            //                                                 "testpass123", "pvarnerhowland@regis.edu"));
            //_myUser.CreateUser(new Credentials("Regis InSite", "https://in2.regis.edu/CookieAuth.dll?GetLogon?curl=Z2F&reason=0&formdir=6",
            //                                                 "pvarnerhowland",
            //                                                 "testpass456", "pvarnerhowland@regis.edu"));
            //Test Code
            BuildCredentialsList(_myUser);
        }

        public void BuildCredentialsList(User user)
        {
            _credentialsList = user.GetCredentialsList();
            foreach (var cred in _credentialsList)
                _app.CredentialsListBox.Items.Add(cred);
        }

        public void CreateCredentials(Credentials creds)
        {
            if (!_credentialsList.Contains(creds.Website))
            {
                OnCredentialsListUpdated(creds.Website, null);
                _myUser.Create(creds);
            }
            else
            {
                creds.Id = (int) _myUser.CredentialsList[creds.Website];
                creds.Update(_myUser);
            }
        }

        public Credentials GetCredentials(string name)
        {
            return _myUser.FindCredentials((int)_myUser.CredentialsList[name]);
        }

        void PassOneApp_OnCredentialsListUpdated(object sender, EventArgs e)
        {
            _app.CredentialsListBox.Items.Add(sender);
        }
    }
}
