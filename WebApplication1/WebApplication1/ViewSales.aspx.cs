using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProcessHandler;
using Telerik.Web.UI;

namespace WebApplication1
{
    public partial class ViewSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalesController scSuppliers = new SalesController();
                this.rcbSupplier.DataSource = scSuppliers.GetSuppliersAll();
                this.rcbSupplier.DataBind();

                SalesController scPeriods = new SalesController();
                this.rcbPeriods.DataSource = scPeriods.GetPeriodsAll();
                this.rcbPeriods.DataBind();
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                e.Item.Expanded = false;
            }
            else if (e.CommandName == "Update")
            {
                try
                {
                    SalesController scGrid = new SalesController();
                    long ID = Convert.ToInt64(this.RadGrid1.Items[e.Item.ItemIndex]["ID"].Text);
                    string SupplierNo = Convert.ToString(this.RadGrid1.Items[e.Item.ItemIndex]["SupplierNo"].Text);
                    string Komments = (e.Item.FindControl("rtx_Komments") as RadTextBox).Text;
                    string TotalInkopAmountKv1 = (e.Item.FindControl("rtx_TotalInkopAmountKv1") as RadNumericTextBox).Text;
                    string TotalInkopAmountKv2 = (e.Item.FindControl("rtxTotalInkopAmountKv2") as RadNumericTextBox).Text;
                    string SumKv12 = (e.Item.FindControl("rtxSumKv12") as RadNumericTextBox).Text;
                    string TotalInkopAmountKv3 = (e.Item.FindControl("rtxTotalInkopAmountKv3") as RadNumericTextBox).Text;
                    string SumKv123 = (e.Item.FindControl("rtxSumKv123") as RadNumericTextBox).Text;
                    string TotalInkopAmountKv4 = (e.Item.FindControl("rtxTotalInkopAmountKv4") as RadNumericTextBox).Text;
                    string SumAllQuarters = (e.Item.FindControl("rtxSumAllQuarters") as RadNumericTextBox).Text;
                    string EgetKundnummer = (e.Item.FindControl("rtxEgetKundnummer") as RadTextBox).Text;
                    string BonusSetAmount = (e.Item.FindControl("rtxBonusSetAmount") as RadNumericTextBox).Text;
                    scGrid.UpdateSales(ID, SupplierNo, Komments, TotalInkopAmountKv1, TotalInkopAmountKv2, SumKv12, TotalInkopAmountKv3, SumKv123, TotalInkopAmountKv4, SumAllQuarters, EgetKundnummer, BonusSetAmount);
                    RadGrid1.Rebind();
                }
                catch (Exception exc)
                {

                }
            }
            else if (e.CommandName == "Delete")
            {
                try
                {
                    SalesController scGrid = new SalesController();
                    scGrid.DelSalesTempByID(Convert.ToInt64(this.RadGrid1.Items[e.Item.ItemIndex]["ID"].Text));
                    RadGrid1.Rebind();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            SalesController scGrid = new SalesController();
            if (this.rcbSupplier.SelectedValue != "")
                this.RadGrid1.DataSource = scGrid.GetMembersBySupplierAndPeriodsID(Convert.ToInt32(this.rcbSupplier.SelectedValue), Convert.ToDateTime(this.rcbPeriods.SelectedValue));
            else
                this.RadGrid1.DataSource = scGrid.GetSuppliersSummaryByPeriodsID(Convert.ToDateTime(this.rcbPeriods.SelectedValue));

        }

        protected void ToolBar_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            try
            {
                String commandName = ((RadToolBarButton)e.Item).CommandName.ToLower();
                SalesController scGrid = new SalesController();
                if (commandName.Equals("delete"))
                {
                    scGrid.DelSalesTemp(Convert.ToString(this.rcbSupplier.SelectedValue), Convert.ToDateTime(rcbPeriods.SelectedValue));
                    RadGrid1.Rebind();
                }
                else if (commandName.Equals("transfer"))
                {
                    //TransferSales
                    string[] atSplt = { "To " };
                    string[] Getenddate = rcbPeriods.SelectedItem.Text.Split(atSplt, StringSplitOptions.RemoveEmptyEntries);
                    scGrid.TransferSales(Convert.ToDateTime(rcbPeriods.SelectedValue), Convert.ToDateTime(Getenddate[1]));
                    RadGrid1.Rebind();
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //AccountingPaymentInfo myStatusGridDataItem = (AccountingPaymentInfo)e.Item.DataItem;
            //if (myStatusGridDataItem != null)
            //{
            //    if (myStatusGridDataItem.Paymentstatus == "Betald")
            //        e.Item.BackColor = System.Drawing.Color.LightSteelBlue;
            //    else if (myStatusGridDataItem.Paymentstatus == "Delvis betald")
            //        e.Item.BackColor = System.Drawing.Color.LightSeaGreen;
            //    else if (myStatusGridDataItem.Paymentstatus == "Obetald")
            //        e.Item.BackColor = System.Drawing.Color.LightSalmon;
            //}
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                // Label txtProcessStatus = e.Item.FindControl("ProcessStatusLabel") as Label;
                if (this.rcbSupplier.SelectedValue == "")
                {
                    ImageButton Editbutton = (ImageButton)item["EditButtonColumn"].Controls[0];
                    ImageButton Deletebutton = (ImageButton)item["DeleteButtonColumn"].Controls[0];
                    Editbutton.Visible = false;
                    Deletebutton.Visible = false;
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((rcbSupplier.SelectedValue != null) || (rcbPeriods.SelectedValue != null))
            {
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (this.rcbSupplier.SelectedValue == "")
            {
                foreach (GridCommandItem cmdItem in RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem))
                {
                    RadToolBar rdtlbr = (RadToolBar)cmdItem.FindControl("RadToolBar2");
                    rdtlbr.FindItemByValue("Delete").Enabled = false;
                    rdtlbr.FindItemByValue("Transfer").Enabled = true;
                }
            }
            else
            {
                foreach (GridCommandItem cmdItem in RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem))
                {
                    RadToolBar rdtlbr = (RadToolBar)cmdItem.FindControl("RadToolBar2");
                    rdtlbr.FindItemByValue("Transfer").Enabled = false;
                }
            }
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