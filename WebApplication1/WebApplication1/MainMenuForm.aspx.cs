using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MainMenuForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewUploadCtrl.aspx");

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewSales.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenuForm.aspx");
        }
    }
}