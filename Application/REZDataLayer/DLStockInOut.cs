using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;
namespace REZServices
{
   public class DLStockInOut : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLStockInOut()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveStockRequest(StockInOutModel ob)
        {
            try
            {
                _sql = "SaveStockRequest";
                _parms = new SqlParameter[9];
                _parms[0] = new SqlParameter("@StockReqId", SqlDbType.Int);
                _parms[0].Value = ob.StockReqId;
                _parms[1] = new SqlParameter("@In_StoreId", SqlDbType.Int);
                _parms[1].Value = ob.In_StoreId;
                _parms[2] = new SqlParameter("@Out_StoreId", SqlDbType.NVarChar);
                _parms[2].Value = ob.Out_StoreId;
                _parms[3] = new SqlParameter("@BDate", SqlDbType.DateTime);
                _parms[3].Value = ob.BDate;               
                _parms[4] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[4].Value = ob.Status;               
                _parms[5] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[5].Value = ob.UserId;
                _parms[6] = new SqlParameter("@Reference", SqlDbType.NVarChar);
                _parms[6].Value = ob.Reference;
                _parms[7] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[7].Value = ob.strStockInOutItemModel;
                _parms[8] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[8].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string SaveStockRequestItem(SaveInOutItemModel ob)
        {
            try
            {
                _sql = "SaveStockRequestItem";
                _parms = new SqlParameter[5];
                _parms[0] = new SqlParameter("@StockReqId", SqlDbType.Int);
                _parms[0].Value = ob.StockReqId;
                _parms[1] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[1].Value = ob.Status;
                _parms[2] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[2].Value = ob.UserId;
                _parms[3] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[3].Value = ob.strOrderItemModel;
                _parms[4] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[4].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string SaveStockTransfer(StockInOutModel ob)
        {
            try
            {
                _sql = "SaveStockTransfer";
                _parms = new SqlParameter[7];
                _parms[0] = new SqlParameter("@StockReqId", SqlDbType.Int);
                _parms[0].Value = ob.StockReqId;
                _parms[1] = new SqlParameter("@BDate", SqlDbType.DateTime);
                _parms[1].Value = ob.BDate;           
                _parms[2] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[2].Value = ob.Status;
                _parms[3] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[3].Value = ob.UserId;
                _parms[4] = new SqlParameter("@Reference", SqlDbType.NVarChar);
                _parms[4].Value = ob.Reference;
                _parms[5] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[5].Value = ob.strStockInOutItemModel;
                _parms[6] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[6].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public DataSet DisplayStockRequest(string Qtype, int StockReqId, int In_StoreId, int Out_StoreId, DateTime FromDate, DateTime Todate)
        {
            try
            {
                _sql = "DisplayStockRequest";
                _parms = new SqlParameter[6];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@StockReqId", SqlDbType.Int);
                _parms[1].Value = StockReqId;
                _parms[2] = new SqlParameter("@In_StoreId", SqlDbType.Int);
                _parms[2].Value = In_StoreId;
                _parms[3] = new SqlParameter("@Out_StoreId", SqlDbType.NVarChar);
                _parms[3].Value = Out_StoreId;
                _parms[4] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                _parms[4].Value = FromDate;
                _parms[5] = new SqlParameter("@Todate", SqlDbType.DateTime);
                _parms[5].Value = Todate;
                return RunProcedure(_sql, _parms, "Filter");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
