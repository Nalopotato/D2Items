using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;
using D2Items.Entity;

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
                    name";

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
    }
}