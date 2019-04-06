using REZCores;
using REZServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZRepository
{
    public class BLMenu
    {
        DLMenu menu = new DLMenu();
        public List<MenuModel> Menu(int RoleId)
        {
            List<MenuModel> menuList = new List<MenuModel>();
            var dt = menu.Menu(RoleId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                menuList = dt.AsEnumerable().Select(x => new MenuModel
                {
                    Id = x.Field<int>("MenuId"),
                    Name = x.Field<string>("MenuName"),
                    ParentId = x.Field<int>("ParentMenuId"),
                    MenuCode = x.Field<string>("MenuCode"),
                    ActionId = x.Field<int>("ActionId"),
                    ActionName = x.Field<string>("ActionName"),
                    TargetUrl = x.Field<string>("TargetURL"),
                }).ToList();
                
            }
            return menuList;
        }
        
       
    }
}
