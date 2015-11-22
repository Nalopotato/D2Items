using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D2Items.Model
{
    public class ModModel : BaseModel
    {
        public string Name { get; set; }

        public override string Label //For populating the DDL with the Name text
        {
            get
            {
                return this.Name;
            }
        }
    }
}