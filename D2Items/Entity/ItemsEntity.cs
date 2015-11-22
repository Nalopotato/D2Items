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
            baseType1,
            baseType2,
            baseType3,
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
            @baseType1,
            @baseType2,
            @baseType3,
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
                    cmd.Parameters.Add(new SqlParameter("@baseType1", Item.BaseType1));
                    cmd.Parameters.Add(new SqlParameter("@baseType2", Item.BaseType2));
                    cmd.Parameters.Add(new SqlParameter("@baseType3", Item.BaseType3));
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
                    var recordsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return recordsAffected == 1;
                }
            }
        }

        public static bool CreateMods(ItemModel Item, List<ItemModsModel> ItemMods)
        {
            int count = 0;
            int recordsAffected = 0;
            object itemID;
            
            string query = @"SELECT ID FROM T_Items WHERE name = '" + Item.Name + "'";

            using (var connection = new SqlConnection(D2ConnectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    ConvertNullsToDBNulls(cmd.Parameters);
                    itemID = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                }
            }

            foreach (ItemModsModel ItemMod in ItemMods)
            {
                query = @"INSERT INTO

                T_ItemMods (
                    modID,
                    itemID,
                    value
                )
                VALUES (
                    @modID" + count + @",
                    @itemID" + count + @",
                    @value" + count + @"
                )";

                using (var connection = new SqlConnection(D2ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@itemID" + count, itemID));
                        cmd.Parameters.Add(new SqlParameter("@modID" + count, ItemMod.Mod));
                        cmd.Parameters.Add(new SqlParameter("@value" + count, ItemMod.ModValue));

                        ConvertNullsToDBNulls(cmd.Parameters);
                        recordsAffected = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        count++;
                    }
                }
            }

            return recordsAffected == 1;
        }
    }
}