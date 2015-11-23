using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using D2Items.Entity;
using D2Items.Model;

namespace D2Items.Controls
{
    public abstract class ExtendedDropDownList<ModelClass, EntityClass> : DropDownList
        where ModelClass : BaseModel, new()
        where EntityClass : DatabaseEntity<ModelClass>, new()
    {
        protected List<ModelClass> collection;
        public bool IncludeInitialItem { get; set; }
        public string InitialText { get; set; }
        public string InitialValue { get; set; }
        public string SelectedText
        {
            get
            {
                return this.SelectedItem.Text;
            }
            set
            {
                ListItem li = this.Items.FindByText(value);
                if (li != null)
                {
                    li.Selected = true;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Items.Count == 0)
            {
                InitializeDropDownList();
                GetCollectionFromDatabase();
                LoadCollectionIntoPicker();
            }
        }

        protected void InitializeDropDownList()
        {
            if (this.IncludeInitialItem)
            {
                this.Items.Add(new ListItem(this.InitialText, this.InitialValue));
            }
        }

        protected virtual void GetCollectionFromDatabase(int? ID = null)
        {
            var Entity = new EntityClass();
            collection = Entity.GetAll(ID);
        }

        protected virtual void LoadCollectionIntoPicker()
        {
            foreach (ModelClass item in collection)
            {
                this.Items.Add(new ListItem(item.Label, item.ID.ToString()));
            }
        }
    }
}
