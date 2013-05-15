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

       private PassOneUser _user;
       public PassOneUser User { get; set; }
       private PassOneView _view;
       private Dictionary<string, int> _credentialsList;
       private bool _passwordHidden;

       /// <summary>
       /// User's list of credentials, updates the listbox when set.
       /// </summary>
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

       /// <summary>
       /// Instance of the View object, can only be set once
       /// </summary>
       public PassOneView View
       {
           get { return _view; }
           set
           {
               if (_view == null)
               {
                   _view = value;
               }

           }
       }

       /// <summary>
       /// Value which indicates whether the user's password is hidden or displayed, when set updates the view accordingly
       /// </summary>
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

       //Constructors
       public PassOneModel(){}

       public PassOneModel(PassOneUser user)
       {
           _user = user;
           CredentialsList = new Dictionary<string, int>();
           Details = new Details(OnDetailsChanged);
       }

       public PassOneModel(PassOneUser user, Dictionary<string, int> dictionary)
       {
           _user = user;
           CredentialsList = dictionary;
           Details = new Details(OnDetailsChanged);
       }

       /// <summary>
       /// Method to handle changing the current state
       /// </summary>
       /// <param name="state">The state to set to</param>
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

       /// <summary>
       /// Method to make the login form visible. Resets all values on the login form to their defaults
       /// </summary>
       public void SetLoginFormVisible()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = true;
       }

       /// <summary>
       /// Method to make the register form visible. Resets all values on the register form to their defaults
       /// </summary>
       public void SetRegisterFormVisible()
       {
           View.RegisterForm.ClearNotifications();
           View.LoginForm.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = true;
       }

       /// <summary>
       /// Method to make the main screen visible
       /// </summary>
       public void SetMainFormVisible()
       {
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = false;
           View.MainForm.Visible = true;
       }

       /// <summary>
       /// Method to update the view to reflect the user's credentials list when it is updated
       /// </summary>
       public void UpdateViewListBox()
       {
           var tempList = View.MainForm.CredentialsListBox.Items.Cast<string>().ToList();

           foreach (var key in _credentialsList.Keys.Where(key => !tempList.Contains(key)))
               AddItemToCredentialsListBox(key);
           foreach (var item in tempList.Where(item => !_credentialsList.ContainsKey(item)))
               RemoveItemFromCredentialsListBox(item);
       }

       /// <summary>
       /// Event handler for when any of the details object's properties are changed. Updates the view to match the new property
       /// </summary>
       /// <param name="sender">The property which has been changed</param>
       /// <param name="e">PropertyChangedEventArgs which contains the string representation of which property was changed</param>
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

       /// <summary>
       /// Method to add a new entry to the view's credentials listbox
       /// </summary>
       /// <param name="item">The credentials title to be added</param>
       public void AddItemToCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Add(item);
       }

       /// <summary>
       /// Method to remove a credentials entry from the view's list box
       /// </summary>
       /// <param name="item">The credentials title to be removed</param>
       public void RemoveItemFromCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Remove(item);
       }

       /// <summary>
       /// Returns the current state of the Details object as a Credentials object
       /// </summary>
       /// <returns>Credentials representation of Details</returns>
       public PassOneCredentials GetDetails()
       {
           return new PassOneCredentials(View.MainForm.WebsiteTextBox.Text, View.MainForm.UrlTextBox.Text,
                                  View.MainForm.UsernameTextBox.Text, View.MainForm.PasswordTextBox.Text,
                                  View.MainForm.EmailTextBox.Text);
       }

       /// <summary>
       /// Method to set the current details object with new Credential's information
       /// </summary>
       /// <param name="creds">The credentials to be placed into details</param>
       public void SetDetails(PassOneCredentials creds)
       {
           Details = new Details(OnDetailsChanged);
           Details.Title = creds.Website;
           Details.Url = creds.Url;
           Details.Username = creds.Username;
           Details.Password = creds.Password;
           Details.Email = creds.EmailAddress;
       }

       /// <summary>
       /// Method to clear the view's details textboxes
       /// </summary>
       public void ClearMainFormDetails()
       {
           View.MainForm.WebsiteTextBox.Clear();
           View.MainForm.UrlTextBox.Clear();
           View.MainForm.UsernameTextBox.Clear();
           View.MainForm.PasswordTextBox.Clear();
           View.MainForm.EmailTextBox.Clear();
           if (!PasswordHidden) PasswordHidden = !PasswordHidden;
       }

       /// <summary>
       /// Method update the view when the user enters an invalid username and/or password
       /// </summary>
       public void InvalidLogin()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = true;
       }
   }

   public class PassOneModel_
   {

       private PassOneUser _user;
       public PassOneUser User { get; set; }
       private PassOneView _view;
       private Dictionary<string, int> _credentialsList;
       private bool _passwordHidden;

       /// <summary>
       /// User's list of credentials, updates the listbox when set.
       /// </summary>
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

       /// <summary>
       /// Instance of the View object, can only be set once
       /// </summary>
       public PassOneView View
       {
           get { return _view; }
           set
           {
               if (_view == null)
               {
                   _view = value;
               }

           }
       }

       /// <summary>
       /// Value which indicates whether the user's password is hidden or displayed, when set updates the view accordingly
       /// </summary>
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

       //Constructors
       public PassOneModel_() { }

       public PassOneModel_(PassOneUser user)
       {
           _user = user;
           CredentialsList = new Dictionary<string, int>();
           Details = new Details(OnDetailsChanged);
       }

       public PassOneModel_(PassOneUser user, Dictionary<string, int> dictionary)
       {
           _user = user;
           CredentialsList = dictionary;
           Details = new Details(OnDetailsChanged);
       }

       /// <summary>
       /// Method to handle changing the current state
       /// </summary>
       /// <param name="state">The state to set to</param>
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

       /// <summary>
       /// Method to make the login form visible. Resets all values on the login form to their defaults
       /// </summary>
       public void SetLoginFormVisible()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = true;
       }

       /// <summary>
       /// Method to make the register form visible. Resets all values on the register form to their defaults
       /// </summary>
       public void SetRegisterFormVisible()
       {
           View.RegisterForm.ClearNotifications();
           View.LoginForm.Visible = false;
           View.MainForm.Visible = false;
           View.RegisterForm.Visible = true;
       }

       /// <summary>
       /// Method to make the main screen visible
       /// </summary>
       public void SetMainFormVisible()
       {
           View.RegisterForm.Visible = false;
           View.LoginForm.Visible = false;
           View.MainForm.Visible = true;
       }

       /// <summary>
       /// Method to update the view to reflect the user's credentials list when it is updated
       /// </summary>
       public void UpdateViewListBox()
       {
           var tempList = View.MainForm.CredentialsListBox.Items.Cast<string>().ToList();

           foreach (var key in _credentialsList.Keys.Where(key => !tempList.Contains(key)))
               AddItemToCredentialsListBox(key);
           foreach (var item in tempList.Where(item => !_credentialsList.ContainsKey(item)))
               RemoveItemFromCredentialsListBox(item);
       }

       /// <summary>
       /// Event handler for when any of the details object's properties are changed. Updates the view to match the new property
       /// </summary>
       /// <param name="sender">The property which has been changed</param>
       /// <param name="e">PropertyChangedEventArgs which contains the string representation of which property was changed</param>
       private void OnDetailsChanged(object sender, PropertyChangedEventArgs e)
       {
           switch (e.PropertyName)
           {
               case "Title":
                   View.MainForm.WebsiteTextBox.Text = ((Details)sender).Title;
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

       /// <summary>
       /// Method to add a new entry to the view's credentials listbox
       /// </summary>
       /// <param name="item">The credentials title to be added</param>
       private void AddItemToCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Add(item);
       }

       /// <summary>
       /// Method to remove a credentials entry from the view's list box
       /// </summary>
       /// <param name="item">The credentials title to be removed</param>
       private void RemoveItemFromCredentialsListBox(string item)
       {
           View.MainForm.CredentialsListBox.Items.Remove(item);
       }

       /// <summary>
       /// Returns the current state of the Details object as a Credentials object
       /// </summary>
       /// <returns>Credentials representation of Details</returns>
       public PassOneCredentials GetDetails()
       {
           return new PassOneCredentials(View.MainForm.WebsiteTextBox.Text, View.MainForm.UrlTextBox.Text,
                                  View.MainForm.UsernameTextBox.Text, View.MainForm.PasswordTextBox.Text,
                                  View.MainForm.EmailTextBox.Text);
       }

       /// <summary>
       /// Method to set the current details object with new Credential's information
       /// </summary>
       /// <param name="creds">The credentials to be placed into details</param>
       public void SetDetails(PassOneCredentials creds)
       {
           Details = new Details(OnDetailsChanged);
           Details.Title = creds.Website;
           Details.Url = creds.Url;
           Details.Username = creds.Username;
           Details.Password = creds.Password;
           Details.Email = creds.EmailAddress;
       }

       /// <summary>
       /// Method to clear the view's details textboxes
       /// </summary>
       public void ClearMainFormDetails()
       {
           View.MainForm.WebsiteTextBox.Clear();
           View.MainForm.UrlTextBox.Clear();
           View.MainForm.UsernameTextBox.Clear();
           View.MainForm.PasswordTextBox.Clear();
           View.MainForm.EmailTextBox.Clear();
           if (!PasswordHidden) PasswordHidden = !PasswordHidden;
       }

       /// <summary>
       /// Method update the view when the user enters an invalid username and/or password
       /// </summary>
       public void InvalidLogin()
       {
           View.LoginForm.UsernameTextBox.Clear();
           View.LoginForm.PasswordTextBox.Clear();
           View.LoginForm.InvalidLoginNotification.Visible = true;
       }
   }
}
