using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;
using PassOne.Service.Factories;

namespace PassOne.Business
{
    public abstract class ManagerBase
    {
        protected Factory Factory;
        private Services _service;

        protected ManagerBase(Services service)
        {
            Factory = new EntityFactory();
            _service = service;
        }
        /// <summary>
        /// Method for retreiving a given service from the Service Layer
        /// </summary>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="user">Optional parameter - required for credentials services</param>
        /// <returns>The requested service</returns>
        protected IPassOneDataSvc GetService()
        {
            return (IPassOneDataSvc)Factory.GetService(_service);
        }
        /// <summary>
        /// Method for retreiving a given service from the Service Layer, used only if the requested service is of another type.
        /// </summary>
        /// <param name="service">Enum - defines the specific service to be retrived</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="user">Optional parameter - required for credentials services</param>
        /// <returns></returns>
        protected IService GetService(Services service)
        {
            return Factory.GetService(service);
        }
    }
}

