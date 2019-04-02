using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REZInventory
{
    public class StVariable
    {
        private static string _ApiUrl;
        public static string ApiUrl
        {
            get
            {
                return StVariable._ApiUrl;
            }
            set
            {
                StVariable._ApiUrl = value;
            }
        }
        private static string _ApiUri;
        public static string ApiUri
        {
            get
            {
                return StVariable._ApiUri;
            }
            set
            {
                StVariable._ApiUri = value;
            }
        }
    }
}