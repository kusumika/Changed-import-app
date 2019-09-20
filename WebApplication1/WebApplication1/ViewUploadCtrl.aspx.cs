using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DataAccess;
using ProcessHandler;

namespace WebApplication1
{
    public partial class ViewUploadCtrl : System.Web.UI.Page
    {
        private string filename;
        string files = "";
        int Quarter = -1;
        string strConn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCount.Visible = false;
                lblCountHead.Visible = false;
                lblMessage.Visible = false;
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            //Set some setting.
            lblCount.Visible = true;
            lblCountHead.Visible = true;
            lblMessage.Visible = true;
            lblMessage.Text = string.Empty;
            btnImport.Enabled = false;
            files = lblMessage.Text;
            int count = 0;

            //Check compulsory setting.
            //if (FileUpload1.FileName == "")
            //{
            //    btnImport.Enabled = true;
            //    lblMessage.Text = "Please select file.";
            //    SuccessColor(0);
            //    return;
            //}

            //if files get from folder
            if (rdo.SelectedValue == "Folder")
            {
                if (txt_FolderPath.Text == "")
                {
                    btnImport.Enabled = true;
                    lblMessage.Text = "Vänligen fyll i sökvägen till import filerna.";
                    SuccessColor(0);
                    return;
                }

                // string GetDirectory = System.IO.Path.GetDirectoryName(FileUpload1.PostedFile.FileName).ToString(); // Get Directory name.
                string GetDirectory = txt_FolderPath.Text; // Get Directory name.
                foreach (string Getfile in Directory.GetFiles(GetDirectory))
                {
                    //Old if (Getfile.EndsWith(".xls") || Getfile.EndsWith(".xlsx"))
                    if (Getfile.EndsWith(".xls", StringComparison.InvariantCultureIgnoreCase) || Getfile.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase))
                    {
                        FileName = Getfile;
                        StartUploadingProcess(FileName);
                        count += 1;
                        lblCount.Text = count.ToString();
                    }
                }
            }
            //Process single file.
            else if (rdo.SelectedValue == "File")
            {
             //   string fileName = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                string fileName = txt_FolderPath.Text + "/" + txt_FileName.Text;
               //string fileName = string.Empty;
               //string browserversion = Request.Browser.Version;
               if (txt_FolderPath.Text == "")
               {
                   btnImport.Enabled = true;
                   lblMessage.Text = "Vänligen fyll i sökvägen till import filerna.";
                   SuccessColor(0);
                   return;
               }
               if (txt_FileName.Text == "")
               {
                   btnImport.Enabled = true;
                   lblMessage.Text = "Vänligen fyll till import filerna.";
                   SuccessColor(0);
                   return;
               }
               
                StartUploadingProcess(fileName);
                count += 1;
                lblCount.Text = count.ToString();
            }
        }

        //Main process start
        public void StartUploadingProcess(string FileName)
        {
            //File Name with path

            Label4.Text = FileName;
            string file = Path.GetFileName(FileName); // Get File name.
            //fileName = System.IO.Path.GetDirectoryName(FileUpload1.PostedFile.FileName).ToString(); // Get Directory name.

            //Declaration of variables.
            Workbook wb;
            Worksheet ws;
            string Password = "Alljarn";
            DataSet ds;
            try
            {
                //Declaration of excel object.

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(FileName);
                //Microsoft.Office.Interop.Excel.Application xlApp1 = new Microsoft.Office.Interop.Excel.Application();
                //if micrsoft excel is not installed.

                if (xlApp == null)
                {
                    btnImport.Enabled = true;
                    lblMessage.Text = "EXCEL could not be started. Check that your office installation and project references are correct.";
                    SuccessColor(0);
                    return;
                }
                //Get workbook and work sheet of particular file.
                wb = xlApp.Workbooks.Add(FileName);
                ws = (Worksheet)wb.Worksheets[1];
                //if file available but not sheet inside the file.
                if (ws == null)
                {
                    btnImport.Enabled = true;
                    lblMessage.Text = "Worksheet could not be created. Check that your office installation and project references are correct.";
                    SuccessColor(0);
                    return;
                }
                //un protect workbook and worksheet.
                ws.Unprotect(Password);
                wb.Unprotect(Password);
                wb.Saved = true;
                wb.SaveCopyAs(FileName);
            }
            catch (Exception ex)
            {
                btnImport.Enabled = true;
                files = lblMessage.Text + " " + file;
                lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                SuccessColor(0);
                return;
            }
            //xlApp.Visible = true;
            System.Data.DataTable dtSheetNames = null;
            if (FileName != string.Empty)
            {
                //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                //Establish connection of Microsoft excel 2000-2003 version.
                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

                // Check file type
                if (rb_FileType.SelectedValue == "OldFile")
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                }


                //Declaration of connection
                OleDbConnection conn = null;
                OleDbCommand cmd = null;
                OleDbDataAdapter da = null;
                SqlConnection connection = null;
                SqlTransaction transaction = null;
                try
                {
                    //Establish connection to read data from excel file.
                    conn = new OleDbConnection(strConn);
                    conn.Open();
                    dtSheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    String[] excelSheets = new String[dtSheetNames.Rows.Count];
                    int i = 0;
                    //Get all sheets
                    foreach (DataRow row in dtSheetNames.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }
                    //Get data from statistics sheet
                    var target = "Statistik$";
                    var excelSheetStatistik = Array.FindAll(excelSheets, s => s.Equals(target)); //Finding all references of target string 
                    //cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[2] + "]", conn);
                    cmd = new OleDbCommand("SELECT * FROM [" + excelSheetStatistik[0] + "]", conn);
                    cmd.CommandType = CommandType.Text;
                    da = new OleDbDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    btnImport.Enabled = true;
                    conn.Close();
                    files = lblMessage.Text + " " + file;
                    lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                    SuccessColor(0);
                    return;
                }
                string SupplierNo = string.Empty;
                string SupplierName = string.Empty;
                DateTime PeriodStartDate;
                DateTime PeriodEndDate;
                try
                {
                    //Get supplier detail and periods.
                    SupplierNo = ds.Tables["Table"].Rows[0][0].ToString();
                    SupplierName = ds.Tables["Table"].Rows[0][1].ToString();
                    PeriodStartDate = Convert.ToDateTime(ds.Tables["Table"].Rows[2][1]);
                    PeriodEndDate = Convert.ToDateTime(ds.Tables["Table"].Rows[4][1]);
                    SalesController sc = new SalesController();
                    sc.DelSalesTemp(SupplierNo, PeriodStartDate);
                    /// Check the period
                    if (PeriodStartDate.Month >= 1 && PeriodEndDate.Month <= 3)
                    {
                        Quarter = 4;
                    }
                    else if (PeriodStartDate.Month >= 4 && PeriodEndDate.Month <= 6)
                    {
                        Quarter = 5;
                    }
                    else if (PeriodStartDate.Month >= 7 && PeriodEndDate.Month <= 9)
                    {
                        Quarter = 7;
                    }
                    else if (PeriodStartDate.Month >= 10 && PeriodEndDate.Month <= 12)
                    {
                        Quarter = 9;
                    }
                }
                catch (Exception ex)
                {
                    btnImport.Enabled = true;
                    conn.Close();
                    files = lblMessage.Text + " " + file;
                    lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                    SuccessColor(0);
                    return;
                }
                string MemberNo = "";
                string MemberName = "";
                int StartRows = 8;
                try
                {
                    //Establish connection with sql server
                    connection = DALHelper.GetConnection();
                    connection.Open();
                }
                catch (Exception ex)
                {
                    btnImport.Enabled = true;
                    conn.Close();
                    files = lblMessage.Text + " " + file;
                    lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                    SuccessColor(0);
                    return;
                }
                try
                {
                    //Batch transaction start here.
                    transaction = connection.BeginTransaction();
                    for (int i = 0; i < ds.Tables["Table"].Rows.Count; i++)
                    {
                        string MemNo = "";
                        string MemName = "";
                        try
                        {
                            //Get member number and name from excel sheet.
                            MemNo = Convert.ToString(ds.Tables["Table"].Rows[StartRows + i][0]);
                            MemName = Convert.ToString(ds.Tables["Table"].Rows[StartRows + i][1]);
                        }
                        catch { }

                        if ((MemNo != "") && (MemName != ""))
                        {
                            SalesController BonSet = new SalesController();
                            //Get bonus sets of particular supplier, how many bonus sets that supplier has
                            System.Data.DataTable dtBonSet = BonSet.GetBonusSets(Convert.ToInt32(SupplierNo), PeriodStartDate);
                            if (dtBonSet.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtBonSet.Rows.Count; k++)
                                {
                                    //Start getting to get data from excel sheet
                                    MemberNo = ds.Tables["Table"].Rows[StartRows + i][0].ToString();
                                    MemberName = ds.Tables["Table"].Rows[StartRows + i][1].ToString();
                                    string Location = ds.Tables["Table"].Rows[StartRows + i][2].ToString();
                                    string Komments = ds.Tables["Table"].Rows[StartRows + i][3].ToString();
                                    string TotalInkopAmountKv1 = ds.Tables["Table"].Rows[StartRows + i][4].ToString();
                                    string TotalInkopAmountKv2 = ds.Tables["Table"].Rows[StartRows + i][5].ToString();
                                    string SumKv12 = ds.Tables["Table"].Rows[StartRows + i][6].ToString();
                                    string TotalInkopAmountKv3 = ds.Tables["Table"].Rows[StartRows + i][7].ToString();
                                    string SumKv123 = ds.Tables["Table"].Rows[StartRows + i][8].ToString();
                                    string TotalInkopAmountKv4 = ds.Tables["Table"].Rows[StartRows + i][9].ToString();
                                    string SumAllQuarters = ds.Tables["Table"].Rows[StartRows + i][10].ToString();
                                    string EgetKundnummer = ds.Tables["Table"].Rows[StartRows + i][11].ToString();
                                    string BonusSetName = null;
                                    try
                                    {
                                        //Get bonus set name by suppliers.
                                        BonusSetName = Convert.ToString(dtBonSet.Rows[k][0]).Trim();
                                    }
                                    catch (Exception ex)
                                    {
                                        transaction.Rollback();
                                        btnImport.Enabled = true;

                                        files = lblMessage.Text + " " + file;
                                        lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                                        SuccessColor(0);
                                        return;
                                    }
                                    string BonusSetAmount = null;
                                    //If user has only one bonus set thant get from columns number 5 in excel sheet.
                                    if (dtBonSet.Rows.Count == 1)
                                    {
                                        //if (BonusSetName.ToLower() ==  Convert.ToString("Bonus").ToLower()) 
                                        //Quarter  BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][7].ToString();
                                        BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][Quarter].ToString();
                                    }
                                    else
                                    {
                                        //Get all bonuses.
                                        if (k == 0)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][12].ToString();
                                        else if (k == 1)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][13].ToString();
                                        else if (k == 2)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][14].ToString();
                                        else if (k == 3)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][15].ToString();
                                        else if (k == 4)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][16].ToString();
                                        else if (k == 5)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][17].ToString();
                                        else if (k == 6)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][18].ToString();
                                        else if (k == 7)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][19].ToString();
                                        else if (k == 8)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][20].ToString();
                                        else if (k == 9)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][21].ToString();
                                        else if (k == 10)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][22].ToString();
                                        else if (k == 11)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][23].ToString();
                                        else if (k == 12)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][24].ToString();
                                        else if (k == 13)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][25].ToString();
                                        else if (k == 14)
                                            BonusSetAmount = ds.Tables["Table"].Rows[StartRows + i][26].ToString();
                                    }
                                    string BonusSetID = null;
                                    try
                                    {
                                        //Get bonus set ID by Bonus set name by passing from excel sheet.
                                        System.Data.DataTable dtBonSetID = BonSet.GetBonusSetsID(Convert.ToInt32(SupplierNo), BonusSetName, PeriodStartDate);
                                        if (dtBonSetID.Rows.Count > 0)
                                            BonusSetID = Convert.ToString(dtBonSetID.Rows[0][0]);
                                    }
                                    catch (Exception ex)
                                    {
                                        transaction.Rollback();
                                        btnImport.Enabled = true;
                                        lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                                        files += lblMessage.Text;
                                        SuccessColor(0);
                                        return;
                                    }
                                    string CreatedBy = "Ray";
                                    DateTime CreatedDate = DateTime.Now;

                                    //Here is insert function.
                                    BonSet.AddSalesTemp(connection, transaction, SupplierNo, SupplierName, PeriodStartDate, PeriodEndDate, MemberNo, MemberName, Location, Komments, TotalInkopAmountKv1, TotalInkopAmountKv2, SumKv12, TotalInkopAmountKv3, SumKv123, TotalInkopAmountKv4, SumAllQuarters, EgetKundnummer, BonusSetID, BonusSetName, BonusSetAmount, CreatedBy, CreatedDate);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    btnImport.Enabled = true;
                    transaction.Rollback();
                    files = lblMessage.Text + " " + file;
                    lblMessage.Text = files + " " + ex.Message.ToString() + Environment.NewLine;
                    SuccessColor(0);
                    return;
                }
                finally
                {
                    //excel connection close.
                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                    //sheet should be null in memory.
                    if (dtSheetNames != null)
                        dtSheetNames.Dispose();
                }
                //batch transaction successfully done here.
                transaction.Commit();

                //sql server connection close.
                if (connection != null)
                    connection.Close();

                //Protect sheet again.
                ws.Protect(Password);
                wb.Protect(Password);
                wb.SaveCopyAs(FileName);
                btnImport.Enabled = true;
                files = lblMessage.Text + " " + file;
                lblMessage.Text = files + " successfully imported" + Environment.NewLine;

                SuccessColor(1);
            }
        }

        //Function change valud dot (.) to comma (,)
        //public string numstring(string val)
        //{
        //    if ((val == "0,00") || (val == "0,0"))
        //    {
        //        val = "0";
        //    }
        //    int dot = val.IndexOf('.');
        //    int comma = val.IndexOf(',');

        //    if (dot < comma)
        //    {
        //        val = val.Replace(".", "");
        //        val = val.Replace(',', '.');
        //    }
        //    return val;
        //}
        //success color change here.
        
        public void SuccessColor(int isSuccess)
        {
            if (isSuccess == 1)
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            else
                lblMessage.ForeColor = System.Drawing.Color.Red;
        }
        //property of file name that hold in memory.
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenuForm.aspx");
        }

        protected void btnBackToImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewUploadCtrl.aspx");
        }

        protected void btnBackToView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewSales.aspx");
        }
    }
}
