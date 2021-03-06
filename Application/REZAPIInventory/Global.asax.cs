﻿using REZServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace REZAPIInventory
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Utility.ConnectionString = ConfigurationManager.ConnectionStrings["REZLoginConn"].ConnectionString;
        }
    }
}
