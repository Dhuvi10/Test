using Newtonsoft.Json;
using REZCores;
using REZInventory.Common;
using REZInventory.Filters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace REZInventory.Controllers
{
    public class UnitController : BaseController
    {
        HttpClient client;
        SessionManager objSessionManager = new SessionManager();
        public UnitController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
        }
    [CustomAuthorized("M00001")]
        public async Task<ActionResult> Index()
        {
            // client.DefaultRequestHeaders.Authorization  = new AuthenticationHeaderValue("Bearer", objSessionManager.AuthToken);
            string url = StVariable.ApiUri + "/api/Unit/getunit?Qtype=All&UnitId=0";
            List<UnitModel> model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<UnitModel>>(responseData);
            }
            // return Json(order);

            return View(model);
        }
        [CustomAuthorized("M00001")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(UnitModel ob)
        {
            string url = StVariable.ApiUri + "/api/Unit/SaveUnit";
            if (ModelState.IsValid)
            {  
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;                   
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            string url = StVariable.ApiUri + "/api/Unit/DisplayStockTakenDetail?Qtype=ID&UnitId=" + id;
            UnitModel model = null;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<UnitModel>>(responseData);
                if (data != null)
                    model = data[0];
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UnitModel ob)
        {
            string url = StVariable.ApiUri + "/api/Unit/SaveUnit";
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ob);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction("Index");
        }
    }
}