using REZCores;
using REZRepository;
using REZServices;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace REZAPIInventory.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        public AccountController()
        {
             Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZLoginConn"].ConnectionString;
        }
        BLUser user = new BLUser();
        [HttpPost]
        [Route("Authenticate")]
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult Authenticate([FromBody] LoginModel model)
        {
           Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZLoginConn"].ConnectionString;

            //bool isUsernamePasswordValid = false;
            var userResponse = user.Login(model);
            // if credentials are valid
            if (userResponse != null && userResponse.UserId != 0)
            {
                userResponse.AuthToken = createToken(userResponse);
                userResponse.ServerName = "";
                userResponse.DbUserName = "";
                userResponse.DbName = "";
                userResponse.Password = "";
                //return the token
                return Ok(userResponse);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                //loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Register")]
        [ResponseType(typeof(RegisterModel))]
        public IHttpActionResult Register(RegisterModel model)
        {
            string str = user.SaveUser(model);
            if (string.IsNullOrEmpty(str))
                return Ok(str);
            else
                return BadRequest(str);
        }

        private string createToken(LoginResponseModel model)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(30);


            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, model.UserName),
               new Claim("UserId",model.UserId.ToString()),
                new Claim("ConnectionString", "Data Source="+model.ServerName+";Initial Catalog="+model.DbName+";user id ="+model.DbUserName+"; password="+model.Password+"")
            });
            Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZLoginConn"].ConnectionString;
            Utility.ConnectionString = "Data Source=" + model.ServerName + ";Initial Catalog=" + model.DbName + ";user id =" + model.DbUserName + "; password=" + model.Password + "";
            // caims.Add(new Claim("desgId", _dtResp.Tables[0].Rows[0]["Designation_Id"].ToString()));

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString(), audience: System.Configuration.ConfigurationManager.AppSettings["APiUri"].ToString(),
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
