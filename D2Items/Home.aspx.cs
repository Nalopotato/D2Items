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
            if (!Page.IsPostBack)
            {
                nameTB.Text = "";
                baseTypePicker1.SelectedIndex = 0;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            var Item = new ItemModel();

            if (nameTB.Text != "" && baseTypePicker1.Text != "0")
            {
                Item.Name = nameTB.Text;

                if (levelTB.Text != "") { Item.Lvl = Int32.Parse(levelTB.Text); }
                if (strTB.Text != "") { Item.Str = Int32.Parse(strTB.Text); }
                if (dexTB.Text != "") { Item.Dex = Int32.Parse(dexTB.Text); }
                Item.Ladder = ladderCB.Checked;
                Item.Version = Int32.Parse(versionDDL.SelectedValue);
                Item.Sockets = Int32.Parse(socketsDDL.Text);

                Item.BaseType1 = baseTypePicker1.Text;
                if (baseTypePicker2.Text != "Select") { Item.BaseType2 = baseTypePicker2.Text; }
                if (baseTypePicker3.Text != "Select") { Item.BaseType3 = baseTypePicker3.Text; }

                Item.ItemType = itemTypePicker.SelectedText;
                if (classDDL.SelectedIndex != 0) { Item.Dex = Int32.Parse(classDDL.Text); }
                Item.Runes = "a" + runePicker1.SelectedValue + "a" + runePicker2.SelectedValue + "a" + runePicker3.SelectedValue + "a" + runePicker4.SelectedValue + "a" + runePicker5.SelectedValue + "a" + runePicker6.SelectedValue + "a";
                Item.Quality = Int32.Parse(qualityRadioList.SelectedItem.Value);

                var ItemMod = new ItemModsModel();
                var ItemMods = new List<ItemModsModel>();

                if (modPicker1.Text != "0" && modTB1.Text != "") { ItemMod.Mod = Int32.Parse(modPicker1.Text); ItemMod.ModValue = Int32.Parse(modTB1.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB2.Text != "") { ItemMod.Mod = Int32.Parse(modPicker2.Text); ItemMod.ModValue = Int32.Parse(modTB2.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB3.Text != "") { ItemMod.Mod = Int32.Parse(modPicker3.Text); ItemMod.ModValue = Int32.Parse(modTB3.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB4.Text != "") { ItemMod.Mod = Int32.Parse(modPicker4.Text); ItemMod.ModValue = Int32.Parse(modTB4.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB5.Text != "") { ItemMod.Mod = Int32.Parse(modPicker5.Text); ItemMod.ModValue = Int32.Parse(modTB5.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB6.Text != "") { ItemMod.Mod = Int32.Parse(modPicker6.Text); ItemMod.ModValue = Int32.Parse(modTB6.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB7.Text != "") { ItemMod.Mod = Int32.Parse(modPicker7.Text); ItemMod.ModValue = Int32.Parse(modTB7.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB8.Text != "") { ItemMod.Mod = Int32.Parse(modPicker8.Text); ItemMod.ModValue = Int32.Parse(modTB8.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB9.Text != "") { ItemMod.Mod = Int32.Parse(modPicker9.Text); ItemMod.ModValue = Int32.Parse(modTB9.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB10.Text != "") { ItemMod.Mod = Int32.Parse(modPicker10.Text); ItemMod.ModValue = Int32.Parse(modTB10.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB11.Text != "") { ItemMod.Mod = Int32.Parse(modPicker11.Text); ItemMod.ModValue = Int32.Parse(modTB11.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB12.Text != "") { ItemMod.Mod = Int32.Parse(modPicker12.Text); ItemMod.ModValue = Int32.Parse(modTB12.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB13.Text != "") { ItemMod.Mod = Int32.Parse(modPicker13.Text); ItemMod.ModValue = Int32.Parse(modTB13.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB14.Text != "") { ItemMod.Mod = Int32.Parse(modPicker14.Text); ItemMod.ModValue = Int32.Parse(modTB14.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB15.Text != "") { ItemMod.Mod = Int32.Parse(modPicker15.Text); ItemMod.ModValue = Int32.Parse(modTB15.Text); ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker1.Text != "0" && modTB16.Text != "") { ItemMod.Mod = Int32.Parse(modPicker16.Text); ItemMod.ModValue = Int32.Parse(modTB16.Text); ItemMods.Add(ItemMod); }

                if (ItemsEntity.Create(Item) && ItemsEntity.CreateMods(Item, ItemMods)) {
                    updateLabel1.Text = Item.Name + " has been added to the database";
                    updateLabel1.Visible = true;
                    updateLabel2.Text = Item.Name + " has been added to the database";
                    updateLabel2.Visible = true;
                }
            }
        }
    }
}