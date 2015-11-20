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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable GetRunes(string runeName)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_Runes", GetConnectionString());
            //da.SelectCommand.Parameters.Add("@name", SqlDbType.Int).Value = runeName;

            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "T_Runes");
            }
            catch (SqlException e)
            {
                // Handle exception.
            }
            finally
            {
                conn.Close();
            }

            if (ds.Tables["T_Runes"] != null)
                return ds.Tables["T_Runes"];

            return null;
        }
    }
}