using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using PassOne.Domain;

namespace PassOne.Service
{
    internal class UserSoapSerializer : SoapSerializerBaseImpl
    {
        public override string FileName { get { return DirectoryPath +  "data\\users.bin"; } }

        //Constructors
        public UserSoapSerializer()
        {
        }

        /// <summary>
        /// Method to store or update a user in the user.bin file.
        /// </summary>
        /// <param name="obj">User to be stored</param>
        public override void UpdateTable(object obj)
        {
            User user = null;
            try
            {
                user = (User)obj;

                var userTable = RetrieveTable();
                if (userTable.ContainsKey(user.Id))
                    userTable[user.Id] = user;
                else
                    userTable.Add(user.Id, user);
                Store(userTable);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Object is not a User");
            }
        }

        /// <summary>
        /// Method to retrieve a specific user by their username
        /// </summary>
        /// <param name="username">The username of the requested User</param>
        /// <returns>The requested user if found; if not returns null</returns>
        public User RetrieveByUsername(string username)
        {
            var users = RetrieveTable();
            var keys = users.Keys;
            foreach (var key in keys)
            {
                var temp = (User)users[key];
                if (temp.Username == username) return temp;
            }
            return null;
        }
    }
}
