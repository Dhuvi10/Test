using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REZInventory.Common
{
    public class SessionManager
    {
        public int UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                    return 0;
                else
                    return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }
        public string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["UserName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public string RoleName
        {
            get
            {
                if (HttpContext.Current.Session["RoleName"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["RoleName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RoleName"] = value;
            }
        }

        public string UserImage
        {
            get
            {
                if (HttpContext.Current.Session["UserImage"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["UserImage"].ToString();
            }
            set
            {
                HttpContext.Current.Session["UserImage"] = value;
            }
        }

        public int RoleId
        {
            get
            {
                if (HttpContext.Current.Session["RoleId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(HttpContext.Current.Session["RoleId"]);
            }
            set
            {
                HttpContext.Current.Session["RoleId"] = value;
            }
        }





        public int ParentRoleId
        {
            get
            {
                if (HttpContext.Current.Session["ParentRoleId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(HttpContext.Current.Session["ParentRoleId"]);
            }
            set
            {
                HttpContext.Current.Session["ParentRoleId"] = value;
            }
        }

        public int ReportingUserId
        {
            get
            {
                if (HttpContext.Current.Session["ReportingUserId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(HttpContext.Current.Session["ReportingUserId"]);
            }
            set
            {
                HttpContext.Current.Session["ReportingUserId"] = value;
            }
        }
        public string AuthToken
        {
            get
            {
                if (HttpContext.Current.Session["AuthToken"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["AuthToken"].ToString();
            }
            set
            {
                HttpContext.Current.Session["AuthToken"] = value;
            }
        }

    }
}