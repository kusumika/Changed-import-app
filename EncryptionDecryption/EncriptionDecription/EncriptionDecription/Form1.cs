using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EncriptionDecription
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string _machineName = System.Environment.MachineName;
        string _cypherText = "xyz3-3hn8-sqoy19";

        public class CryptoEngine
        {
            public static string Encrypt(string input, string key)
            {
                byte[] resultArray = new byte[1000];
                try
                {
                    byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                    tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                    tripleDES.Mode = CipherMode.ECB;
                    tripleDES.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                    resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                    tripleDES.Clear();
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
                catch (Exception ex)
                {

                }
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
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

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEnCrypt.Text != string.Empty)
                {
                    //Here key is of 128 bit  
                    //Key should be either of 128 bit or of 192 bit  
                    string paddedText = txtEnCrypt.Text + _machineName;
                    txtCypher.Text = CryptoEngine.Encrypt(txtEnCrypt.Text, _cypherText);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCypher.Text != string.Empty)
                {
                    //Key shpuld be same for encryption and decryption  
                    //string key = "sblw-xyz-" + _machineName;
                    string decryptPadded = CryptoEngine.Decrypt(txtCypher.Text, _cypherText);
                    txtDecript.Text = decryptPadded.Replace(_machineName,"");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
