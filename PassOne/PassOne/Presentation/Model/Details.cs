using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PassOne.Presentation
{
    public class Details : INotifyPropertyChanged
    {
        private string _title;
        private string _url;
        private string _username;
        private string _password;
        private string _email;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("URL");
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public void Clear()
        {
            Title = string.Empty;
            Url = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Details(PropertyChangedEventHandler handler)
        {
            PropertyChanged = handler;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
