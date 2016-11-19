using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class RunesEntity : DatabaseEntity<RuneModel>
    {
        public override List<RuneModel> GetAll(int? ID = null)
        {
            string query =

                @"SELECT
                    ID,
                    name
                FROM
                    T_Runes";

            using (var Connection = new SqlConnection(D2ConnectionString))
            {
                Connection.Open();
                using (var cmd = new SqlCommand(query, Connection))
                {
                    var runes = new List<RuneModel>();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            var rune = new RuneModel();
                            rune.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) rune.Name = reader.GetString(1);
                            runes.Add(rune);
                        }
                        cmd.Connection.Close();
                        return runes;
                    }
                }
            }
        }
    }
}