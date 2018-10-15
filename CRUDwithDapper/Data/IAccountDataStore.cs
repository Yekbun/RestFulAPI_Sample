using CRUDwithDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwithDapper.Data
{
   public  interface IAccountDataStore
    {
        List<Account> GetAccounts(int rowCount, string sort);

        Account GetAccount(string accountNumber);
        Account GetAccount(int id);

        bool CreateAccount(Account account);

        bool DeleteAccount(string accountNumber);

        bool UpdateAccount(Account account);

    }
}
