using System;
using System.Web.UI.WebControls;

namespace D2Items.Controls
{
    public class IntRangePicker : DropDownList
    {
        public int Max { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Populate();
        }

        private void Populate()
        {
            this.Items.Add(new ListItem("Select", "0"));

            for (int i = 1; i <= Max; i++)
            {
                this.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}