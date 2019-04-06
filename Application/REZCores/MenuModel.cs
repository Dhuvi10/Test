using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZCores
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string MenuCode { get; set; }
        public int  ParentId { get; set; }
        public string ActionName { get; set; }
        public int ActionId { get; set; }
        public string TargetUrl { get; set; }
    }
}
