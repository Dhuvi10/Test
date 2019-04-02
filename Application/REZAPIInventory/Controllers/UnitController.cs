using REZCores;
using REZRepository;
using REZServices;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace REZAPIInventory.Controllers
{
    [Authorize]
    public class UnitController : ApiController
    {
        public UnitController()
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
            //  Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString;
            //Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZInventoryConn"].ConnectionString;
        }
        BLUnit obj = new BLUnit();
        [ResponseType(typeof(UnitModel))]
        [Authorize]
        public IHttpActionResult GetUnit(string Qtype,int UnitId)
        {
            var list = obj.DisplayUnitMaster(Qtype, UnitId);
            return Ok(list);
        }
        [ResponseType(typeof(UnitModel))]
        public IHttpActionResult SaveUnit(UnitModel ob)
        {
            string str = obj.SaveUnitMaster(ob);
            return Ok(str);
        }
    }
}
