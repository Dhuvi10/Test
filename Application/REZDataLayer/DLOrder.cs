using DataDefnation.DAL;
using REZCores;
using System;
using System.Data;
using System.Data.SqlClient;

namespace REZServices
{
   public class DLOrder : DataAccess
    {
        private string _sql;
        private SqlParameter[] _parms;
        public static SqlConnection con = null;
        public DLOrder()
            : base(Utility.ConnectionString)
        {
            _sql = null;
        }

        public string SaveOrder(OrderModel ob)
        {
            try
            {
                _sql = "SaveOrder";
                _parms = new SqlParameter[10];
                _parms[0] = new SqlParameter("@OrderId", SqlDbType.Int);
                _parms[0].Value = ob.OrderId;
                _parms[1] = new SqlParameter("@StoreId", SqlDbType.Int);
                _parms[1].Value = ob.StoreId;
                _parms[2] = new SqlParameter("@BDate", SqlDbType.DateTime);
                _parms[2].Value = ob.BDate;
                _parms[3] = new SqlParameter("@OrderNo", SqlDbType.NVarChar);
                _parms[3].Value = ob.OrderNo;
                _parms[4] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[4].Value = ob.Status;
                _parms[5] = new SqlParameter("@VendorId", SqlDbType.Int);
                _parms[5].Value = ob.VendorId;
                _parms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[6].Value = ob.UserId;
                _parms[7] = new SqlParameter("@Reference", SqlDbType.NVarChar);
                _parms[7].Value = ob.Reference;
                _parms[8] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[8].Value = ob.strOrderItemModel;
                _parms[9] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[9].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string SaveOrderItem(SaveItemModel ob)
        {
            try
            {
                _sql = "SaveOrderItem";
                _parms = new SqlParameter[5];
                _parms[0] = new SqlParameter("@OrderId", SqlDbType.Int);
                _parms[0].Value = ob.OrderId;               
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

        public string SaveReceiving(OrderModel ob)
        {
            try
            {
                _sql = "SaveRecieving";
                _parms = new SqlParameter[8];
                _parms[0] = new SqlParameter("@OrderId", SqlDbType.Int);
                _parms[0].Value = ob.OrderId;         
                _parms[1] = new SqlParameter("@BDate", SqlDbType.DateTime);
                _parms[1].Value = ob.BDate;
                _parms[2] = new SqlParameter("@ReceiptNo", SqlDbType.NVarChar);
                _parms[2].Value = ob.ReceiptNo;
                _parms[3] = new SqlParameter("@Status", SqlDbType.Int);
                _parms[3].Value = ob.Status;             
                _parms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                _parms[4].Value = ob.UserId;
                _parms[5] = new SqlParameter("@Reference", SqlDbType.NVarChar);
                _parms[5].Value = ob.Reference;
                _parms[6] = new SqlParameter("@ListData", SqlDbType.NVarChar);
                _parms[6].Value = ob.strOrderItemModel;
                _parms[7] = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 1000);
                _parms[7].Direction = ParameterDirection.Output;
                return Convert.ToString(RunProcedure(_sql, "@ReturnValue", _parms));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public System.Data.DataSet DisplayOrder(string Qtype, int OrderId, int VendorId, int StoreId, DateTime FromDate, DateTime Todate)
        {
            try
            {
                _sql = "DisplayOrder";
                _parms = new SqlParameter[6];
                _parms[0] = new SqlParameter("@Qtype", SqlDbType.NVarChar, 50);
                _parms[0].Value = Qtype;
                _parms[1] = new SqlParameter("@OrderId", SqlDbType.Int);
                _parms[1].Value = OrderId;
                _parms[2] = new SqlParameter("@VendorId", SqlDbType.Int);
                _parms[2].Value = VendorId;
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
