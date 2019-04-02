using Newtonsoft.Json;
using REZInventory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace REZInventory.Controllers
{
 
    public class HomeController : BaseController
    {
        HttpClient client;
        SessionManager objSessionManager = new SessionManager();
        public HomeController()
        {
            StVariable.ApiUri = System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString();
            StVariable.ApiUri = System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString();

            client = new HttpClient();
            //client.BaseAddress = new Uri(StVariable.ApiUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
        }
        // GET: Home
        public ActionResult Index()
        {
            client.DefaultRequestHeaders.Authorization
                      = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
            string url = StVariable.ApiUri + "/api/Home/Get";
           // List<UnitModel> model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage =  client.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var result  = JsonConvert.DeserializeObject<string>(responseData);
                ViewBag.result = result;
            }
            else if(responseMessage.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                ViewBag.Error = "User Dont have permission";
                return View("Error");
            }
            else
            {
                ViewBag.Error = "there is some error";
                return View("Error");
            }
            // return Json(order);
           
            return View();
           
        }
    }
}