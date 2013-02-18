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
        /// <summary>
        /// Method for retreiving a given service from the Service Layer
        /// </summary>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="user">Optional parameter - required for credentials services</param>
        /// <returns>The requested service</returns>
        protected ISerializeSvc GetService(string path, User user = null)
        {
            return (ISerializeSvc)Factory.GetService(_service, path, user);
        }
        /// <summary>
        /// Method for retreiving a given service from the Service Layer, used only if the requested service is of another type.
        /// </summary>
        /// <param name="service">Enum - defines the specific service to be retrived</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="user">Optional parameter - required for credentials services</param>
        /// <returns></returns>
        protected ISerializeSvc GetService(Services service, string path, User user = null)
        {
            return (ISerializeSvc)Factory.GetService(service, path, user);
        }
    }
}

