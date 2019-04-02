using Newtonsoft.Json;
using REZCores;
using REZInventory.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace REZInventory.Controllers
{
    public class StockTakingController : BaseController
    {
        HttpClient client;
        SessionManager objSessionManager = new SessionManager();
        public StockTakingController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Store = new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.StockTakenType = new SelectList(await GetInventoryType(), "CodeID", "CodeName");
            return View();
        }
        public  async Task<List<StoreModel>> GetStore()
        {
            List<StoreModel> lst = new List<StoreModel>();
            string url = StVariable.ApiUri + "/api/Store/DDLStore";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                 lst = JsonConvert.DeserializeObject<List<StoreModel>>(responseData);        
            }
            return lst;
        }
        public async Task<List<SystemCode>> GetInventoryType()
        {
            List<SystemCode> lst = new List<SystemCode>();
            string url = StVariable.ApiUri + "/api/Common/DDLSystemCode?CodeTypeId=1"; 
           
            HttpResponseMessage responseMessage1 = await client.GetAsync(url);
            if (responseMessage1.IsSuccessStatusCode)
            {
                var responseData = responseMessage1.Content.ReadAsStringAsync().Result;
                 lst = JsonConvert.DeserializeObject<List<SystemCode>>(responseData);             
            }
            return lst;
        }

        public async Task<ActionResult> Create()
        {
            int NoofDays = 3;
            int DayofWeek = 4;
            int DateofMonth = 28;
            ViewBag.MinDate = DateTime.Now.AddDays(-NoofDays);
            ViewBag.DayofWeek = DayofWeek;
            ViewBag.DateofMonth = DateofMonth;
            ViewBag.Store = new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.StockTakenType = new SelectList(await GetInventoryType(), "CodeID", "CodeName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(StockTakenModel ob)
        {
            ob.UserId = objSessionManager.UserID;
            string url = StVariable.ApiUri + "/api/StockTaken/SaveStockTaken";
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    return Json(new { success = true, StockTakingId = responseData }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetStockTaken(int StocktakingTypeId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            try
            {
                string url = StVariable.ApiUri + "/api/StockTaken/GetStockTaken?Qtype=ALL&StocktakingTypeId=" + StocktakingTypeId+ "&StoreId=" + StoreId+ "&FromDate="+FromDate + "&Todate=" + Todate;        
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        return Json(new { success = responseData }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { success = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);
        }


        public  async Task<JsonResult>  CheckInventory(StockTakenModel ob)
        {  
            try
            {
                string url = StVariable.ApiUri + "/api/StockTaking/CheckStockTaken?Qtype=ID&StocktakingTypeId=" + ob.StocktakingTypeId + "&StoreId=" + ob.StoreId + "&BDate=" + ob.BDate ; 
              
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        return Json(new { success = 1, msg= responseData }, JsonRequestBehavior.AllowGet);
                    }
                }                
            }
            catch (Exception ex)
            {
               
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);
            //if (obj.Count > 0)
            //{
            //    return Json(new { success = 1 }, JsonRequestBehavior.AllowGet);
            //}
            //else if (obj1.Count > 0)
            //{
            //    return Json(new { success = 2 }, JsonRequestBehavior.AllowGet);
            //}
            //else if (st <= 0)
            //{
            //    return Json(new { success = 3 }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(new { success = 4 }, JsonRequestBehavior.AllowGet);
            //}
        }


        public async Task<ActionResult> CountSheet(int StockTakingId)
        {
            string url = StVariable.ApiUri + "/api/StockTaken/GetStockTakenDetail?Qtype=ID&StockTakingId=" + StockTakingId;
            StockTakenModel model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                 model = JsonConvert.DeserializeObject<StockTakenModel>(responseData);             
            }
            return View(model);
        }
    }
}