using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreManagement.Aspx
{
    public partial class Supervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetItems();
        }
        private void GetItems()
        {
          //  ddlItem.DataSource= ;
        }
    }
}