using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<RuneModel> RunesList { get; set; }
        public List<ItemModsModel> ModsList { get; set; }
    }
}