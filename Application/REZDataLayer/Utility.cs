using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REZServices
{
   public class Utility
    {
        private static int _parentRoleID;
        private static string _userName;
        private static string _connectionString;
        private static string _LoginconnectionString;
        private static System.Globalization.CultureInfo _culture;
        public Utility()
        {

        }
        public static string UserName
        {
            get
            {
                return Utility._userName;
            }
            set
            {
                Utility._userName = value;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return Utility._connectionString;
            }
            set
            {
                Utility._connectionString = value;
            }
        }
        public static string LoginConnectionString
        {
            get
            {
                return Utility._LoginconnectionString;
            }
            set
            {
                Utility._LoginconnectionString = value;
            }
        }
        public static System.Globalization.CultureInfo Culture
        {
            get
            {
                return Utility._culture;
            }
            set
            {
                Utility._culture = value;
            }
        }
        public static int ParentRole
        {
            get
            {
                return Utility._parentRoleID;
            }
            set
            {
                Utility._parentRoleID = value;
            }
        }
    }
}
