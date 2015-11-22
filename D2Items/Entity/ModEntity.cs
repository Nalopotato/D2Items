using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;
using D2Items.Entity;

namespace D2Items.Entity
{
    public class ModEntity : DatabaseEntity<ModModel>
    {
        public override List<ModModel> GetAll(int? ID = null)
        {
            string query =

                @"SELECT
                    ID,
                    name
                FROM
                    T_Mods
                ORDER BY
                    name";

            using (var Connection = new SqlConnection(D2ConnectionString))
            {
                Connection.Open();
                using (var cmd = new SqlCommand(query, Connection))
                {
                    var mods = new List<ModModel>();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            var mod = new ModModel();
                            mod.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) mod.Name = reader.GetString(1);
                            mods.Add(mod);
                        }
                        cmd.Connection.Close();
                        return mods;
                    }
                }
            }
        }
    }
}