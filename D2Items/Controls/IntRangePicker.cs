using System;
using System.Web.UI.WebControls;

namespace D2Items.Controls
{
    public class IntRangePicker : DropDownList
    {
        public int Max { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (Items.Count == 0)
            {
                Populate();
            }
        }

        private void Populate()
        {
            //this.Items.Add(new ListItem("Select", "0"));

            for (int i = 0; i <= Max; i++)
            {
                Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}