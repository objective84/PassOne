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
        public string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOne\\";

        public CredentialsManager()
            : base(Services.CredentialsSoapSerializer)
        {
        }

        public void CreateCredentials(User user, Credentials creds, string path)
        {
            var credsSvc = GetService(Services.CredentialsSoapSerializer, path, user) as ISerializeSvc;
            creds.Id = credsSvc.GetNextIdValue();
            if (!user.CredentialsList.ContainsKey(creds.Website))
                user.CredentialsList.Add(creds.Website, creds.Id);
            credsSvc.UpdateTable(creds);
            (GetService(Services.UserSoapSerializer, path) as UserSoapSerializer).UpdateTable(user);
        }

        public void UpdateCredentials(User user, Credentials creds, string path)
        {
            try
            {
                GetService(path, user).UpdateTable(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        public Credentials FindCredentials(User user, int id, string path)
        {
            try
            {
                var creds =
                    ((CredentialsSoapSerializer) GetService(Services.CredentialsSoapSerializer, path, user))
                        .RetreiveById(id) as Credentials;
                return creds;
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        public void DeleteCredentials(Credentials creds, User user, string path)
        {
            try
            {
                GetService(path, user).DeleteValue(creds);
                user.CredentialsList.Remove(creds.Id);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }
    }
}
