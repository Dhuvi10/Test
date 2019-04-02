using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
    public class DLUnit : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;   
        public DLUnit()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveUnitMaster(UnitModel objunit)
        {
            try
            {
                _sql = "SaveUnitMaster";
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

        public System.Data.DataSet DisplayUnitMaster(string Qtype, int UnitId)
        {
            try
            {
                _sql = "DisplayUnitMaster";
                _parms = new SqlParameter[2];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@UnitId", SqlDbType.Int);
                _parms[1].Value = UnitId;  
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch
            {
                throw;
            }
        }     
        
    }
}
