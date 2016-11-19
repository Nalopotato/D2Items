using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class ItemTypeEntity : DatabaseEntity<ItemTypeModel>
    {
        public override List<ItemTypeModel> GetAll(int? ID = null)
        {
            string query =

                @"SELECT
                    ID,
                    name,
                    baseType
                FROM
                    T_SubTypes
                ORDER BY
                    name";

            using (var Connection = new SqlConnection(D2ConnectionString))
            {
                Connection.Open();
                using (var cmd = new SqlCommand(query, Connection))
                {
                    var itemTypes = new List<ItemTypeModel>();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            var itemType = new ItemTypeModel();

                            itemType.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) itemType.Name = reader.GetString(1);
                            if (!reader.IsDBNull(2)) itemType.BaseType = reader.GetString(2);

                            itemTypes.Add(itemType);
                        }
                        cmd.Connection.Close();
                        return itemTypes;
                    }
                }
            }
        }
    }
}