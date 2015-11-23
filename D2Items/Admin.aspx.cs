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
    public partial class Admin : System.Web.UI.Page
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

                Item.BaseType1 = baseTypePicker1.SelectedText;
                if (baseTypePicker2.SelectedText != "Select") { Item.BaseType2 = baseTypePicker2.SelectedText; }
                if (baseTypePicker3.SelectedText != "Select") { Item.BaseType3 = baseTypePicker3.SelectedText; }

                Item.ItemType = itemTypePicker.SelectedText;
                if (classDDL.SelectedIndex != 0) { Item.Class = classDDL.Text; }
                Item.Runes = "a" + runePicker1.SelectedValue + "a" + runePicker2.SelectedValue + "a" + runePicker3.SelectedValue + "a" + runePicker4.SelectedValue + "a" + runePicker5.SelectedValue + "a" + runePicker6.SelectedValue + "a";
                Item.Quality = Int32.Parse(qualityRadioList.SelectedItem.Value);
                Item.Rarity = Int32.Parse(rarityRadioList.SelectedItem.Value);

                var ItemMod = new ItemModsModel();
                var ItemMods = new List<ItemModsModel>();

                if (modPicker1.Text != "0" && modTB1.Text != "") { ItemMod.Mod = Int32.Parse(modPicker1.Text); ItemMod.ModValue1 = float.Parse(modTB1.Text); if (modTB1a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB1a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker2.Text != "0" && modTB2.Text != "") { ItemMod.Mod = Int32.Parse(modPicker2.Text); ItemMod.ModValue1 = float.Parse(modTB2.Text); if (modTB2a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB2a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker3.Text != "0" && modTB3.Text != "") { ItemMod.Mod = Int32.Parse(modPicker3.Text); ItemMod.ModValue1 = float.Parse(modTB3.Text); if (modTB3a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB3a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker4.Text != "0" && modTB4.Text != "") { ItemMod.Mod = Int32.Parse(modPicker4.Text); ItemMod.ModValue1 = float.Parse(modTB4.Text); if (modTB4a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB4a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker5.Text != "0" && modTB5.Text != "") { ItemMod.Mod = Int32.Parse(modPicker5.Text); ItemMod.ModValue1 = float.Parse(modTB5.Text); if (modTB5a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB5a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker6.Text != "0" && modTB6.Text != "") { ItemMod.Mod = Int32.Parse(modPicker6.Text); ItemMod.ModValue1 = float.Parse(modTB6.Text); if (modTB6a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB6a.Text); }  ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker7.Text != "0" && modTB7.Text != "") { ItemMod.Mod = Int32.Parse(modPicker7.Text); ItemMod.ModValue1 = float.Parse(modTB7.Text); if (modTB7a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB7a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker8.Text != "0" && modTB8.Text != "") { ItemMod.Mod = Int32.Parse(modPicker8.Text); ItemMod.ModValue1 = float.Parse(modTB8.Text); if (modTB8a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB8a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker9.Text != "0" && modTB9.Text != "") { ItemMod.Mod = Int32.Parse(modPicker9.Text); ItemMod.ModValue1 = float.Parse(modTB9.Text); if (modTB9a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB9a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker10.Text != "0" && modTB10.Text != "") { ItemMod.Mod = Int32.Parse(modPicker10.Text); ItemMod.ModValue1 = float.Parse(modTB10.Text); if (modTB10a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB10a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker11.Text != "0" && modTB11.Text != "") { ItemMod.Mod = Int32.Parse(modPicker11.Text); ItemMod.ModValue1 = float.Parse(modTB11.Text); if (modTB11a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB11a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker12.Text != "0" && modTB12.Text != "") { ItemMod.Mod = Int32.Parse(modPicker12.Text); ItemMod.ModValue1 = float.Parse(modTB12.Text); if (modTB12a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB12a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker13.Text != "0" && modTB13.Text != "") { ItemMod.Mod = Int32.Parse(modPicker13.Text); ItemMod.ModValue1 = float.Parse(modTB13.Text); if (modTB13a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB13a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker14.Text != "0" && modTB14.Text != "") { ItemMod.Mod = Int32.Parse(modPicker14.Text); ItemMod.ModValue1 = float.Parse(modTB14.Text); if (modTB14a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB14a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker15.Text != "0" && modTB15.Text != "") { ItemMod.Mod = Int32.Parse(modPicker15.Text); ItemMod.ModValue1 = float.Parse(modTB15.Text); if (modTB15a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB15a.Text); } ItemMods.Add(ItemMod); }
                ItemMod = new ItemModsModel();
                if (modPicker16.Text != "0" && modTB16.Text != "") { ItemMod.Mod = Int32.Parse(modPicker16.Text); ItemMod.ModValue1 = float.Parse(modTB16.Text); if (modTB16a.Text != "") { ItemMod.ModValue2 = float.Parse(modTB16a.Text); } ItemMods.Add(ItemMod); }

                if (ItemsEntity.Create(Item) && ItemsEntity.InstertMods(Item, ItemMods)) {
                    updateLabel1.Text = Item.Name + " has been added to the database";
                    updateLabel1.Visible = true;
                    updateLabel2.Text = Item.Name + " has been added to the database";
                    updateLabel2.Visible = true;

                    nameTB.Text = "";
                    levelTB.Text = "";
                    strTB.Text = "";
                    dexTB.Text = "";
                    classDDL.SelectedIndex = 0;
                    baseTypePicker2.SelectedIndex = 0;
                    baseTypePicker3.SelectedIndex = 0;

                    runePicker1.SelectedIndex = 0;
                    runePicker2.SelectedIndex = 0;
                    runePicker3.SelectedIndex = 0;
                    runePicker4.SelectedIndex = 0;
                    runePicker5.SelectedIndex = 0;
                    runePicker6.SelectedIndex = 0;

                    modPicker1.SelectedIndex = 0; modTB1.Text = ""; modTB1a.Text = "";
                    modPicker2.SelectedIndex = 0; modTB2.Text = ""; modTB2a.Text = "";
                    modPicker3.SelectedIndex = 0; modTB3.Text = ""; modTB3a.Text = "";
                    modPicker4.SelectedIndex = 0; modTB4.Text = ""; modTB4a.Text = "";
                    modPicker5.SelectedIndex = 0; modTB5.Text = ""; modTB5a.Text = "";
                    modPicker6.SelectedIndex = 0; modTB6.Text = ""; modTB6a.Text = "";
                    modPicker7.SelectedIndex = 0; modTB7.Text = ""; modTB7a.Text = "";
                    modPicker8.SelectedIndex = 0; modTB8.Text = ""; modTB8a.Text = "";
                    modPicker9.SelectedIndex = 0; modTB9.Text = ""; modTB9a.Text = "";
                    modPicker10.SelectedIndex = 0; modTB10.Text = ""; modTB10a.Text = "";
                    modPicker11.SelectedIndex = 0; modTB11.Text = ""; modTB11a.Text = "";
                    modPicker12.SelectedIndex = 0; modTB12.Text = ""; modTB12a.Text = "";
                    modPicker13.SelectedIndex = 0; modTB13.Text = ""; modTB13a.Text = "";
                    modPicker14.SelectedIndex = 0; modTB14.Text = ""; modTB14a.Text = "";
                    modPicker15.SelectedIndex = 0; modTB15.Text = ""; modTB15a.Text = "";
                    modPicker16.SelectedIndex = 0; modTB16.Text = ""; modTB16a.Text = "";

                    nameTB.Focus();
                }
            }
        }
    }
}