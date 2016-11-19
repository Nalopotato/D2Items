using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using D2Items.Model;
using D2Items.Entity;

namespace D2Items
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (rarityRadioList.SelectedIndex == 2)
            {
                qualityPanel.Visible = true;
                runesPanel.Visible = true;
            }
            else
            {
                qualityPanel.Visible = false;
                runesPanel.Visible = false;
            }

            if (Page.IsPostBack == true && ItemList.Visible == true)
            {
                ItemList.Visible = false;
            }
        }

        private void BindData()
        {
            var item = new ItemFetchModel();
            var mod = new ItemModsModel();
            var mods = new List<ItemModsModel>();

            if (runePicker1.SelectedText != "None") { item.Rune1 = runePicker1.SelectedText; }
            if (runePicker2.SelectedText != "None") { item.Rune2 = runePicker2.SelectedText; }
            if (runePicker3.SelectedText != "None") { item.Rune3 = runePicker3.SelectedText; }
            if (runePicker4.SelectedText != "None") { item.Rune4 = runePicker4.SelectedText; }

            mod.ModID = modPicker1.SelectedIndex; mods.Add(mod); mod = new ItemModsModel();
            mod.ModID = modPicker2.SelectedIndex; mods.Add(mod); mod = new ItemModsModel();
            mod.ModID = modPicker3.SelectedIndex; mods.Add(mod); mod = new ItemModsModel();
            mod.ModID = modPicker4.SelectedIndex; mods.Add(mod);

            item.ModsList = mods;

            item.Name = nameTB.Text;
            item.MinLvl = minLvlDDL.SelectedIndex;
            if (maxLvlDDL.SelectedIndex != 0) { item.MaxLvl = maxLvlDDL.SelectedIndex; } else { item.MaxLvl = 99; }
            //item.MaxLvl = maxLvlDDL.SelectedIndex;

            if (minStrTB.Text != "") { item.MinStr = int.Parse(minStrTB.Text); } else { item.MinStr = 0; }
            if (maxStrTB.Text != "") { item.MaxStr = int.Parse(maxStrTB.Text); } else { item.MaxStr = 999; }
            if (minDexTB.Text != "") { item.MinDex = int.Parse(minDexTB.Text); } else { item.MinDex = 0; }
            if (maxStrTB.Text != "") { item.MaxDex = int.Parse(maxDexTB.Text); } else { item.MaxDex = 999; }
            if (baseTypePicker.SelectedIndex > 0) { item.BaseType = baseTypePicker.SelectedText; }
            if (classDDL.SelectedIndex > 0) { item.Class = classDDL.SelectedValue; }
            item.Ladder = ladderCB.Checked;
            item.Rarity = int.Parse(rarityRadioList.SelectedValue);
            item.Quality = int.Parse(qualityRadioList.SelectedValue);

            List<ItemModel> Items = ItemsEntity.Get(item);

            ItemList.DataSource = Items.Select(im => new ItemModel
            {
                ID = im.ID,
                Name = im.Name,
                BaseType1 = im.BaseType1,
                BaseType2 = im.BaseType2,
                Rune1 = im.Rune1,
                Rune2 = im.Rune2,
                Rune3 = im.Rune3,
                Rune4 = im.Rune4,
                Rune5 = im.Rune5,
                Rune6 = im.Rune6,
                Lvl = im.Lvl,
                Str = im.Str,
                Dex = im.Dex,
                Ladder = im.Ladder,
                Class = im.Class
            }).ToList();

            DataBind();
            ItemList.Visible = true;
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            nameTB.Text = "";
            minLvlDDL.SelectedIndex = 0;
            maxLvlDDL.SelectedIndex = 0;
            minStrTB.Text = "";
            maxStrTB.Text = "";
            minDexTB.Text = "";
            maxDexTB.Text = "";

            classDDL.SelectedIndex = 0;
            baseTypePicker.SelectedIndex = 0;

            runePicker1.SelectedIndex = 0;
            runePicker2.SelectedIndex = 0;
            runePicker3.SelectedIndex = 0;
            runePicker4.SelectedIndex = 0;

            modPicker1.SelectedIndex = 0;
            modPicker2.SelectedIndex = 0;
            modPicker3.SelectedIndex = 0;
            modPicker4.SelectedIndex = 0;
        }

        protected void ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ItemList.FindControl("ItemsPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindData();
        }

        protected void runePicker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runePicker1.SelectedIndex > 0)
            {
                runePicker2.Visible = true;
            }
            else
            {
                runePicker2.Visible = false;
            }
        }

        protected void runePicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runePicker2.SelectedIndex > 0)
            {
                runePicker3.Visible = true;
            }
            else
            {
                runePicker3.Visible = false;
            }
        }

        protected void runePicker3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runePicker3.SelectedIndex > 0)
            {
                runePicker4.Visible = true;
            }
            else
            {
                runePicker4.Visible = false;
            }
        }
    }
}