using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REZCores;
using REZServices;
namespace REZRepository
{
  public class BLCommon
    {
        DLCommon obj = new DLCommon();   
        public List<SystemCode> DDLSystemCode(int CodeTypeId)
        {
            List<SystemCode> objlist = new List<SystemCode>();
            var dt = obj.DisplaySystemCode("DDL", CodeTypeId, 0).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objlist = dt.AsEnumerable().Select(x => new SystemCode
                {
                    CodeID = x.Field<int>("CodeID"),
                    CodeName = x.Field<string>("CodeName")
                }).ToList();
            }
            return objlist;
        }
    }
}
