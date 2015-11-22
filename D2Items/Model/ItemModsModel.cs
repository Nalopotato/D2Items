using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D2Items.Model
{
    public class ItemModsModel : BaseModel
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public int Mod { get; set; }
        public int ModValue { get; set; }

        public override string Label
        {
            get
            {
                return (this.Name);
            }
        }    
    }
}