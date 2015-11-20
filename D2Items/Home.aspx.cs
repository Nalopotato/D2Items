using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using D2Items.Model;
using D2Items.Entity;

namespace D2Items
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            var Item = new ItemModel();

            Item.Name = nameTB.Text;

            if (levelTB.Text != "") { Item.Lvl = Int32.Parse(levelTB.Text); }
            if (strTB.Text != "") { Item.Str = Int32.Parse(strTB.Text); }
            if (dexTB.Text != "") { Item.Dex = Int32.Parse(dexTB.Text); }
            Item.Ladder = ladderCB.Checked;
            Item.Version = Int32.Parse(versionDDL.SelectedValue);
            Item.Sockets = Int32.Parse(socketsDDL.Text);
            Item.ItemType = itemTypePicker.SelectedText;
            if (classDDL.SelectedIndex != 0) { Item.Dex = Int32.Parse(classDDL.Text); }
            Item.Runes = "a" + runePicker1.SelectedValue + "a" + runePicker2.SelectedValue + "a" + runePicker3.SelectedValue + "a" + runePicker4.SelectedValue + "a" + runePicker5.SelectedValue + "a" + runePicker6.SelectedValue + "a";
            Item.Quality = Int32.Parse(qualityRadioList.SelectedItem.Value);

            ItemsEntity.Create(Item);
        }
    }
}