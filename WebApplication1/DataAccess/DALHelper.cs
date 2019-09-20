using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DataAccess
{
    public class DALHelper
    {
        static string _machineName = System.Environment.MachineName;
        static string _cypherText = "xyz3-3hn8-sqoy19";
        
        //Establish connection string with SQL Server
        public static SqlConnection GetConnection()
        {
            //TODO Test
            //const string conStr = "Server=172.18.36.10; Persist Security Info=False;Initial Catalog=bolist_DB02;UID=sa;PWD=L1nuxRul35th3un!vers3"; //Production DB 
            string conStr = ConfigurationManager.AppSettings["ConnectionString"];

            SqlConnectionStringBuilder sqlConnectionSettings = new SqlConnectionStringBuilder(conStr);
            string pwd = sqlConnectionSettings.Password;

            string decryptPadded = Decrypt(pwd, _cypherText);
            string deCryptedpwd = decryptPadded.Replace(_machineName, "");
            sqlConnectionSettings.Password = deCryptedpwd;


            return new SqlConnection(sqlConnectionSettings.ToString());
        }

        /// <summary>
        /// Decryption is doing here
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string input, string key)
        {
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                byte[] resultArray = null;
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
        }
    }
}
