using System.Collections.Generic;

namespace D2Items.Model
{
    public class ItemFetchModel
    {
        public string Name { get; set; }
        public int MinLvl { get; set; }
        public int MaxLvl { get; set; }
        public int MinStr { get; set; }
        public int MaxStr { get; set; }
        public int MinDex { get; set; }
        public int MaxDex { get; set; }
        public bool Ladder { get; set; }
        public int Version { get; set; }
        public int Sockets { get; set; }
        public string BaseType { get; set; }
        public string ItemType { get; set; }
        public int Quality { get; set; }
        public int Rarity { get; set; }
        public string Class { get; set; }
        public string Rune1 { get; set; }
        public string Rune2 { get; set; }
        public string Rune3 { get; set; }
        public string Rune4 { get; set; }
        public List<ItemModsModel> ModsList { get; set; }
    }
}