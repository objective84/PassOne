using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Business
{
    public abstract class ManagerBase
    {
        protected Factory Factory;
        private Services _service;

        protected ManagerBase(Services service)
        {
            Factory = new SoapFactory();
            _service = service;
        }

        protected ISerializeSvc GetService(string path, User user = null)
        {
            return (ISerializeSvc)Factory.GetService(_service, path, user);
        }

        protected ISerializeSvc GetService(Services service, string path, User user = null)
        {
            return (ISerializeSvc)Factory.GetService(service, path, user);
        }
    }
}

