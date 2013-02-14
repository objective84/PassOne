using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PassOne.Business;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Presentation
{
    public enum ModelStates
    {
        Register,
        Login,
        Main
    }
   public class PassOneController
   {
       public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOne\\";
       private PassOneModel _model;
       public PassOneModel Model
       {
           private get { return _model; }
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

       public PassOneController()
       {
           _userManager = new UserManager();
           _credentialsManager = new CredentialsManager();
           
       }

       public void CredentialsList_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (((ListBox) sender).SelectedItem == null) return;
           Model.SetDetails(_credentialsManager.FindCredentials(Model.User,
                                                                Model.CredentialsList[
                                                                    ((ListBox) sender).SelectedItem.ToString()], Path));
       }

       public void newEntry_Click(object sender, EventArgs e)
       {
           Model.Details.Clear();
       }

       public void showPasswordBtn_Click(object sender, EventArgs e)
        {
            Model.PasswordHidden = !Model.PasswordHidden;
        }

       public void SaveBtn_Click(object sender, EventArgs e)
       {
           SaveCredentials();
       }

       public void deleteCredentials_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Are you sure you want to delete this credentials entry?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
           {
               _credentialsManager.DeleteCredentials(Model.GetDetails(), Model.User, Path);
           }
       }

       public void copyPasswordBtn_Click(object sender, EventArgs e)
       {
           Clipboard.SetText(Model.Details.Password);
       }

       public void generateButton_Click(object sender, EventArgs e)
       {
           Model.Details.Password = CreateRandomPassword(10);
       }

       public void logoutBtn_Click(object sender, EventArgs e)
       {
           Logout();
       }

       public void DeleteEntry()
       {
           
       }

       private void SaveCredentials()
       {
           try
           {
               _credentialsManager.CreateCredentials(Model.User, Model.GetDetails(), Path);
               Model.Details.Clear();
           }
           catch (MissingInformationException e)
           {
               MessageBox.Show(e.Message);
           }
       }

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

       public void RegisterUser(string fn, string ln, string un, string pw, string confirm)
       {
           if (pw != confirm) throw new PasswordDoesNotMatchConfirmationException();
           _userManager.CreateUser(fn, ln, un, pw, Path);
           Login(un, pw);
       }
       
       public void Login(string username, string password)
       {
           try
           {
               Model.User =_userManager.Authenticate(username, password, Path);
               ModelState = ModelStates.Main;
               Model.CredentialsList = _userManager.GetCredentialsList(Model.User, Path);
           }
           catch (InvalidLoginException)
           {
               Model.InvalidLogin();
           }
       }

       public void Logout()
       {
           Model.User = null;
           ModelState = ModelStates.Login;
       }
   }
}
