using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;
using CRUDwithDapper.Entities;

namespace CRUDwithDapper.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        private IDbConnection getConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);
        }

       bool IAccountDataStore.DeleteAccount(string accountNumber)
        {
            int retVal = 0;
            using (IDbConnection db = getConnection())
            {
                retVal = db.Execute(@"DELETE FROM [Accounts] WHERE AccountNumber = @AccountNumber", new { AccountNumber = accountNumber });
            }
            if (retVal > 0)
            {
                return true;
            }
            return false;
        }

        Account IAccountDataStore.GetAccount(string accountNumber)
        {
            using (IDbConnection db = getConnection())
            {
                return db.Query<Account>("SELECT [Id], [AccountNumber] ,[Balance],[Status],[AllowedPaymentSchemes] FROM [Accounts] WHERE [AccountNumber] =@AccountNumber", new { AccountNumber = accountNumber }).SingleOrDefault();
            }
        }

        Account IAccountDataStore.GetAccount(int id)
        {
            using (IDbConnection db = getConnection())
            {
                return db.Query<Account>("SELECT [Id],[AccountNumber] ,[Balance],[Status],[AllowedPaymentSchemes] FROM [Accounts] WHERE [Id] =@Id", new { Id = id }).SingleOrDefault();
            }
        }

      

        List<Account> IAccountDataStore.GetAccounts(int rowCount, string sort)
        {
            using (IDbConnection db = getConnection())
            {
                return db.Query<Account>("SELECT TOP " + rowCount.ToString() + " [Id],[AccountNumber] ,[Balance],[Status],[AllowedPaymentSchemes]  FROM [Accounts] ORDER BY  " + sort).ToList();
            }
        }

        bool IAccountDataStore.CreateAccount(Account account)
        {
            int retVal = 0;

            using (IDbConnection db = getConnection())
            {
                retVal = db.Execute(@"INSERT INTO [Accounts] ([AccountNumber],[Balance],[Status],[AllowedPaymentSchemes]) VALUES (@AccountNumber,@Balance,@Status,@AllowedPaymentSchemes)",
                                new
                                {
                                    AccountNumber = account.AccountNumber,
                                    Balance = account.Balance,
                                    Status = account.Status,
                                    AllowedPaymentSchemes = account.AllowedPaymentSchemes
                                });
            }
            if (retVal > 0)
            {
                return true;
            }
            return false;
        }

        bool IAccountDataStore.UpdateAccount(Account account)
        {
            int retVal = 0;
            using (IDbConnection db = getConnection())
            {
                retVal = db.Execute("UPDATE [Accounts] SET [Balance] = @Balance ,[Status] = @Status ,[AllowedPaymentSchemes] = @AllowedPaymentSchemes WHERE [AccountNumber] =@AccountNumber",
                    new
                    {
                        AccountNumber = account.AccountNumber,
                        Balance = account.Balance,
                        Status = account.Status,
                        AllowedPaymentSchemes = account.AllowedPaymentSchemes
                    });
            }
            if (retVal > 0)
            {
                return true;
            }
            return false;
        }

     
    }
}
