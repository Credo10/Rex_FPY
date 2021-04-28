using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using HRLData;
using System.Threading.Tasks;
using System.Configuration;
using Encryption;
using Bandwidth.Net;
using Bandwidth.Net.Api;


namespace RexVOIS3
{
    public class clsSMS
    {

        public static async Task SendText(string strTo, string strFrom, string strMessage)
        {



            try
            {
                string strUser = clsEncrypt.Decrypt(ConfigurationManager.AppSettings["BandUser"]);
                string strToken = clsEncrypt.Decrypt(ConfigurationManager.AppSettings["BandToken"]);
                string strSecret = clsEncrypt.Decrypt(ConfigurationManager.AppSettings["BandSecret"]);


                var client = new Client(strUser, strToken, strSecret);


                var sms = await client.Message.SendAsync(new MessageData
                {
                    From = strFrom,
                    To = strTo,
                    Text = strMessage

                });



            }
            catch (Exception ex)
            {
                AddError(ex);

            }

        }

        static void AddError(Exception msg)
        {
            try
            {
                BPSEntities db = clsDAL.efdbBPS();

                string strMsg = msg.Message.ToString();

                if (strMsg + "" == "")
                {
                    strMsg = msg.InnerException.ToString();
                }

                if (strMsg + "" != "")
                {
                    tblBandWidthError tbl = new tblBandWidthError();
                    tbl.WE_Created = DateTime.Now;
                    tbl.WE_Desc = strMsg;
                    db.tblBandWidthError.Add(tbl);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }


        }


    }

}
