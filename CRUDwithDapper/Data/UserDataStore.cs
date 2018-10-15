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
    public class UserDataStore : IUserDataStore
    {
        private IDbConnection getConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);
        }           

        User IUserDataStore.GetUser(string userMail)
        {
            using (IDbConnection db = getConnection())
            {
                return db.Query<User>("SELECT [UserMail],[Password],[LastLoginTime],[Name],[Surname] FROM [Users] WHERE [UserMail]=@userMail", new { userMail = userMail }).SingleOrDefault();
            }
        }
        User IUserDataStore.GetUser(string userMail, string password)
        {
            using (IDbConnection db = getConnection())
            {
                return db.Query<User>("SELECT [UserMail],[Password],[LastLoginTime],[Name],[Surname] FROM [Users] WHERE [UserMail]=@userMail AND [Password]=@Password", new { userMail = userMail , Password = password }).SingleOrDefault();
            }
        }


    }
}
