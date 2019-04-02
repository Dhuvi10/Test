using REZCores;
using REZRepository;
using REZServices;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace REZAPIInventory.Controllers
{
    [Authorize]
    public class StoreController : ApiController
    {
        BLStore obj = new BLStore();
        public StoreController()
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
        [ResponseType(typeof(StoreModel))]
        public IHttpActionResult GetStore(string Qtype, int StoreId,int MasterStoreId)
        {
            var list = obj.DisplayStore(Qtype, StoreId,MasterStoreId);
            return Ok(list);
        }
        //[AcceptVerbs("GET", "POST")]
        [HttpGet]
        [ResponseType(typeof(StoreModel))]
        public IHttpActionResult DDLStore()
        {
            var list = obj.DDLStore();
            return Ok(list);
        }
        [ResponseType(typeof(StoreModel))]
        public IHttpActionResult SaveStore(StoreModel ob)
        {
            string str = obj.SaveStore(ob);
            return Ok(str);
        }
    }
}
