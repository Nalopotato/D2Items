using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;
using D2Items.Entity;

namespace D2Items.Entity
{
    public class ItemsEntity : DatabaseEntity<ItemModel>
    {
        public static bool Create(ItemModel Item)
        {
            const string query = @"INSERT INTO
        T_Items (
            name,
            itemType,
            runes,
            quality,
            lvl,
            str,
            dex,
            sockets,
            version,
            ladder,
            class
        )
        VALUES (
            @name,
            @itemType,
            @runes,
            @quality,
            @lvl,
            @str,
            @dex,
            @sockets,
            @version,
            @ladder,
            @class
        )";

            using (var connection = new SqlConnection(D2ConnectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@name", Item.Name));
                    cmd.Parameters.Add(new SqlParameter("@itemType", Item.ItemType));
                    cmd.Parameters.Add(new SqlParameter("@runes", Item.Runes));
                    cmd.Parameters.Add(new SqlParameter("@quality", Item.Quality));
                    cmd.Parameters.Add(new SqlParameter("@lvl", Item.Lvl));
                    cmd.Parameters.Add(new SqlParameter("@str", Item.Str));
                    cmd.Parameters.Add(new SqlParameter("@dex", Item.Dex));
                    cmd.Parameters.Add(new SqlParameter("@sockets", Item.Sockets));
                    cmd.Parameters.Add(new SqlParameter("@version", Item.Version));
                    cmd.Parameters.Add(new SqlParameter("@ladder", Item.Ladder));
                    cmd.Parameters.Add(new SqlParameter("@class", Item.Class));

                    ConvertNullsToDBNulls(cmd.Parameters);
                    int recordsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return recordsAffected == 1;
                }
            }
        }
    }
}