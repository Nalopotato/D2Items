using System;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace D2Items
{
    public partial class D2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }
    }
}