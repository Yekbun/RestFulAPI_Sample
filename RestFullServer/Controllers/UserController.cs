using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDwithDapper.Data;
using CRUDwithDapper.Entities;

namespace RestFullServer.Controllers
{
    [RoutePrefix("api/login")]
    public class UserController : ApiController
    {
        // GET: api/User
        [Route("{userMail}/{password}")]
        public HttpResponseMessage GetUser(string userMail, string password)
        {
            User user = null;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, user);
            IUserDataStore userDataStore = new UserDataStore();
            user = userDataStore.GetUser(userMail, password);

            if (user != null)
                response = Request.CreateResponse(HttpStatusCode.OK, user);

            return response;
        }
    }
}
