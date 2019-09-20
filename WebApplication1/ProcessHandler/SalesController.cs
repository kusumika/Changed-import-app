using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace ProcessHandler
{
    public class SalesController
    {

        public DataTable GetMembersBySupplierAndPeriodsID(int SupplierID, DateTime PeriodStartDate)
        {
            return new SalesDAL().GetMembersBySupplierAndPeriodsID(SupplierID, PeriodStartDate);
        }

        public DataTable GetSuppliersSummaryByPeriodsID(DateTime PeriodStartDate)
        {
            return new SalesDAL().GetSuppliersSummaryByPeriodsID(PeriodStartDate);
        }

        

        public DataTable GetSuppliersAll()
        {
            return new SalesDAL().GetSuppliersAll();
        }

        public DataTable GetPeriodsAll()
        {
            return new SalesDAL().GetPeriodsAll();
        }
        //Get bonus set name.
        public DataTable GetBonusSets(int SupplierID, DateTime periodStartDate)
        {
            return new SalesDAL().GetBonusSets(SupplierID, periodStartDate);
        }
        //Get bonus set id
        public DataTable GetBonusSetsID(int SupplierID, string BonusSetName, DateTime periodStartDate)
        {
            return new SalesDAL().GetBonusSetID(SupplierID, BonusSetName, periodStartDate);
        }
        // Insert Sales 
        public string AddSalesTemp(SqlConnection conn, SqlTransaction transaction, string SupplierNo, string SupplierName, DateTime PeriodStartDate, DateTime PeriodEndDate, string MemberNo, string MemberName, string Location, string Komments, string TotalInkopAmountKv1, string TotalInkopAmountKv2, string SumKv12, string TotalInkopAmountKv3, string SumKv123, string TotalInkopAmountKv4, string SumAllQuarters, string EgetKundnummer, string BonusSetID, string BonusSetName, string BonusSetAmount, string CreatedBy, DateTime CreatedDate)
        {
            return new SalesDAL().AddSalesTemp(conn, transaction, SupplierNo, SupplierName, PeriodStartDate, PeriodEndDate, MemberNo, MemberName, Location, Komments, TotalInkopAmountKv1, TotalInkopAmountKv2, SumKv12, TotalInkopAmountKv3, SumKv123, TotalInkopAmountKv4, SumAllQuarters, EgetKundnummer, BonusSetID, BonusSetName, BonusSetAmount, CreatedBy, CreatedDate);
        }

        public string UpdateSales(long ID, string SupplierNo, string Komments, string TotalInkopAmountKv1, string TotalInkopAmountKv2, string SumKv12, string TotalInkopAmountKv3, string SumKv123, string TotalInkopAmountKv4, string SumAllQuarters, string EgetKundnummer, string BonusSetAmount)
        {
            return new SalesDAL().UpdateSales(ID, SupplierNo, Komments, TotalInkopAmountKv1, TotalInkopAmountKv2, SumKv12, TotalInkopAmountKv3, SumKv123, TotalInkopAmountKv4, SumAllQuarters, EgetKundnummer, BonusSetAmount);
        }


        
        //Delete sales.
        public string DelSalesTemp(string SupplierNo, DateTime PeriodStartDate)
        {
            return new SalesDAL().DelSalesTemp(SupplierNo, PeriodStartDate);
        }

        public string DelSalesTempByID(long ID)
        {
            return new SalesDAL().DelSalesTempByID(ID);
        }

        public string TransferSales(DateTime PeriodStartDate, DateTime PeriodEndDate)
        {
            return new SalesDAL().TransferSales(PeriodStartDate, PeriodEndDate);
        }
    }
}
