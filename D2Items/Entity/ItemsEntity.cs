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
        public static List<ItemModel> Get(ItemFetchModel Item)
        {
            List<ItemModel> Items = new List<ItemModel>();

            string query =
@"SELECT
    ID,
    name,
    baseType1,
    rune1,
    rune2,
    rune3,
    rune4,
    rune5,
    rune6,
    lvl,
    str,
    dex,
    class
FROM 
    T_Items
WHERE 
    {0}
    lvl >= @minLvl AND
    lvl <= @maxLVL AND
    str >= @minStr AND
    str <= @maxStr AND
    dex >= @minDex AND
    dex <= @maxDex AND
    {1}
    {2}
    rarity = @rarity";

            var cmd = new SqlCommand { Connection = new SqlConnection(D2ConnectionString) };

            string nameFilter = "";
            string baseTypeFilter = "";
            string classFilter = "";

            if (Item.Name != "")
            {
                nameFilter = "name LIKE '%@name%' AND";
                cmd.Parameters.Add(new SqlParameter("@name", Item.Name));
            }

            if (Item.BaseType != null)
            {
                baseTypeFilter = "baseType1 LIKE '%@baseType%' AND";
                cmd.Parameters.Add(new SqlParameter("@baseType", Item.BaseType));
            }

            if (Item.Class != null)
            {
                classFilter = "class = @class AND";
                cmd.Parameters.Add(new SqlParameter("@class", Item.Class));
            }

            cmd.Parameters.Add(new SqlParameter("@minLvl", Item.MinLvl));
            cmd.Parameters.Add(new SqlParameter("@maxLvl", Item.MaxLvl));
            cmd.Parameters.Add(new SqlParameter("@minStr", Item.MinStr));
            cmd.Parameters.Add(new SqlParameter("@maxStr", Item.MaxStr));
            cmd.Parameters.Add(new SqlParameter("@minDex", Item.MinDex));
            cmd.Parameters.Add(new SqlParameter("@maxDex", Item.MaxDex));

            cmd.Parameters.Add(new SqlParameter("@rune1", Item.Rune1));
            cmd.Parameters.Add(new SqlParameter("@rune2", Item.Rune2));
            cmd.Parameters.Add(new SqlParameter("@rune3", Item.Rune3));
            cmd.Parameters.Add(new SqlParameter("@rune4", Item.Rune4));

            //cmd.Parameters.Add(new SqlParameter("@ladder", Item.Ladder));
            cmd.Parameters.Add(new SqlParameter("@rarity", Item.Rarity));
            //cmd.Parameters.Add(new SqlParameter("@quality", Item.Quality));

            query = String.Format(query, nameFilter, baseTypeFilter, classFilter);

            cmd.CommandText = query;
            cmd.Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                var items = new List<ItemModel>();
                while (reader.Read())
                {
                    var item = new ItemModel();
                    //item.ID = ID;
                    if (!reader.IsDBNull(0)) item.ID = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) item.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) item.BaseType1 = reader.GetString(2);
                    if (!reader.IsDBNull(3)) item.Rune1 = reader.GetString(3);
                    if (!reader.IsDBNull(3)) item.Rune2 = reader.GetString(3);
                    if (!reader.IsDBNull(3)) item.Rune3 = reader.GetString(3);
                    if (!reader.IsDBNull(3)) item.Rune4 = reader.GetString(3);
                    if (!reader.IsDBNull(3)) item.Rune5 = reader.GetString(3);
                    if (!reader.IsDBNull(3)) item.Rune6 = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.Lvl = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) item.Str = reader.GetInt32(5);
                    if (!reader.IsDBNull(6)) item.Dex = reader.GetInt32(6);
                    if (!reader.IsDBNull(6)) item.Ladder = reader.GetBoolean(6);
                    if (!reader.IsDBNull(6)) item.Class = reader.GetString(6);
                    items.Add(item);
                }
                cmd.Connection.Close();
                return items;
            }
        }

        public static bool Create(ItemModel Item)
        {
            const string query = @"INSERT INTO
        T_Items (
            name,
            baseType1,
            baseType2,
            baseType3,
            itemType,
            rune1,
            rune2,
            rune3,
            rune4,
            rune5,
            rune6,
            quality,
            rarity,
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
            @rune1,
            @rune2,
            @rune3,
            @rune4,
            @rune5,
            @rune6,
            @quality,
            @rarity,
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
                    cmd.Parameters.Add(new SqlParameter("@rune1", Item.Rune1));
                    cmd.Parameters.Add(new SqlParameter("@rune2", Item.Rune2));
                    cmd.Parameters.Add(new SqlParameter("@rune3", Item.Rune3));
                    cmd.Parameters.Add(new SqlParameter("@rune4", Item.Rune4));
                    cmd.Parameters.Add(new SqlParameter("@rune5", Item.Rune5));
                    cmd.Parameters.Add(new SqlParameter("@rune6", Item.Rune6));
                    cmd.Parameters.Add(new SqlParameter("@quality", Item.Quality));
                    cmd.Parameters.Add(new SqlParameter("@rarity", Item.Rarity));
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

        public static bool InstertMods(ItemModel Item, List<ItemModsModel> ItemMods)
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
                    value1,
                    value2
                )
                VALUES (
                    @modID" + count + @",
                    @itemID" + count + @",
                    @value1" + count + @",
                    @value2" + count + @"
                )";

                using (var connection = new SqlConnection(D2ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@itemID" + count, itemID));
                        cmd.Parameters.Add(new SqlParameter("@modID" + count, ItemMod.ModID));
                        cmd.Parameters.Add(new SqlParameter("@value1" + count, ItemMod.ModValue1));
                        cmd.Parameters.Add(new SqlParameter("@value2" + count, ItemMod.ModValue2));

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