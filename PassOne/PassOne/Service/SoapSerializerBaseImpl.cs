using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;

namespace PassOne.Service
{
    public abstract class SoapSerializerBaseImpl : ISerializeSvc
    {
        protected static string DirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                       "//PassOne//data//";
            }
        }
        protected readonly string TempPath = DirectoryPath + "temp.bin";

        public abstract string FileName { get; }

        protected Hashtable RetrieveTable()
        {
            var soap = new SoapFormatter();
            try
            {
                //Check if directory exists, if not create it.
                if (!Directory.Exists(DirectoryPath)) Directory.CreateDirectory(DirectoryPath);
                
                //Check if file exists, if not create it.
                if (!File.Exists(FileName))
                {
                    var str = File.Create(FileName);
                    str.Close();
                }
            }
            catch (IOException)
            {
                //Throw FileNotFoundException if problem occurs creating the file.
                if (!File.Exists(FileName)) throw new FileNotFoundException();
            }

            File.Copy(FileName, TempPath);
            var tempStream = new FileStream(TempPath, FileMode.Open, FileAccess.Read);

            //If data exists in tempStream, deserialize it into a Hashtable, else create an empty Hashtable.
            var table = tempStream.Length > 0 ? soap.Deserialize(tempStream) as Hashtable : new Hashtable();
            tempStream.Close();
            File.Delete(TempPath);
            return table;
        }

        public int GetNextIdValue()
        {
            return (RetrieveTable().Count + 1);
        }

        public virtual object RetreiveById(int id)
        {
            return RetrieveTable()[id];
        }

        public virtual void DeleteValue(object obj)
        {
            var temp = new Hashtable();
            var values = RetrieveTable();
            foreach (var key in values.Keys)
                temp.Add(key, values[key]);

            foreach (var value in temp.Cast<object>().Where(value => value.Equals(obj)))
            {
                values.Remove(value);
                break;
            }
            Store(values);
        }

        public void Store(Hashtable table)
        {
            var soap = new SoapFormatter();
            var stream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            soap.Serialize(stream, table);
            stream.Close();
        }

        public abstract void UpdateTable(object obj);
    }
}
