using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
    public class CommonModel
    {
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
    public class FilterModel
    {
    }

    public class SystemCode
    {
        public int CodeID { get; set; }
        public string CodeName { get; set; }
    }
}
