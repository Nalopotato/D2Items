using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class BaseTypeEntity : DatabaseEntity<BaseTypeModel>
    {
        public override List<BaseTypeModel> GetAll(int? ID = null)
        {
            string query =

                @"SELECT
                    ID,
                    name
                FROM
                    T_BaseTypes
                ORDER BY
                    name DESC";

            using (var Connection = new SqlConnection(D2ConnectionString))
            {
                Connection.Open();
                using (var cmd = new SqlCommand(query, Connection))
                {
                    var baseTypes = new List<BaseTypeModel>();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            var baseType = new BaseTypeModel();

                            baseType.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) baseType.Name = reader.GetString(1);

                            baseTypes.Add(baseType);
                        }

                        cmd.Connection.Close();
                        return baseTypes;
                    }
                }
            }
        }

        public static int GetID(string name)
        {
            int baseType = 0;
            string select = @"SELECT ID FROM T_BaseTypes WHERE name = @name";

            using (var Connection = new SqlConnection(D2ConnectionString))
            {
                Connection.Open();
                using (var cmd = new SqlCommand(select, Connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            baseType = reader.GetInt32(0);
                        }

                        cmd.Connection.Close();
                        return baseType;
                    }
                }
            }
        }
    }
}