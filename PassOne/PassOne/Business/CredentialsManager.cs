using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public class CredentialsManager : ManagerBase
    {
        //Constructors
        public CredentialsManager()
            : base(Services.CredentialsData)
        {
        }

        public int CreateCredentials(PassOneCredentials creds)
        {
            var credsSvc = GetService(Services.CredentialsData) as IPassOneDataSvc;
            credsSvc.Create(creds);
            return creds.Id;
        }

        /// <summary>
        /// Method for updating the contents of a saved set of credentials
        /// </summary>
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="creds">The credentials to be updated</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void UpdateCredentials(PassOneUser user, PassOneCredentials creds)
        {
            try
            {
                GetService().Edit(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        /// <summary>
        /// Method for retrieving a specific set of credentials
        /// </summary>
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="id">The Id of the credentials to be retrieved</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>The requested credentials, if found; if not, returns null</returns>
        public PassOneCredentials FindCredentials(int id)
        {
            try
            {
                var creds =
                    (GetService(Services.CredentialsData) as IPassOneDataSvc).RetreiveById(id) as PassOneCredentials;
                return creds;
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }
        /// <summary>
        /// Method for deleting a credentials entry
        /// </summary>
        /// <param name="creds">The credentials to be deleted</param>
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void DeleteCredentials(PassOneCredentials creds, PassOneUser user)
        {
            try
            {
                creds.Encrypt(new Encryption(user.K, user.V));
                GetService().Delete(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        public Dictionary<string, int> GetCredentialsList(int userId)
        {
            return ((EntityCredentialsImplementation)GetService()).GetCredentialsList(userId);
        }

    }
}
