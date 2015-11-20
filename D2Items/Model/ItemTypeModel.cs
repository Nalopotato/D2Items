using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D2Items.Model
{
    public class ItemTypeModel : BaseModel
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public string BaseType { get; set; }
        public override string Label
        {
            get
            {
                return this.Name;
            }
        }
    }
}