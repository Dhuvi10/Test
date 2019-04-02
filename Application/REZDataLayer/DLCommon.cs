using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
   public class DLCommon : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLCommon()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }   

        public DataSet DisplaySystemCode(string Qtype,int CodeTypeId, int CodeID)
        {
            try
            {
                _sql = "DisplaySystemCode";
                _parms = new SqlParameter[3];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@CodeTypeId", SqlDbType.Int);
                _parms[1].Value = CodeTypeId;
                _parms[2] = new SqlParameter("@CodeID", SqlDbType.Int);
                _parms[2].Value = CodeID;
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch
            {
                throw;
            }
        }



    }
}
