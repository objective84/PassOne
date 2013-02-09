using System;
using System.Collections.Specialized;
using System.Configuration;
using PassOne.Domain;

namespace PassOne.Service
{
    public enum Services
    {
        CredentialsSoapSerializer,
        UserSoapSerializer,
        UserAuthenticator
    }

    public class SoapFactory
    {
        public IService GetService(Services serviceName, User user = null)
        {
            Type type;
            var obj = new object();
            try
            {
                type = Type.GetType(GetImplName(serviceName.ToString()));
                obj = Activator.CreateInstance(type);
            }
            catch (MissingMethodException)
            {
                obj = new CredentialsSoapSerializer(user);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }
            return (IService) obj;
        }

        private string GetImplName(string servicename)
        {
            var settings =
            ConfigurationManager.AppSettings;
            return settings.Get(servicename);
        }
    }
}
