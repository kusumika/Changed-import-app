using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess
{
    public class SalesDAL
    {
        public DataTable GetSuppliersAll()
        {
            string SQLQuery = "sp_SelectPRIM_SalesTempSuppliersAll";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SQLQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;                
                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "Table");
            }

            finally
            {
                conn.Close();
            }
            return dataset.Tables["Table"];
        }

        public DataTable GetPeriodsAll()
        {
            string SQLQuery = "sp_SelectPRIM_SalesTempPeriodssAll";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SQLQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "Table");
            }

            finally
            {
                conn.Close();
            }
            return dataset.Tables["Table"];
        }

        public DataTable GetMembersBySupplierAndPeriodsID(int SupplierID, DateTime PeriodStartDate)
        {
            string SQLQuery = "sp_SelectPRIM_SalesTempBySupplierAndPeriodsID";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SQLQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter mySupplierID = sqlcommand.Parameters.Add("@SupplierID", SqlDbType.Int, 15);
                mySupplierID.Value = SupplierID;

                SqlParameter myParm = sqlcommand.Parameters.Add("@Period", SqlDbType.DateTime);
                myParm.Value = PeriodStartDate;                
                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "Table");
            }

            finally
            {
                conn.Close();
            }
            return dataset.Tables["Table"];
        }

        public DataTable GetSuppliersSummaryByPeriodsID(DateTime PeriodStartDate)
        {
            string SQLQuery = "sp_SelectPRIM_SalesTempAllSupplierSummary";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SQLQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                SqlParameter myParm = sqlcommand.Parameters.Add("@Period", SqlDbType.DateTime);
                myParm.Value = PeriodStartDate;                
                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "Table");
            }
            finally
            {
                conn.Close();
            }
            return dataset.Tables["Table"];
        }

        ///Get bonus sets  from sql server database. Added periodStartDate to get the BonusSet from the right contract
        public DataTable GetBonusSets(int supplierID, DateTime periodStartDate)
        {
            string SQLQuery = "sp_SelectPRIM_SalesTempBonusSetsBySupplierID_New";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SQLQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                SqlParameter myParm = sqlcommand.Parameters.Add("@SupplierID", SqlDbType.Int, 15);
                myParm.Value = supplierID;
                SqlParameter myParm2 = sqlcommand.Parameters.Add("@PeriodStartDate", SqlDbType.DateTime);
                myParm2.Value = periodStartDate;                
                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "Table");
            }

            finally
            {
                conn.Close();
            }
            return dataset.Tables["Table"];
        }

        //Get Bonus Set ID.  Added periodStartDate to get the BonusSet from the right contract
        public DataTable GetBonusSetID(int supplierID, string bonusSetName, DateTime periodStartDate)
        {
            string SqlQuery = "sp_SelectPRIM_SalesTempBonusSetsIDByBonusSetName_New";
            SqlConnection conn = null;
            DataSet dataset = null;
            try
            {
                SqlDataAdapter dataAdapter = null;
                conn = DALHelper.GetConnection();
                SqlCommand sqlcommand = new SqlCommand(SqlQuery, conn);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter ParmSetName = sqlcommand.Parameters.Add("@BonusSetName", SqlDbType.Text, 50);
                ParmSetName.Value = bonusSetName;

                SqlParameter SupplierIDParm = sqlcommand.Parameters.Add("@SupplierID", SqlDbType.Int, 15);
                SupplierIDParm.Value = supplierID;

                SqlParameter myParm2 = sqlcommand.Parameters.Add("@PeriodStartDate", SqlDbType.DateTime);
                myParm2.Value = periodStartDate;                

                conn.Open();
                dataAdapter = new SqlDataAdapter(sqlcommand);
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "tb1");
            }

            finally
            {
                conn.Close();
            }
            return dataset.Tables["tb1"];
        }

        //Insert sale function.
        public string AddSalesTemp(SqlConnection conn, SqlTransaction transaction, string SupplierNo, string SupplierName, DateTime PeriodStartDate, DateTime PeriodEndDate, string MemberNo, string MemberName, string Location, string Komments, string TotalInkopAmountKv1, string TotalInkopAmountKv2, string SumKv12, string TotalInkopAmountKv3, string SumKv123, string TotalInkopAmountKv4, string SumAllQuarters, string EgetKundnummer, string BonusSetID, string BonusSetName, string BonusSetAmount, string CreatedBy, DateTime CreatedDate)
        {
            string SQLQuery = "sp_InsertPRIM_SalesTemp";
            SqlConnection connection = conn;
            SqlCommand sqlcommand = new SqlCommand(SQLQuery, connection);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.Add(new SqlParameter("@SupplierNo", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SupplierName", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@PeriodStartDate", SqlDbType.DateTime));
            sqlcommand.Parameters.Add(new SqlParameter("@PeriodEndDate", SqlDbType.DateTime));
            sqlcommand.Parameters.Add(new SqlParameter("@MemberNo", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@MemberName", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@Location", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@Komments", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv1", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv2", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumKv12", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv3", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumKv123", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv4", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumAllQuarters", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@EgetKundnummer", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@BonusSetID", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@BonusSetName", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@BonusSetAmount", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime));
            sqlcommand.Transaction = transaction;
            sqlcommand.Parameters["@SupplierNo"].Value = SupplierNo;
            sqlcommand.Parameters["@SupplierName"].Value = SupplierName;
            sqlcommand.Parameters["@PeriodStartDate"].Value = PeriodStartDate;
            sqlcommand.Parameters["@PeriodEndDate"].Value = PeriodEndDate;
            sqlcommand.Parameters["@MemberNo"].Value = MemberNo;
            sqlcommand.Parameters["@MemberName"].Value = MemberName;
            sqlcommand.Parameters["@Location"].Value = Location;
            sqlcommand.Parameters["@Komments"].Value = Komments;
            sqlcommand.Parameters["@TotalInkopAmountKv1"].Value = TotalInkopAmountKv1;
            sqlcommand.Parameters["@TotalInkopAmountKv2"].Value = TotalInkopAmountKv2;
            sqlcommand.Parameters["@SumKv12"].Value = SumKv12;
            sqlcommand.Parameters["@TotalInkopAmountKv3"].Value = TotalInkopAmountKv3;
            sqlcommand.Parameters["@SumKv123"].Value = SumKv123;
            sqlcommand.Parameters["@TotalInkopAmountKv4"].Value = TotalInkopAmountKv4;
            sqlcommand.Parameters["@SumAllQuarters"].Value = SumAllQuarters;
            sqlcommand.Parameters["@EgetKundnummer"].Value = EgetKundnummer;
            sqlcommand.Parameters["@BonusSetID"].Value = BonusSetID;
            sqlcommand.Parameters["@BonusSetName"].Value = BonusSetName;
            sqlcommand.Parameters["@BonusSetAmount"].Value = BonusSetAmount;
            sqlcommand.Parameters["@CreatedBy"].Value = CreatedBy;
            sqlcommand.Parameters["@CreatedDate"].Value = CreatedDate;
            sqlcommand.ExecuteNonQuery();
            return "success";
        }
        
        public string UpdateSales(long ID, string SupplierNo, string Komments, string TotalInkopAmountKv1, string TotalInkopAmountKv2, string SumKv12, string TotalInkopAmountKv3, string SumKv123, string TotalInkopAmountKv4, string SumAllQuarters, string EgetKundnummer, string BonusSetAmount)
        {
            string SQLQuery = "sp_UpdatePRIM_SalesTemp";
            SqlConnection connection = DALHelper.GetConnection();
            SqlCommand sqlcommand = new SqlCommand(SQLQuery, connection);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
            sqlcommand.Parameters.Add(new SqlParameter("@SupplierNo", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@Komments", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv1", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv2", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumKv12", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv3", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumKv123", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@TotalInkopAmountKv4", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@SumAllQuarters", SqlDbType.VarChar));
            sqlcommand.Parameters.Add(new SqlParameter("@EgetKundnummer", SqlDbType.VarChar));            
            sqlcommand.Parameters.Add(new SqlParameter("@BonusSetAmount", SqlDbType.VarChar));
            connection.Open();
            sqlcommand.Parameters["@ID"].Value = ID;
            sqlcommand.Parameters["@SupplierNo"].Value = SupplierNo;
            sqlcommand.Parameters["@Komments"].Value = Komments;
            sqlcommand.Parameters["@TotalInkopAmountKv1"].Value = TotalInkopAmountKv1;
            sqlcommand.Parameters["@TotalInkopAmountKv2"].Value = TotalInkopAmountKv2;
            sqlcommand.Parameters["@SumKv12"].Value = SumKv12;
            sqlcommand.Parameters["@TotalInkopAmountKv3"].Value = TotalInkopAmountKv3;
            sqlcommand.Parameters["@SumKv123"].Value = SumKv123;
            sqlcommand.Parameters["@TotalInkopAmountKv4"].Value = TotalInkopAmountKv4;
            sqlcommand.Parameters["@SumAllQuarters"].Value = SumAllQuarters;
            sqlcommand.Parameters["@EgetKundnummer"].Value = EgetKundnummer;
            sqlcommand.Parameters["@BonusSetAmount"].Value = BonusSetAmount;
            sqlcommand.ExecuteNonQuery();
            return "success";
        }
        //Delete Sales Temp
        public string DelSalesTemp(string SupplierNo, DateTime PeriodStartDate)
        {
            string sql = "sp_DeletePRIM_SalesTemp";
            SqlConnection connection = DALHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@SupplierNo", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@PeriodStartDate", SqlDbType.DateTime));
            connection.Open();
            try
            {
                SqlTransaction transaction = connection.BeginTransaction();
                cmd.Transaction = transaction;
                try
                {
                    cmd.Parameters["@SupplierNo"].Value = SupplierNo;
                    cmd.Parameters["@PeriodStartDate"].Value = PeriodStartDate;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return "success";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public string DelSalesTempByID(long ID)
        {
            string sql = "sp_DeletePRIM_SalesTempByID";
            SqlConnection connection = DALHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
            connection.Open();
            try
            {
                SqlTransaction transaction = connection.BeginTransaction();
                cmd.Transaction = transaction;
                try
                {
                    cmd.Parameters["@ID"].Value = ID;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return "success";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public string TransferSales(DateTime PeriodStartDate, DateTime PeriodEndDate)
        {
            string sql = "sp_TransferPRIM_Sales";
            SqlConnection connection = DALHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PeriodStartDate", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@PeriodEndDate", SqlDbType.DateTime));
            connection.Open();
            try
            {
                SqlTransaction transaction = connection.BeginTransaction();
                cmd.Transaction = transaction;
                try
                {
                    cmd.Parameters["@PeriodStartDate"].Value = PeriodStartDate;
                    cmd.Parameters["@PeriodEndDate"].Value = PeriodEndDate;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return "success";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            finally
            {
                connection.Close();
            }
        }   
    }
}

