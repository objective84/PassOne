using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Service
{
    public enum Services
    {
        CredentialsSoapSerializer,
        UserSoapSerializer,
        UserAuthenticator
    }

    public abstract class Factory
    {

        public abstract IService GetService(Services serviceName, string path, User user = null);

        protected string GetImplName(string servicename)
        {
            var settings =
                ConfigurationManager.AppSettings;
            return settings.Get(servicename);
        }
    }
}

