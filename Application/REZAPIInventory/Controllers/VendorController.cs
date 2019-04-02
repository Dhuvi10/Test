using REZCores;
using REZRepository;
using REZServices;
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using System.Security.Claims;
namespace REZAPIInventory.Controllers
{
   [Authorize]
  
    public class VendorController : ApiController
    {


        BLVendor obj = new BLVendor();
        public VendorController()
        {

            // Utility.ConnectionString = Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString; ;
            //Utility.ConnectionString = Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString; ;

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



        [HttpGet]
        [ResponseType(typeof(VendorModel))]
        public IHttpActionResult DDLVendor()
        {
            var list = obj.DDLVendor();
            return Ok(list);

        }      


        [HttpGet]             
        [ResponseType(typeof(VendorCatalogModel))]
        public IHttpActionResult GetVendorCatalog(string Qtype, int VendorId,int ItemGroupId)
        {

            var list = obj.GetVendorCatalog(Qtype, VendorId, ItemGroupId);
            return Ok(list);
           
        }

    }
}
