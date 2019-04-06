using DataDefnation.DAL;
using REZCores;
using REZServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZRepository
{
    public class BLUser
    {
        DLUser user = new DLUser();
        public string SaveUser(RegisterModel objUser)
        {
            return user.SaveUser(objUser);
        }
        public LoginResponseModel Login(LoginModel model)
        {
            LoginResponseModel response = new LoginResponseModel();
            try
            {
                var dt = user.Login(model).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    response = dt.AsEnumerable().Select(x => new LoginResponseModel
                    {
                        UserName = x.Field<string>("UserName"),
                        UserId = x.Field<int>("UserId"),
                        RoleID = x.Field<int>("RoleID"),
                        ServerName = x.Field<string>("ServerName"),
                        DbName = x.Field<string>("DatabseName"),
                        DbUserName = x.Field<string>("DbUserName"),
                        Password = x.Field<string>("Password"),
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return response;
           // return user.Login(model);
        }
    
    }
}
