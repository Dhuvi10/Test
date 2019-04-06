using Newtonsoft.Json;
using REZCores;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace REZInventory.Controllers
{

    public class AccountController : Controller
    {


        HttpClient client;
        public AccountController()
        {
            StVariable.ApiUri = System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString();
            StVariable.ApiUri = System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString();

            client = new HttpClient();
            //client.BaseAddress = new Uri(StVariable.ApiUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Login()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            // var token = ValidateUser(model);
            var jsonString = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(StVariable.ApiUri + "/api/account/Authenticate", content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<LoginResponseModel>(responseData);
               // FormsAuthentication.SetAuthCookie(data.AuthToken, false);
                FormsAuthentication.SetAuthCookie(data.UserName, false);
                //FormsAuthentication.SetAuthCookie(data.RoleID.ToString(), false);
                // FormsAuthentication.SetAuthCookie(data.UserId.ToString(), false);
                Session["AuthToken"] = data.AuthToken;
                Session["UserId"] = data.UserId;
                Session["RoleId"] = data.UserId;
                Response.Cookies.Add(new HttpCookie("AuthToken", data.AuthToken));
                if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return this.Redirect(returnUrl);
                }
                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                this.ModelState.AddModelError(string.Empty, responseData);
                return this.View(model);

            }
        }  


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.UserName = model.Email;
                model.Password = model.EncryptedPassword;
                model.BrandId = "1";
                model.IsActive = true;
                var jsonString = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(StVariable.ApiUri + "/api/account/register", content).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<string>(responseData);
                    if (!string.IsNullOrEmpty(data))
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", data);
                        return View(new RegisterModel());
                    }
                    // model = data[0];
                }
                else
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    //var data = JsonConvert.DeserializeObject<>(responseData);
                    ModelState.AddModelError("", responseData.ToString());
                    return View();

                }
                //responseMessage.Content.er
                //return View();

            }


        }


        public ActionResult LogOff()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Login", "Account");
        }
    }
}