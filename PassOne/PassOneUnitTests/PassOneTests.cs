using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;
using PassOne.Service.Factories;

namespace PassOneUnitTests
{
   public abstract class PassOneTests
   {
       protected readonly Factory Factory;
       protected readonly PassOneUser TestUser = new PassOneUser(1, "Peter", "Varner-Howland", "pvarnerhowland", "testPass321");
       protected readonly PassOneUser TestUser2 = new PassOneUser(2, "Arwen", "Varner-Howland", "avarnerhowland", "testPass123");

       protected readonly PassOneCredentials TestCredentials = new PassOneCredentials("Regis WorldClass", "https://worldclass.regis.edu/",
                                                             "pvarnerhowland",
                                                             "testpass123", "pvarnerhowland@regis.edu", 1);
       protected readonly PassOneCredentials TestCredentials2 = new PassOneCredentials("Regis InSite", "https://in2.regis.edu/CookieAuth.dll?GetLogon?curl=Z2F&reason=0&formdir=6",
                                                             "pvarnerhowland",
                                                             "testpass456", "pvarnerhowland@regis.edu", 2);

       protected PassOneTests()
       {
           Factory = new EntityFactory();
       }
    }
}
