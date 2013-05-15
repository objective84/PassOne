using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   public interface IPassOneDataSvc : IService
   {
       PassOneObject RetreiveById(int id);
       void Create(PassOneObject obj);
       void Delete(PassOneObject obj);
       void Edit(PassOneObject obj);
       int GetNextIdValue();
   }
}
