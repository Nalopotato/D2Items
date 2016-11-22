using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class SkillsEntity : DatabaseEntity<SkillModel>
    {
        public static string GetAll(double ID)
        {
            string query =

                @"SELECT
                    name
                FROM
                    T_Skills
                WHERE
                    ID = @id";

            var cmd = new SqlCommand { Connection = new SqlConnection(D2ConnectionString) };

            cmd.Parameters.Add(new SqlParameter("@id", ID));

            cmd.CommandText = query;
            cmd.Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                string name = "";
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) name = reader.GetString(0);
                }
                cmd.Connection.Close();
                return name;
            }
        }
    }
}