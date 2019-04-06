using Newtonsoft.Json;
using REZInventory.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
            HttpClient client;
          
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization
                     = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
            string url = StVariable.ApiUri + "/api/Menu/GetMenu?RoleId=1";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = client.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
               // ViewBag.Menu = JsonConvert.DeserializeObject<List<MenuModel>>(responseData);
            }
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