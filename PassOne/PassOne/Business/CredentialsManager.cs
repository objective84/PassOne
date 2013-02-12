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
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOne\\";

        public static void Create(this User user, Credentials creds, string path)
        {
            var credsSvc = GetCredentialsSvc(user, path);
            creds.Id = credsSvc.GetNextIdValue();
            if (!user.CredentialsList.ContainsKey(creds.Website))
                user.CredentialsList.Add(creds.Website, creds.Id);
            credsSvc.UpdateTable(creds);
            user.UpdateUser(path);
        }

        public static void Update(this Credentials creds, User user, string path)
        {
            try
            {
                GetCredentialsSvc(user, path).UpdateTable(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        public static Credentials FindCredentials(this User user, int id, string path)
        {
            try
            {
                var creds = GetCredentialsSvc(user, path).RetreiveById(id) as Credentials;
                return creds;
            }
            catch (CryptographicException)
            {
               throw new EncryptionException();
            }
        }

        public static void Delete(this Credentials creds, User user, string path)
        {
            try
            {
                GetCredentialsSvc(user, path).DeleteValue(creds);
                user.CredentialsList.Remove(creds.Id);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        private static ISerializeSvc GetCredentialsSvc(User user, string path)
        {
            var factory = new SoapFactory();
            return factory.GetService(Services.CredentialsSoapSerializer, path, user) as ISerializeSvc;
        }
    }
}
