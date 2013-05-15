using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Business;
using PassOne.Domain;
using PassOne.Domain.Exceptions;
using PassOne.Service;

namespace PassOne.Presentation
{
    /// <summary>
    /// Enum for the three states the app can be in: Login, Register, MainScreen
    /// </summary>
    public enum ModelStates
    {
        Register,
        Login,
        Main
    }
   public class PassOneController
   {
       private PassOneModel _model;
       public PassOneModel Model
       {
           get { return _model; }
           set
           {
               if (_model == null)
                   _model = value;
           }
       }

       private readonly UserManager _userManager;
       private readonly CredentialsManager _credentialsManager;

       private ModelStates _modelState;
       public ModelStates ModelState
       {
           get { return _modelState; }
           set
           {
               _modelState = value;
               Model.ModelStateChanged(_modelState);
           }
       }


       //Constructors
       public PassOneController()
       {
           _userManager = new UserManager();
           _credentialsManager = new CredentialsManager();
           
       }

       /// <summary>
       /// Event handler for when the user selects a new credentials entry from the list
       /// </summary>
       /// <param name="sender">The credentials listbox</param>
       /// <param name="e">Not used</param>
       public void CredentialsList_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (((ListBox) sender).SelectedItem == null) return;
           Model.SetDetails(
               _credentialsManager.FindCredentials(Model.CredentialsList[((ListBox) sender).SelectedItem.ToString()]));
       }

       /// <summary>
       /// Event handler for when the user clicks the New Entry toolbar icon or menu item.
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void newEntry_Click(object sender, EventArgs e)
       {
           Model.Details.Clear();
       }

       /// <summary>
       /// Event handler for when the user clicks the Show Password button
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void showPasswordBtn_Click(object sender, EventArgs e)
        {
            Model.PasswordHidden = !Model.PasswordHidden;
        }

       /// <summary>
       /// Event handler for when the user clicks the Save button or menu item
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void SaveBtn_Click(object sender, EventArgs e)
       {
           SaveCredentials();
       }

       /// <summary>
       /// Event handler for when the user clicks the Delete Credentials menu item or toolbar icon
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void deleteCredentials_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Are you sure you want to delete this credentials entry?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
           {
               var creds = Model.GetDetails();
               creds.UserId = Model.User.Id;
               Model.RemoveItemFromCredentialsListBox(creds.Website);
               creds.Id = Model.CredentialsList[creds.Website];
               Model.CredentialsList.Remove(creds.Website);
               _credentialsManager.DeleteCredentials(creds, Model.User);
               Model.Details.Clear();
           }
       }

       /// <summary>
       /// Event handler for when the user clicks the Copy Password button
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void copyPasswordBtn_Click(object sender, EventArgs e)
       {
           Clipboard.SetText(Model.Details.Password);
       }

       /// <summary>
       /// Event handler for when the user clicks the Generate Password button
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void generateButton_Click(object sender, EventArgs e)
       {
           Model.Details.Password = CreateRandomPassword(10);
       }

       /// <summary>
       /// Event handler for when the user clicks the Logout menu item
       /// </summary>
       /// <param name="sender">The GUI element clicked</param>
       /// <param name="e">Not used</param>
       public void logoutBtn_Click(object sender, EventArgs e)
       {
           Logout();
       }

       /// <summary>
       /// Method to delete the currently selected Credentials entry
       /// </summary>
       public void DeleteEntry()
       {
           
       }

       /// <summary>
       /// Method to save the credentials currently displayed in the details section
       /// </summary>
       private void SaveCredentials()
       {
           try
           {
               var website = Model.GetDetails().Website;
               var creds = Model.GetDetails();
               creds.UserId = Model.User.Id;
               creds.Encrypt(new Encryption(Model.User.K, Model.User.V));
               var id = _credentialsManager.CreateCredentials(creds);
               Model.CredentialsList.Add(website, id);
               Model.UpdateViewListBox();
               Model.Details.Clear();
               MessageBox.Show("Credentials Saved");
           }
           catch (MissingInformationException e)
           {
               MessageBox.Show(e.Message);
           }
           catch (NullReferenceException e)
           {
           }
           //catch (ArgumentException)
           //{
           //    Model.CredentialsList.Remove(Model.GetDetails().Website);
           //}
       }

       /// <summary>
       /// Method to create a randomly generated secure password
       /// </summary>
       /// <param name="passwordLength">How long the password should be</param>
       /// <returns>A password of the given length</returns>
       private string CreateRandomPassword(int passwordLength)
       {
           const string allowedCharsLowerCase = "abcdefghijkmnopqrstuvwxyz";
           const string allowedCharsUpperCase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
           const string allowedNums = "0123456789";
           const string allowedSymbols = "!@$?_-";
           var chars = new char[passwordLength];
           var rd = new Random();

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

       /// <summary>
       /// Method to register a new user
       /// </summary>
       /// <param name="fn">The user's first name</param>
       /// <param name="ln">The user's last name</param>
       /// <param name="un">The user's chosen username</param>
       /// <param name="pw">The user's chosen password</param>
       /// <param name="confirm">The user's password confirmation field</param>
       public void RegisterUser(string fn, string ln, string un, string pw, string confirm)
       {
           if (pw != confirm) throw new PasswordDoesNotMatchConfirmationException();
           _userManager.CreateUser(fn, ln, un, pw);
           Login(un, pw);
       }
       
       /// <summary>
       /// Method to log the user into their account
       /// </summary>
       /// <param name="username">The username provided by the user</param>
       /// <param name="password">The password provided by the user</param>
       public void Login(string username, string password)
       {
           try
           {
               Model.User = _userManager.Authenticate(username, password);
               ModelState = ModelStates.Main;
               Model.CredentialsList = _credentialsManager.GetCredentialsList(Model.User.Id);
           }
           catch (InvalidLoginException)
           {
               Model.InvalidLogin();
           }
       }

       /// <summary>
       /// Method to log the user out of their account
       /// </summary>
       public void Logout()
       {
           Model.User = null;
           ModelState = ModelStates.Login;
       }
   }
}
