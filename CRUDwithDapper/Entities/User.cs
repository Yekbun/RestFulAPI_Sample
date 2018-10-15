using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwithDapper.Entities
{
   public class User
    {
        public virtual string UserMail { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime LastLoginTime { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
    }
}
