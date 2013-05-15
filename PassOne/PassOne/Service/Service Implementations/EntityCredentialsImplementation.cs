using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;

namespace PassOne.Service
{
    public class EntityCredentialsImplementation : IPassOneDataSvc
    {
        public PassOneObject RetreiveById(int id)
        {
            var context = new PassOneContext();
            var query = from u in context.Credentials select u;
            var creds = query.ToList();

            return creds.Where(user => user.Id == id).Select(ConvertToDomainObject).FirstOrDefault();
        }

        public void Create(PassOneObject obj)
        {
            obj.Id = GetNextIdValue();
            var creds = (PassOneCredentials) obj;
            using (var db = new PassOneContext())
            {
                var userQuery = from u in db.Users select u;
                var user = userQuery.ToList().FirstOrDefault(user1 => user1.Id == creds.UserId);
                creds.Encrypt(new Encryption(user.k, user.v));
                var entity = ConvertToEntity(creds);
                entity.User = user;
                db.Credentials.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(PassOneObject obj)
        {
            using (var db = new PassOneContext())
            {
                var query = from c in db.Credentials select c;
                var creds = query.ToList().FirstOrDefault(creds1 => creds1.Id == obj.Id);
                db.Credentials.Remove(creds);
                db.SaveChanges();
            }
        }

        public void Edit(PassOneObject obj)
        {
            using (var db = new PassOneContext())
            {
                
                var credsQuery = from u in db.Credentials select u;
                var creds = credsQuery.ToList().FirstOrDefault(user1 => user1.Id == obj.Id);
                db.Credentials.Remove(creds);
                db.Credentials.Add((ConvertToEntity(obj)));
                db.SaveChanges();
            }
        }

        public int GetNextIdValue()
        {
            var context = new PassOneContext();
            var query = from u in context.Credentials select u;
            var users = query.ToList();

            return users.Select(user => user.Id).Concat(new[] { 0 }).Max() + 1;
        }

        public Dictionary<string, int> GetCredentialsList(int userId)
        {
            var list = new Dictionary<string, int>();
            using (var db = new PassOneContext())
            {
                var query = from c in db.Credentials select c;
                foreach (var credential in query.ToList())
                {
                    if (credential.UserId == userId)
                    {
                        var decrypted = ConvertToDomainObject(credential);
                        decrypted.Decrypt(new Encryption(credential.User.k, credential.User.v));
                        list.Add(decrypted.Website, credential.Id);
                    }
                }
            }
            return list;
        }

        private PassOneCredentials ConvertToDomainObject(Credential entity)
        {
            return new PassOneCredentials()
                {
                    EncryptedWebsite = entity.Website,
                    EncryptedUrl = entity.Url,
                    EncryptedUsername = entity.Username,
                    EncryptedEmail = entity.Email,
                    EncryptedPassword = entity.Password
                };
        }

        private Credential ConvertToEntity(PassOneObject obj)
        {
            var creds = (PassOneCredentials) obj;
            var newCred = new Credential
                {
                    Website = creds.EncryptedWebsite,
                    Url = creds.EncryptedUrl,
                    Username = creds.EncryptedUsername,
                    Email = creds.EncryptedEmail,
                    Password = creds.EncryptedPassword
                };
            return newCred;
        }
    }
}