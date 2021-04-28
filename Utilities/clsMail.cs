using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System;
using System.Text;
using RexrothData;
using System.Collections.Generic;
using HRLData;
using System.Data.Linq;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace FPY
{
    class clsMail
    {
        static string strProcessOwnerEmail = "administrator.SharePoint@us.bosch.com";
        static string strTestEmail = "external.Patrick.Miller@us.bosch.com"; //set to me
        static string strSystemEmail = "DocApproval@us.bosch.com";

       
       
     
        private static void ReplaceRecipientsWithCredo(System.Net.Mail.MailMessage message)
        {
            foreach (System.Net.Mail.MailAddress to in message.To)
            {
                message.To.Remove(to);
            }
            foreach (System.Net.Mail.MailAddress cc in message.CC)
            {
                message.CC.Remove(cc);
            }

            message.To.Add("kevin.curnow@us.bosch.com");

        }
      

        //public static bool SendMailIT( string EmSender) // added 1/30/2017
        //{

        //    Boolean fVal = true;

        //    HRLEntities db = clsStart.efdb();
        //    RexrothEntities db2 = clsStart.efdbRexroth();

        //    try
        //    {

        //        String strSMTP = (from rv in db2.tblAppOptions
        //                          where rv.APOP_Note == "SMTP"
        //                          select rv).First().APOP_Desc.ToString();

        //        var qry = (from ct in db.tblReplenishDistribution
        //                  join em in db.tblAssociate on ct.ASID equals em.ASID 
        //                  where ct.RD_Deleted.HasValue == false
        //                  select em.AS_Email).ToArray();



        //        //var qrySender = from ct in db.tblAssociate
        //        //                where ct.ASID == ECID
        //        //                select ct.AS_Email;



        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(strSMTP);
        //        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //        message.Priority = System.Net.Mail.MailPriority.High;
        //        message.From = new System.Net.Mail.MailAddress(EmSender);


        //        foreach (var em in qry)
        //        {
        //            message.To.Add(em.ToString());
        //        }

        //        message.CC.Add(EmSender);

        //        message.Subject = "Replenishment Tool Is Down";
        //        message.Body = "Replenishment Tool is Down";

        //        // added 5/9/16  - was not trapping for previously - Patrick
        //        if (Debugger.IsAttached == true)
        //        {
        //            //message.To.Add(strTestEmail);
        //        }
        //        smtp.Send(message);

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return fVal;

        //}

     
    }
}
