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
    public class OrderController : BaseController
    {
        HttpClient client;
        SessionManager objSessionManager = new SessionManager();

        public OrderController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.StoreId = new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.VendorId = new SelectList(await GetVendor(), "VendorId", "VendorName");
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

        public async Task<List<VendorModel>> GetVendor()
        {
            List<VendorModel> lst = new List<VendorModel>();
            string url = StVariable.ApiUri + "/api/Vendor/DDLVendor";           
            HttpResponseMessage responseMessage1 = await client.GetAsync(url);
            if (responseMessage1.IsSuccessStatusCode)
            {
                var responseData = responseMessage1.Content.ReadAsStringAsync().Result;
                lst = JsonConvert.DeserializeObject<List<VendorModel>>(responseData);
            }
            return lst;
        }

        public async Task<JsonResult> GetVendorCatalog(int VendorId,int OrderId)
        {           
            string url = StVariable.ApiUri + "/api/Vendor/GetVendorCatalog?Qtype=Catalog&VendorId=" + VendorId + "&ItemGroupId=" + OrderId;
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
            ViewBag.StoreId = new SelectList(await GetStore(), "StoreId", "StoreName");
            ViewBag.VendorId = new SelectList(await GetVendor(), "VendorId", "VendorName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrder(OrderModel ob)
        {
            var orderId = 0;
            ob.UserId = objSessionManager.UserID;
            string url = StVariable.ApiUri + "/api/Order/SaveOrder";
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result.Replace("\"", "").Split('|');
                    if (responseData[1] == "")
                    {
                        orderId = Convert.ToInt16(responseData[0]);
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);                       
                    }
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveOrderItem(SaveItemModel ob)
        {     
            ob.UserId = objSessionManager.UserID;
            string url = StVariable.ApiUri + "/api/Order/SaveOrderItem";
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
        public async Task<JsonResult> GetOrder(int VendorId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            try
            {
                string url = StVariable.ApiUri + "/api/Order/GetOrder?Qtype=ALL&VendorId=" + VendorId + "&StoreId=" + StoreId + "&FromDate=" + FromDate + "&Todate=" + Todate;
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
        
        public async Task<ActionResult> OrderItem(int OrderId)
        {
            string url = StVariable.ApiUri + "/api/Order/GetOrderDetail?Qtype=ID&OrderId=" + OrderId;
            OrderModel model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<OrderModel>(responseData);
            }
            return View(model);
        }

        public async Task<JsonResult> GetOrderItem(int OrderId)
        {
            string url = StVariable.ApiUri + "/api/Order/GetOrderDetail?Qtype=ID&OrderId=" + OrderId;           
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