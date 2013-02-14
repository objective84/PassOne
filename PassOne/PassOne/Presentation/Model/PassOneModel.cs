using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Presentation
{

   public class PassOneModel
   {

       private User _user;
       public User User { get; set; }
       private PassOneView _view;
       private Dictionary<string, int> _credentialsList;
       private bool _passwordHidden;

       public Dictionary<string, int> CredentialsList
       {
           get { return _credentialsList; }
           set
           {
               _credentialsList = value;
               UpdateViewListBox();
           }
       }

       public Details Details { get; set; }

       public PassOneView View
       {
           private get { return _view; }
           set
           {
               if (_view == null)
               {
                   _view = value;
               }

           }
       }

       public bool PasswordHidden
       {
           get { return _passwordHidden; }
           set
           {
               _passwordHidden = value;
               View.MainForm.PasswordTextBox.UseSystemPasswordChar = _passwordHidden;
               View.MainForm.ShowPasswordBtn.Text = _passwordHidden ? "Show Password" : "Hide Password";
           }
       }

       public PassOneModel(){}

       public PassOneModel(User user)
       {
           _user = user;
           CredentialsList = new Dictionary<string, int>();
           Details = new Details(OnDetailsChanged);
       }

       public PassOneModel(User user, Dictionary<string, int> dictionary)
       {
           _user = user;
           CredentialsList = dictionary;
           Details = new Details(OnDetailsChanged);
       }

       public void ModelStateChanged(ModelStates state)
       {
           switch (state)
           {
               case ModelStates.Login:
                   SetLoginFormVisible();
                   break;
               case ModelStates.Register:
                   SetRegisterFormVisible();
                   break;
               case ModelStates.Main:
                   SetMainFormVisible();
                   break;
           }
       }
       public void SetLoginFormVisible()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = true;
       }

       public void SetRegisterFormVisible()
       {
           View.RegisterForm.ClearNotifications();
           View.LoginForm.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = true;
       }

       public void SetMainFormVisible()
       {
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = false;
           View.MainForm.Visible = true;
       }

       public void UpdateViewListBox()
       {
           var tempList = View.MainForm.CredentialsListBox.Items.Cast<string>().ToList();

           foreach (var key in _credentialsList.Keys.Where(key => !tempList.Contains(key)))
               AddItemToCredentialsListBox(key);
           foreach (var item in tempList.Where(item => !_credentialsList.ContainsKey(item)))
               RemoveItemFromCredentialsListBox(item);
       }

       private void OnDetailsChanged(object sender, PropertyChangedEventArgs e)
       {
           switch (e.PropertyName)
           {
               case "Title":
                   View.MainForm.WebsiteTextBox.Text = ((Details) sender).Title;
                   break;
               case "URL":
                   View.MainForm.UrlTextBox.Text = ((Details)sender).Url;
                   break;
               case "Username":
                   View.MainForm.UsernameTextBox.Text = ((Details)sender).Username;
                   break;
               case "Password":
                   View.MainForm.PasswordTextBox.Text = ((Details)sender).Password;
                   break;
               case "Email":
                   View.MainForm.EmailTextBox.Text = ((Details)sender).Email;
                   break;
           }
       }

       private void AddItemToCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Add(item);
       }

       private void RemoveItemFromCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Remove(item);
       }

       public Credentials GetDetails()
       {
           return new Credentials(View.MainForm.WebsiteTextBox.Text, View.MainForm.UrlTextBox.Text,
                                  View.MainForm.UsernameTextBox.Text, View.MainForm.PasswordTextBox.Text,
                                  View.MainForm.EmailTextBox.Text);
       }

       public void SetDetails(Credentials creds)
       {
           Details = new Details(OnDetailsChanged);
           Details.Title = creds.Website;
           Details.Url = creds.Url;
           Details.Username = creds.Username;
           Details.Password = creds.Password;
           Details.Email = creds.EmailAddress;
       }

       public void ClearMainFormDetails()
       {
           View.MainForm.WebsiteTextBox.Clear();
           View.MainForm.UrlTextBox.Clear();
           View.MainForm.UsernameTextBox.Clear();
           View.MainForm.PasswordTextBox.Clear();
           View.MainForm.EmailTextBox.Clear();
           if (!PasswordHidden) PasswordHidden = !PasswordHidden;
       }

       public void InvalidLogin()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = true;
       }
   }
}
