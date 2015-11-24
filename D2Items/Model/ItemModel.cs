using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D2Items.Model
{
    public class ItemModel : BaseModel
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public bool Ladder { get; set; }
        public int Version { get; set; }
        public int Sockets { get; set; }
        public string BaseType1 { get; set; }
        public string BaseType2 { get; set; }
        public string BaseType3 { get; set; }
        public string ItemType { get; set; }
        public string Rune1 { get; set; }
        public string Rune2 { get; set; }
        public string Rune3 { get; set; }
        public string Rune4 { get; set; }
        public string Rune5 { get; set; }
        public string Rune6 { get; set; }
        public int Quality { get; set; }
        public int Rarity { get; set; }
        public string Class { get; set; }

        public override string Label
        {
            get
            {
                return this.Name;
            }
        }        
    }
}