using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebApplication1
{
    public partial class Programs : System.Web.UI.Page
    {
        #region Private Members


        #endregion

        #region Starting Routines

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindData();

                }
            }
            catch (Exception ex) //Module failed to load
            {
                Response.Write("Exception Occured:   " + ex);
            }
        }

        #endregion

        #region content methods

        private static void BindData()
        {
            //ReportNameController ReportNameCtrl = new ReportNameController();
            //this.RadGridPrograms.DataSource = ReportNameCtrl.GetAllReportName();
            //this.RadGridPrograms.DataBind();
        }

        #endregion

        #region grid methodes

        protected void RadGridProgramsItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                e.Item.Expanded = false;
            }
            else if (e.CommandName == "Update")
            {
                //ReportNameController ReportNameCtrl = new ReportNameController();
                //int ReportNameID = Convert.ToInt32(this.grid_ReportName.Items[e.Item.ItemIndex]["ReportName_ID"].Text);
                //ReportNameInfo myReportNameObj = ReportNameCtrl.GetReportName(ReportNameID);

                //myReportNameObj.ReportName = (e.Item.FindControl("txb_ReportName") as TextBox).Text;

                //try
                //{
                //    ReportNameCtrl.UpdateReportName(myReportNameObj);
                //}
                //catch (Exception exc)
                //{
                //    Exceptions.ProcessModuleLoadException(this, exc);
                //}
            }
            else if (e.CommandName == "Insert")
            {
                //ReportNameController ReportNameCtrl = new ReportNameController();
                //ReportNameInfo myReportNameObj = new ReportNameInfo();

                //myReportNameObj.ReportName = (e.Item.FindControl("txb_ReportName") as TextBox).Text;

                //try
                //{
                //    ReportNameCtrl.AddReportName(myReportNameObj);

                //    grid_ReportName.Rebind();
                //}
                //catch (Exception exc)
                //{
                //    Exceptions.ProcessModuleLoadException(this, exc);
                //}
            }
        }
        protected void RadGridProgramsDeleteCommand(object source, GridCommandEventArgs e)
        {
            //ReportNameController ReportNameCtrl = new ReportNameController();
            //GridDataItem item = (GridDataItem)e.Item;

            //int ReportNameID = Convert.ToInt32(item.GetDataKeyValue("ReportName_ID").ToString());

            //if (ReportNameID != Null.NullInteger && ReportNameID != -1)
            //{
            //    try
            //    {
            //        ReportNameCtrl.DeleteReportName(ReportNameID);
            //        grid_ReportName.Rebind();
            //    }
            //    catch (Exception exc)
            //    {
            //        Exceptions.ProcessModuleLoadException(this, exc);
            //    }
            //}
        }

        protected void RadGridProgramsNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //ReportNameController ReportNameCtrl = new ReportNameController();
            //this.RadGridPrograms.DataSource = ReportNameCtrl.GetAllReportName();
        }

        protected void RadGridProgramsItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridCommandItem)
            {
                ((LinkButton)e.Item.FindControl("InitInsertButton")).Text = "Add New Program";
                ((LinkButton)e.Item.FindControl("RebindGridButton")).Text = "Update";
            }
        }


        #endregion
    }
}