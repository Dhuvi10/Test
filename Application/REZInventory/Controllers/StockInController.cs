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
    public class StockInController : BaseController
    {
        HttpClient client;
        SessionManager objSessionManager = new SessionManager();

        public StockInController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
        }

        public async Task<ActionResult> Index()
        {
            var storedata= new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.In_StoreId = storedata;
            ViewBag.Out_StoreId = storedata;
            return View();
        }

        public async Task<List<StoreModel>> GetStore()
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

        public async Task<JsonResult> GetItem(int Out_StoreId)
        {
            string url = StVariable.ApiUri + "/api/Vendor/GetVendorCatalog?Qtype=ItemId&VendorId=0&ItemGroupId=" + Out_StoreId;
            HttpResponseMessage responseMessage1 = await client.GetAsync(url);
            if (responseMessage1.IsSuccessStatusCode)
            {
                var responseData = responseMessage1.Content.ReadAsStringAsync().Result;
                return Json(new { success = 1, msg = responseData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);
        }
                     
        public async Task<ActionResult> Create()
        {
            var storedata = new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.In_StoreId = storedata;
            ViewBag.Out_StoreId = storedata;
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> SaveStockRequest(StockInOutModel ob)
        {
            var StockReqId = 0;
            ob.UserId = objSessionManager.UserID;
            string url = StVariable.ApiUri + "/api/StockInOut/SaveStockRequest";
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result.Replace("\"", "").Split('|');
                    if (responseData[1] == "")
                    {
                        StockReqId = Convert.ToInt16(responseData[0]);
                        return RedirectToAction("StockInItem", new { StockReqId= StockReqId });
                       // return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveStockRequestItem(SaveItemModel ob)
        {
            ob.UserId = objSessionManager.UserID;
            string url = StVariable.ApiUri + "/api/StockInOut/SaveOrderItem";
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    return Json(new { success = responseData }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> GetStockRequest(int In_StoreId, int Out_StoreId, DateTime FromDate, DateTime Todate)
        {
            try
            {
                string url = StVariable.ApiUri + "/api/StockInOut/GetStockRequest?Qtype=ALL&In_StoreId=" + In_StoreId + "&Out_StoreId=" + Out_StoreId + "&FromDate=" + FromDate + "&Todate=" + Todate;
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
            }
            catch (Exception ex)
            {
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> StockInItem(int StockReqId)
        {
            string url = StVariable.ApiUri + "/api/StockInOut/GetStockRequestDetail?Qtype=ID&StockReqId=" + StockReqId;
            StockInOutModel model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<StockInOutModel>(responseData);
            }
            return View(model);
        }

        public async Task<JsonResult> GetStockInItem(int StockReqId)
        {
            string url = StVariable.ApiUri + "/api/StockInOut/GetStockRequestDetail?Qtype=ID&StockReqId=" + StockReqId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return Json(new { success = responseData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = "Error" }, JsonRequestBehavior.AllowGet);
        }

    }
}