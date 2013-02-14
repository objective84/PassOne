using System;
using System.Collections.Specialized;
using System.Configuration;
using PassOne.Domain;

namespace PassOne.Service
{
    public class SoapFactory : Factory
    {
        public override IService GetService(Services serviceName, string path,  User user = null)
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
            ((ISerializeSvc)obj).SetPath(path);
            return (IService) obj;
        }
    }
}
