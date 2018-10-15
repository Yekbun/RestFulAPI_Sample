using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDwithDapper.Entities;
using CRUDwithDapper.Data;

namespace RestFullServer.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        //Using multi parameterin in GET method
        // GET api/Account/5/AccountNumber
        [Route("{rowCount:int}/{sort}")]
        public HttpResponseMessage GetAccounts(int rowCount, string sort)
        {
            IEnumerable<Account> accounts = null;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, accounts);

            IAccountDataStore accountDataStore = new AccountDataStore();
            accounts= accountDataStore.GetAccounts(rowCount, sort);

            if (accounts != null)
                response = Request.CreateResponse(HttpStatusCode.OK, accounts);

            return response;
        }

        //Using string parameter in GET method
        // GET api/Account/ABC
        [Route("{accountNo}")]
        public HttpResponseMessage GetAccount(string accountNo)
        {
            Account account = null;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, account);
            IAccountDataStore accountDataStore = new AccountDataStore();
            account = accountDataStore.GetAccount(accountNo);
            if (account != null)
                response = Request.CreateResponse(HttpStatusCode.OK, account);

            return response;

        }
        //Using int parameter in method
        // GET api/Account/5
        [Route("{id:int}")]
        public HttpResponseMessage GetAccount(int id)
        {
            Account account = null;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, account);           

            IAccountDataStore accountDataStore = new AccountDataStore();
            account = accountDataStore.GetAccount(id);
            if (account !=null )
                response = Request.CreateResponse(HttpStatusCode.OK, account);
            
            return response;

        }


        // POST: api/Account
        [HttpPost]
        public HttpResponseMessage CreateAccount([FromBody]Account value)
        {
            bool retVal = false;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            IAccountDataStore accountDataStore = new AccountDataStore();
            retVal= accountDataStore.CreateAccount(value);
            if (retVal == true)
                response = Request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        // PUT: api/Account/5
       [HttpPut]
        public HttpResponseMessage UpdateAccount([FromBody]Account value)
        {
            bool retVal = false;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            IAccountDataStore accountDataStore = new AccountDataStore();
            retVal= accountDataStore.UpdateAccount(value);
            if (retVal == true)
                response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        // DELETE: api/Account/5
        [Route("{accountNo}")]
        public HttpResponseMessage DeleteAccount(string accountNo)
        {
            bool retVal = false;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            IAccountDataStore accountDataStore = new AccountDataStore();
            retVal= accountDataStore.DeleteAccount(accountNo);
            if (retVal == true)
                response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
