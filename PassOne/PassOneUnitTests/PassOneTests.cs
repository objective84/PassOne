using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests
{
   public abstract class PassOneTests
   {
       public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PassOneTests\\";
       protected readonly SoapFactory Factory;
       protected readonly User TestUser = new User(1, "Peter", "Varner-Howland", "pvarnerhowland", "testPass321");
       protected readonly User TestUser2 = new User(2, "Arwen", "Varner-Howland", "avarnerhowland", "testPass123");

       protected readonly Credentials TestCredentials = new Credentials("Regis WorldClass", "https://worldclass.regis.edu/",
                                                             "pvarnerhowland",
                                                             "testpass123", "pvarnerhowland@regis.edu", 1);
       protected readonly Credentials TestCredentials2 = new Credentials("Regis InSite", "https://in2.regis.edu/CookieAuth.dll?GetLogon?curl=Z2F&reason=0&formdir=6",
                                                             "pvarnerhowland",
                                                             "testpass456", "pvarnerhowland@regis.edu", 2);

       protected PassOneTests()
       {
           Factory = new SoapFactory();
       }
    }
}
