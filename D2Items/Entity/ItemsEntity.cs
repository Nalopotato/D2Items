using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using D2Items.Model;

namespace D2Items.Entity
{
    public class ItemsEntity : DatabaseEntity<ItemModel>
    {
        public static List<ItemModel> Get(ItemFetchModel Item)
        {
            List<ItemModel> Items = new List<ItemModel>();

            string query =
@"SELECT
    i.ID,
    i.name,
    i.baseType1,
    i.baseType2,
    i.baseType3,
    rune1,
    rune2,
    rune3,
    rune4,
    rune5,
    rune6,
    lvl,
    str,
    dex,
    sockets,
    ladder,
    class
FROM 
    T_Items i INNER JOIN T_ItemTypes it
        ON i.ID = it.itemID
            INNER JOIN T_BaseTypes bt
                ON it.baseTypeID = bt.ID
WHERE 
    {0}
    {1}
    {2}
    {3}
    {4}
    {5}
    lvl >= @minLvl AND
    lvl <= @maxLvl AND
    str >= @minStr AND
    str <= @maxStr AND
    dex >= @minDex AND
    dex <= @maxDex AND
    rarity = @rarity
ORDER BY
    lvl DESC";

            var cmd = new SqlCommand { Connection = new SqlConnection(D2ConnectionString) };

            string nameFilter = "";
            string baseTypeFilter = "";
            string classFilter = "";
            string runeFilter = "";
            string ladderFilter = "";
            string socketsFilter = "";

            if (Item.Name != "")
            {
                nameFilter = "name LIKE '%@name%' AND";
                cmd.Parameters.Add(new SqlParameter("@name", Item.Name));
            }

            if (Item.BaseType != null)
            {
                if (Item.BaseType == "Weapons")
                {
                    baseTypeFilter = "bt.name = 'Weapons' OR bt.isMelee = 1 OR bt.name LIKE '%Missile%'";
                }
                else if (Item.BaseType == "Melee Weapons")
                {
                    baseTypeFilter = "bt.name = 'Weapons' OR bt.isMelee = 1";
                }
                else
                {
                    baseTypeFilter = "bt.name LIKE '%'+@baseType+'%' AND";
                    cmd.Parameters.Add(new SqlParameter("@baseType", Item.BaseType));
                }
            }

            if (Item.Class != null)
            {
                classFilter = "class = @class AND";
                cmd.Parameters.Add(new SqlParameter("@class", Item.Class));
            }

            if (Item.Rune1 != null)
            {
                runeFilter += "((rune1 = @rune1 OR rune2 = @rune1 OR rune3 = @rune1 OR rune4 = @rune1 OR rune5 = @rune1 OR rune6 = @rune1)";
                cmd.Parameters.Add(new SqlParameter("@rune1", Item.Rune1));
            }
            if (Item.Rune2 != null)
            {
                runeFilter += " AND (rune1 = @rune2 OR rune2 = @rune2 OR rune3 = @rune2 OR rune4 = @rune2 OR rune5 = @rune2 OR rune6 = @rune2)";
                cmd.Parameters.Add(new SqlParameter("@rune2", Item.Rune2));
            }
            if (Item.Rune3 != null)
            {
                runeFilter += " AND (rune1 = @rune3 OR rune2 = @rune3 OR rune3 = @rune3 OR rune4 = @rune3 OR rune5 = @rune3 OR rune6 = @rune3)";
                cmd.Parameters.Add(new SqlParameter("@rune3", Item.Rune3));
            }
            if (Item.Rune4 != null)
            {
                runeFilter += " AND (rune1 = @rune4 OR rune2 = @rune4 OR rune3 = @rune4 OR rune4 = @rune4 OR rune5 = @rune4 OR rune6 = @rune4)";
                cmd.Parameters.Add(new SqlParameter("@rune4", Item.Rune4));
            }
            if (runeFilter != "") { runeFilter += ") AND"; }

            if (Item.Ladder == true) { ladderFilter = "ladder = 'true' AND"; }

            if (Item.Sockets > 0)
            {
                socketsFilter = "sockets = @sockets AND";
                cmd.Parameters.Add(new SqlParameter("@sockets", Item.Sockets));
            }

            cmd.Parameters.Add(new SqlParameter("@minLvl", Item.MinLvl));
            cmd.Parameters.Add(new SqlParameter("@maxLvl", Item.MaxLvl));
            cmd.Parameters.Add(new SqlParameter("@minStr", Item.MinStr));
            cmd.Parameters.Add(new SqlParameter("@maxStr", Item.MaxStr));
            cmd.Parameters.Add(new SqlParameter("@minDex", Item.MinDex));
            cmd.Parameters.Add(new SqlParameter("@maxDex", Item.MaxDex));
            cmd.Parameters.Add(new SqlParameter("@rarity", Item.Rarity));
            //cmd.Parameters.Add(new SqlParameter("@quality", Item.Quality));

            query = String.Format(query, nameFilter, baseTypeFilter, classFilter, runeFilter, ladderFilter, socketsFilter);

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
                    if (!reader.IsDBNull(3)) item.BaseType2 = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.BaseType3 = reader.GetString(4);
                    if (!reader.IsDBNull(5)) item.Rune1 = reader.GetString(5);
                    if (!reader.IsDBNull(6)) item.Rune2 = reader.GetString(6);
                    if (!reader.IsDBNull(7)) item.Rune3 = reader.GetString(7);
                    if (!reader.IsDBNull(8)) item.Rune4 = reader.GetString(8);
                    if (!reader.IsDBNull(9)) item.Rune5 = reader.GetString(9);
                    if (!reader.IsDBNull(10)) item.Rune6 = reader.GetString(10);
                    if (!reader.IsDBNull(11)) item.Lvl = reader.GetInt32(11);
                    if (!reader.IsDBNull(12)) item.Str = reader.GetInt32(12);
                    if (!reader.IsDBNull(13)) item.Dex = reader.GetInt32(13);
                    if (!reader.IsDBNull(14)) item.Sockets = reader.GetInt32(14);
                    if (!reader.IsDBNull(15)) item.Ladder = reader.GetBoolean(15);
                    if (!reader.IsDBNull(16)) item.Class = reader.GetString(16);
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