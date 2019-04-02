using DataDefnation.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZServices
{
    public class DLMenu:DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLMenu()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }
        public System.Data.DataSet Menu(int RoleId)
        {
            try
            {
                _sql = "DisplayRoleMenus";
                _parms = new SqlParameter[1];
                _parms[0] = new SqlParameter("@RoleId", SqlDbType.Int);
               _parms[0].Value = RoleId;
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }
        public System.Data.DataSet SubMenu(int MenuId)
        {
            try
            {
                _sql = "LoginUser";
                _parms = new SqlParameter[2];
                _parms[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }
    }
}
