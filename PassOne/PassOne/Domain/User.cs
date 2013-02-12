using System;
using System.Collections;

namespace PassOne.Domain
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Username { get;  set; }
        public string Password { get;  set; }
        public readonly Hashtable CredentialsList;
        public Encryption Encryption;

        //Constuctors
        public User()
        {
            CredentialsList = new Hashtable();
            Encryption = new Encryption();
        }

        public User(int id, string first, string last, string user, string pass)
        {
            CheckForMissingInformation(first, last, user, pass);
            Id = id;
            FirstName = first;
            LastName = last;
            Username = user;
            Password = pass;
            CredentialsList = new Hashtable();
            Encryption = new Encryption();
        }

        public User(int id, string first, string last, string user, string pass, Hashtable list)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            Username = user;
            Password = pass;
            CredentialsList = list;
            Encryption = new Encryption();
        }

        private void CheckForMissingInformation(string fn, string ln, string username, string password)
        {
            if (fn == string.Empty)
                throw new MissingInformationException("your first name");
            if (ln == string.Empty)
                throw new MissingInformationException("your last name");
            if (username == string.Empty)
                throw new MissingInformationException("a username");
            if (password == string.Empty)
                throw new MissingInformationException("a password");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User) obj);
        }

        protected bool Equals(User other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) &&
                   string.Equals(Username, other.Username) && string.Equals(Password, other.Password);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CredentialsList != null ? CredentialsList.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Encryption != null ? Encryption.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return "First name: " + FirstName +
                   "/nLast name: " + LastName +
                   "/nUsername: " + Username +
                   "/nPassword: " + Password;
        }
    }
}
