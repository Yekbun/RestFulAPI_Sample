using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwithDapper.Entities
{
   public class Account
    {
        public virtual string AccountNumber { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual AccountStatus Status { get; set; }
        public virtual AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }
    }
}
