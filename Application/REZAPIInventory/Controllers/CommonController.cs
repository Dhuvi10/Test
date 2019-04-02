using REZCores;
using REZRepository;
using System.Web.Http;
using System.Web.Http.Description;
using System.Security.Claims;
using REZServices;

namespace REZAPIInventory.Controllers
{
    [Authorize]
    public class CommonController : ApiController
    {       
        BLCommon obj = new BLCommon();
        public CommonController()
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
        [HttpGet]
        [ResponseType(typeof(SystemCode))]
        public IHttpActionResult DDLSystemCode(int CodeTypeId)
        {
            var list = obj.DDLSystemCode(CodeTypeId);
            return Ok(list);
        }
    }
}
