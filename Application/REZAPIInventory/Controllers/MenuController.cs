using REZRepository;
using REZServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
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
                    var DBCS = ConfigurationManager.ConnectionStrings["REZInventoryConn"];

                    //Convert Readonly to Writable (In Connection String Provider is readonly so we need to change it as Writable)  
                    //Dont forgot to Declare BelowNameSpace  
                    //using System.Configuration;  
                    //using System.Reflection;  
                    var writable = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    writable.SetValue(DBCS, false);

                    //Replace Connecion string  
                    DBCS.ConnectionString = item.Value;
                    //ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString= item.Value;
                    //Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZLoginConn"].ConnectionString;
                    //Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString;
                    //Utility.ConnectionString = item.Value;
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
