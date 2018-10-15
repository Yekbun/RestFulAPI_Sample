using CRUDwithDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwithDapper.Data
{
   public  interface IUserDataStore    {
       
        User GetUser(string userMail);
        User GetUser(string userMail, string password);

    }
}
