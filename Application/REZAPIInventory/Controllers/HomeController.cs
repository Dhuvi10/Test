
using REZServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace REZAPIInventory.Controllers
{
   
    public class HomeController : ApiController
    {
        public HomeController()
        {

            var identity = User.Identity as ClaimsIdentity;
            foreach (var item in identity.Claims)
            {
                if (item.Type == "ConnectionString")
                {
                    Utility.ConnectionString = item.Value;
                    Utility.ConnectionString = item.Value;
                }

            }
        }
          //  var claims = identity.Claims.Select(e => e.Type== "ConnectionString");
            //this load once at login api
       
        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
           
            return Ok("Test Is Ok");
        }
        //[HttpGet]
        //[Route("Test/{id}")]
        //public IHttpActionResult Test(int id)
        //{
        //    return Ok("Ok");
        //}

    }
}
