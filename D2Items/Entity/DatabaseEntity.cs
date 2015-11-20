using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using D2Items.Model;
using System.Data;
using System.Data.SqlClient;
using Elmah;

namespace D2Items.Entity
{
    public class DatabaseEntity<ModelClass>// where ModelClass : BaseModel, new()
    {
        protected delegate ModelClass ReaderToModelMapper(SqlDataReader Reader);
        protected static string D2ConnectionString = "Data Source=.\\SQLEXPRESS;User Id=d2db;Password=ou812jello;Initial Catalog=D2Items; Application Name=D2 Items; Type System Version=Latest;";
        protected static SqlConnection Connection = new SqlConnection(D2ConnectionString);

        public virtual List<ModelClass> GetAll(int? ID = null)
        {
            throw new NotImplementedException();
        }

        public static void ConvertNullsToDBNulls(SqlParameterCollection Parameters)
        {
            foreach (SqlParameter parameter in Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = System.DBNull.Value;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        protected static List<ModelClass> ExecuteReader(string Query, List<SqlParameter> Parameters, ReaderToModelMapper MappingFunction)
        {
            using (var connection = new SqlConnection(D2ConnectionString))
            {
                using (var cmd = new SqlCommand(Query, connection))
                {
                    var modelClasses = new List<ModelClass>();
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(Parameters.ToArray());
                        ConvertNullsToDBNulls(cmd.Parameters);
                    }
                    try
                    {
                        cmd.Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            while (reader.Read())
                            {
                                modelClasses.Add(MappingFunction(reader));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorSignal.FromCurrentContext().Raise(e);
                    }
                    return modelClasses;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        protected static int ExecuteNonQuery(string Query, List<SqlParameter> Parameters)
        {
            using (var connection = new SqlConnection(D2ConnectionString))
            {
                using (var cmd = new SqlCommand(Query, connection))
                {
                    int rowCount;
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(Parameters.ToArray());
                        ConvertNullsToDBNulls(cmd.Parameters);
                    }
                    try
                    {
                        cmd.Connection.Open();
                        rowCount = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        rowCount = 0;
                        ErrorSignal.FromCurrentContext().Raise(e);
                    }
                    return rowCount;
                }
            }
        }

        protected static string GetSelectStatement(string TableName, string[] Columns)
        {
            string query =
@"SELECT
	{1}
FROM
	{0}";
            return string.Format(
                query,
                TableName
                //GetFormattedColumns(Columns)
            );

        }
    }
}