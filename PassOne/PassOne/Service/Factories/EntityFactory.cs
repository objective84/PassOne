using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service.Factories
{
   public class EntityFactory : Factory
    {
        public override IService GetService(Services serviceName)
        {
            Type type;
            var obj = new object();
            try
            {
                type = Type.GetType(GetImplName(serviceName.ToString()));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }
            return (IService)obj;
        }
    }
}
