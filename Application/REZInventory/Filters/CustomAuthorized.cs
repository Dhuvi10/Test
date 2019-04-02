using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace REZInventory.Filters
{
    public class CustomAuthorized:AuthorizeAttribute
    {
        string MenuCode;
        public CustomAuthorized(string Menucode)
        {
            MenuCode = Menucode;           
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Common.SessionManager objSessionManager = new Common.SessionManager();
            bool authorize = false;    
            int UserId = objSessionManager.UserID;
            int RoleId = objSessionManager.RoleId;

            //UserRightsMenuService obj = new UserRightsMenuService();
            //if (obj.CustomAuthorization(UserId, MenuCode, RoleId))
            //{ authorize = true; }
            //else { authorize = false; }
            //return obj.CustomAuthorization(UserId, MenuCode, RoleId);
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "../Account", action = "Login" }));
         
        }
    }
}