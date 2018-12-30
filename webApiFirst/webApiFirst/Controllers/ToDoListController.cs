using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiFirst.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class ToDoListController : ApiController
    {
        // GET api/values/5
        public string Get()
        {
            return "Hellow World";
        }

    }
}
