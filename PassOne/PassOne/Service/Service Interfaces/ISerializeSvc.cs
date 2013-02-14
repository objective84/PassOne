using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   public interface ISerializeSvc : IService
   {
       string FileName { get; }

       object RetreiveById(int id);
       void Store(Hashtable table);
       void DeleteValue(object obj);
       int GetNextIdValue();
       void UpdateTable(object obj);
       void SetPath(string path);
   }
}
