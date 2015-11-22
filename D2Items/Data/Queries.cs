using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace D2Items
{
    public class Queries
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["D2ConnectionString"].ConnectionString;
        }
    }
}