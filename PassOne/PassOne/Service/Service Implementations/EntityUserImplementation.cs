using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;


namespace PassOne.Service
{
    public class EntityUserImplementation : IPassOneDataSvc
    {
        public PassOneObject RetreiveById(int id)
        {
            var context = new PassOneContext();
            var query = from u in context.Users select u;
            var users = query.ToList();

            return users.Where(user => user.Id == id).Select(ConvertToDomainObject).FirstOrDefault();
        }

        public void Create(PassOneObject obj)
        {
            obj.Id = GetNextIdValue();
            using (var db = new PassOneContext())
            {
                db.Users.Add(ConvertToEntity(obj));
                db.SaveChanges();
            }
        }

        public void Delete(PassOneObject obj)
        {
            using (var db = new PassOneContext())
            {
                var userQuery = from u in db.Users select u;
                var user = userQuery.ToList().FirstOrDefault(user1 => user1.Id == obj.Id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void Edit(PassOneObject obj)
        {
            using (var db = new PassOneContext())
            {
                var userQuery = from u in db.Users select u;
                var user = userQuery.ToList().FirstOrDefault(user1 => user1.Id == obj.Id);
                userQuery.ToList().Remove(user);
                userQuery.ToList().Add((ConvertToEntity(obj)));
                db.SaveChanges();
            }
        }

        public int GetNextIdValue()
        {
            var context = new PassOneContext();
            var query = from u in context.Users select u;
            var users = query.ToList();

            return users.Select(user => user.Id).Concat(new[] {0}).Max() + 1;
        }

        public PassOneUser Authenticate(string username, string password)
        {
            User user;
            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var query = from u in db.Users select u;
                user = query.ToList().FirstOrDefault(user1 => user1.Username == username && user1.Password == password);
            }
            if (user == null)
                throw new InvalidLoginException();

            return new PassOneUser(user.Id, user.FirstName, user.LastName, user.Username, user.Password, user.k,
                                   user.v);
        }

        private PassOneUser ConvertToDomainObject(User entity)
        {
            return new PassOneUser(entity.Id, entity.FirstName, entity.LastName, entity.Username, entity.Password, entity.k, entity.v);
        }

        private User ConvertToEntity(PassOneObject obj)
        {
            var user = (PassOneUser) obj;
            var newUser = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    k = user.K,
                    v = user.V
                };
            return newUser;
        }
    }
}