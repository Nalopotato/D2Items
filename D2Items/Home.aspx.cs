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
            if (rarityRadioList.SelectedIndex <= 1)
            {
                qualityPanel.Visible = true;
                runesPanel.Visible = true;
            }
            else
            {
                qualityPanel.Visible = false;
                runesPanel.Visible = false;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            ItemFetchModel Item = new ItemFetchModel();

            Item.Name = nameTB.Text;
            Item.MinLvl = minLvlDDL.SelectedIndex;
            Item.MaxLvl = maxLvlDDL.SelectedIndex;
            Item.MinStr = Int32.Parse(minStrTB.Text);
            Item.MaxStr = Int32.Parse(maxStrTB.Text);
            
            List<ItemModel> Items = ItemsEntity.Get(Item);

            ItemList.DataSource = Items.Select(im => new ItemModel
            {
                ID = im.ID,
                Name = im.Name,
                Lvl = im.Lvl,
                Str = im.Str,
                Dex = im.Dex,
                BaseType1 = im.BaseType1,
                RunesList = im.RunesList
            }).ToList();
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

        }
    }
}