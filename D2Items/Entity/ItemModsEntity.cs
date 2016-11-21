using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class ItemModsEntity : DatabaseEntity<ItemModsModel>
    {
        public static List<ItemModsModel> GetAll(int ID)
        {
            string query =

                @"SELECT
                    im.ID,
                    m.name,
                    modID,
                    itemID,
                    value1,
                    value2,
                    skill
                FROM
                    T_ItemMods im INNER JOIN T_Mods m
                        ON im.modID = m.ID
                WHERE
                    itemID = @id";

            var cmd = new SqlCommand { Connection = new SqlConnection(D2ConnectionString) };

            cmd.Parameters.Add(new SqlParameter("@id", ID));

            cmd.CommandText = query;
            cmd.Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                var itemMods = new List<ItemModsModel>();
                while (reader.Read())
                {
                    var itemMod = new ItemModsModel();
                    if (!reader.IsDBNull(0)) itemMod.ID = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) itemMod.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) itemMod.ModID = reader.GetInt32(2);
                    if (!reader.IsDBNull(3)) itemMod.ItemID = reader.GetInt32(3);
                    if (!reader.IsDBNull(4)) itemMod.ModValue1 = reader.GetDouble(4);
                    if (!reader.IsDBNull(5)) itemMod.ModValue2 = reader.GetDouble(5);
                    if (!reader.IsDBNull(6)) itemMod.Skill = reader.GetString(6);
                    itemMods.Add(itemMod);
                }
                cmd.Connection.Close();
                return itemMods;
            }
        }
    }
}