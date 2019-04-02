using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
    public class DLUser : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLUser()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveUser(RegisterModel objunit)
        {
            try
            {
                _sql = "CreateUser";
                _parms = new SqlParameter[10];
                _parms[0] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[0].Value = objunit.UserId;
                _parms[1] = new SqlParameter("@UName", SqlDbType.NVarChar, 100);
                _parms[1].Value = objunit.UserName;
                //_parms[4] = new SqlParameter("@UserID", SqlDbType.Int);
                //_parms[4].Value = objunit.UserId;
                _parms[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
                _parms[2].Value = objunit.IsActive;
              


                _parms[3] = new SqlParameter("@FName", SqlDbType.NVarChar, 100);
                _parms[3].Value = objunit.FirstName;
                _parms[4] = new SqlParameter("@LName", SqlDbType.NVarChar, 100);
                _parms[4].Value = objunit.LastName;

                _parms[5] = new SqlParameter("@PhNo", SqlDbType.NVarChar, 50);
                _parms[5].Value = objunit.PhoneNumber;

                _parms[6] = new SqlParameter("@EmailId", SqlDbType.NVarChar, 50);
                _parms[6].Value = objunit.Email;

                _parms[7] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                _parms[7].Value = objunit.Password;

                _parms[8] = new SqlParameter("@BrandId", SqlDbType.Int);
                _parms[8].Value = objunit.BrandId;
                _parms[9] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[9].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public System.Data.DataSet Login(LoginModel model)
        {
            try
            {
                _sql = "LoginUser";
                _parms = new SqlParameter[2];
                _parms[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                _parms[0].Value = model.UserName;
                _parms[1] = new SqlParameter("@Password", SqlDbType.NVarChar,200);
                _parms[1].Value = model.Password;
                //_parms[2] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                //_parms[2].Direction = ParameterDirection.Output;
                return RunProcedure(_sql , _parms, "Filter");
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }
       
    }
}
