using Newtonsoft.Json;
using REZCores;
using REZInventory.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace REZInventory.Controllers
{
    public class BaseController : Controller
    {
      Common.SessionManager objSession = new Common.SessionManager();
        public BaseController()
        {         
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    if (objSession.UserID != 0)
                    {
                        if (filterContext.HttpContext.Session != null)
                        {
                            if (filterContext.HttpContext.Session.IsNewSession)
                            {
                                string cookie = filterContext.HttpContext.Request.Headers["Cookie"];
                                if ((cookie != null) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                                {
                                    filterContext.Result = RedirectToAction("Login", "Login", new { area = "" });
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                        return;
                    }
                }
            }
            else
            {
                filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                return;
            }
                //LoginService objLoginService = new LoginService();
                //int Result = objLoginService.DisplayLoggedOutTime(objSession.UserName, objSession.LoggedTime);
                //if (Result == 0)
                //{
                //    filterContext.Result = RedirectToAction("Login", "Login", new { area = "" });
                //    return;
                //}
                //if (Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
                //{
                //    if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                //    {
                //        if (objSession.UserID != 0)
                //        {
                //            if (filterContext.HttpContext.Session != null)
                //            {
                //                if (filterContext.HttpContext.Session.IsNewSession)
                //                {
                //                    string cookie = filterContext.HttpContext.Request.Headers["Cookie"];
                //                    if ((cookie != null) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                //                    {
                //                        filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                //                        return;
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                //        return;
                //    }
                //}
                //else
                //{
                //    filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                //    return;
                //}
                base.OnActionExecuting(filterContext);
        }
        protected override void Initialize(RequestContext requestContext)
        {
            
            HttpClient client;
            SessionManager objSessionManager = new SessionManager();
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
                ViewBag.Menu = JsonConvert.DeserializeObject<List<MenuModel>>(responseData);
            }
            base.Initialize(requestContext);
            // return Json(order);


            //MenuModel objMenu = new MenuModel();
            //MenuService objmenuservice = new MenuService();
            //objMenu.GetMenuList = objmenuservice.GetUserMenu(objSession.UserID, objSession.RoleId);
            //ViewBag.MenuList = objMenu.GetMenuList;
        }
    }
}