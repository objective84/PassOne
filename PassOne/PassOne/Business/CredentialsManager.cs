using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public static class CredentialsManager
    {
        public static void Create(this User user, Credentials creds)
        {
            var credsSvc = GetCredentialsSvc(user);
            ISerializeSvc temp = new UserSoapSerializer();
            creds.Id = credsSvc.GetNextIdValue();
            if (!user.CredentialsList.ContainsKey(creds.Website))
                user.CredentialsList.Add(creds.Website, creds.Id);
            credsSvc.UpdateTable(creds);
            user.UpdateUser();
        }

        public static void Update(this Credentials creds, User user)
        {
            try
            {
                GetCredentialsSvc(user).UpdateTable(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        public static Credentials FindCredentials(this User user, int id)
        {
            try
            {
                var creds = GetCredentialsSvc(user).RetreiveById(id) as Credentials;
                return creds;
            }
            catch (CryptographicException)
            {
               throw new EncryptionException();
            }
        }

        public static void Delete(this Credentials creds, User user)
        {
            try
            {
                GetCredentialsSvc(user).DeleteValue(creds);
                user.CredentialsList.Remove(creds.Id);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        private static ISerializeSvc GetCredentialsSvc(User user)
        {
            var factory = new SoapFactory();
            return factory.GetService(Services.CredentialsSoapSerializer, user) as ISerializeSvc;
        }
    }
}
