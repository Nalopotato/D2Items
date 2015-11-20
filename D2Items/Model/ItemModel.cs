﻿using System;
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
        public string ItemType { get; set; }
        public string Runes { get; set; }
        public int Quality { get; set; }
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