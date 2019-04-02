using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
  public  class DLStockTaken : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLStockTaken()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveStockTaken(StockTakenModel ob)
        {
            try
            {
                _sql = "SaveStockTaken";
                _parms = new SqlParameter[9];
                _parms[0] = new SqlParameter("@StockTakingId", SqlDbType.Int);
                _parms[0].Value = ob.StockTakingId;
                _parms[1] = new SqlParameter("@StoreId", SqlDbType.Int);
                _parms[1].Value = ob.StoreId;            
                _parms[2] = new SqlParameter("@BDate", SqlDbType.DateTime);
                _parms[2].Value = ob.BDate;
                _parms[3] = new SqlParameter("@InventoryTime", SqlDbType.Int);
                _parms[3].Value = ob.InventoryTime;
                _parms[4] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[4].Value = ob.Status;
                _parms[5] = new SqlParameter("@StocktakingTypeId", SqlDbType.Int);
                _parms[5].Value = ob.StocktakingTypeId;
                _parms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[6].Value = ob.UserId;
                _parms[7] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[7].Value = ob.strCountSheetModel;
                _parms[8] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[8].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
      
        public System.Data.DataSet DisplayStockTaken(string Qtype, int StockTakingId,int StocktakingTypeId,int StoreId, DateTime FromDate,DateTime Todate)
        {
            try
            {
                _sql = "DisplayStockTaken";
                _parms = new SqlParameter[6];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@StockTakingId", SqlDbType.Int);
                _parms[1].Value = StockTakingId;
                _parms[2] = new SqlParameter("@StocktakingTypeId", SqlDbType.Int);
                _parms[2].Value = StocktakingTypeId;
                _parms[3] = new SqlParameter("@StoreId", SqlDbType.Int);
                _parms[3].Value = StoreId;
                _parms[4] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                _parms[4].Value = FromDate;
                _parms[5] = new SqlParameter("@Todate", SqlDbType.DateTime);
                _parms[5].Value = Todate;
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch
            {
                throw;
            }
        }

    }
}
