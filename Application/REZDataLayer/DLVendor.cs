using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
   public class DLVendor : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLVendor()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveVendor(UnitModel objunit)
        {
            try
            {
                _sql = "";
                _parms = new SqlParameter[4];
                _parms[0] = new SqlParameter("@UnitId", SqlDbType.Int);
                _parms[0].Value = objunit.UnitId;
                _parms[1] = new SqlParameter("@UnitName", SqlDbType.NVarChar, 50);
                _parms[1].Value = objunit.UnitName;
                //_parms[4] = new SqlParameter("@UserID", SqlDbType.Int);
                //_parms[4].Value = objunit.UserId;
                _parms[2] = new SqlParameter("@ISACTIVE", SqlDbType.Bit);
                _parms[2].Value = objunit.IsActive;
                _parms[3] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[3].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataSet DisplayVendor(string Qtype, int VendorId, int ItemGroupId)
        {
            try
            {
                _sql = "DisplayVendor";
                _parms = new SqlParameter[3];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@VendorId", SqlDbType.Int);
                _parms[1].Value = VendorId;
                _parms[2] = new SqlParameter("@ItemGroupId", SqlDbType.Int);
                _parms[2].Value = ItemGroupId;
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch
            {
                throw;
            }
        }
    }
}
