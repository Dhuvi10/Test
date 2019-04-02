using REZRepository;
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
    public class MenuController : ApiController
    {
        public MenuController()
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
        BLMenu obj = new BLMenu();
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetMenu(int RoleId)
        {
            var list = obj.Menu(RoleId);
            return Ok(list);
        
        }
    }
}
