using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwithDapper.Entities
{
    public enum AllowedPaymentSchemes : int
    {
        FasterPayments,
        Bacs,
        Chaps
    }
}
