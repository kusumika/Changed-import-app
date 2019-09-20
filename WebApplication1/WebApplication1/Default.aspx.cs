using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;
using System.Data;
using ProcessHandler;
using System.IO;
using System.Data.SqlClient;
using DataAccess;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Redirect("~/MainMenuForm.aspx");
        }
    }
}


