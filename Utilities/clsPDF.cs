
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace FPY
{
    public class clsPDF
    {

       
        //public static Boolean ConvertPPT_PDF(string strFile)
        //{

        //    //
        //    // Create COM Objects
        //    //  

        //    Boolean fOk = true;

        //    Microsoft.Office.Interop.PowerPoint.Application pptApplication = null;
        //    Microsoft.Office.Interop.PowerPoint.Presentation pptPresentation = null;
        //    string strPDF = strFile.ToLower().Replace(".ppt", ".pdf");

        //    try
        //    {

        //        object unknownType = Type.Missing;

        //        //start power point 
        //        pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();

        //        //
        //        //open powerpoint document
        //        //
        //        pptPresentation = pptApplication.Presentations.Open(strFile, Microsoft.Office.Core.MsoTriState.msoTrue,
        //            Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse);

        //        //
        //        // save PowerPoint as PDF
        //        //    
        //        pptPresentation.ExportAsFixedFormat(strPDF,
        //            Microsoft.Office.Interop.PowerPoint.PpFixedFormatType.ppFixedFormatTypePDF,
        //            Microsoft.Office.Interop.PowerPoint.PpFixedFormatIntent.ppFixedFormatIntentPrint,
        //            MsoTriState.msoFalse, Microsoft.Office.Interop.PowerPoint.PpPrintHandoutOrder.ppPrintHandoutVerticalFirst,
        //            Microsoft.Office.Interop.PowerPoint.PpPrintOutputType.ppPrintOutputSlides, MsoTriState.msoFalse, null,
        //            Microsoft.Office.Interop.PowerPoint.PpPrintRangeType.ppPrintAll, string.Empty, true, true, true,
        //            true, false, unknownType);

        //        if (!(File.Exists(strPDF)))
        //        {
        //            fOk = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        fOk = false;
        //    }

           

        //    //
        //    //  Quit PowerPoint and release the ApplicationClass object
        //    //

        //    finally
        //    {
        //        // Close and release the Document object.
        //        if (pptPresentation != null)
        //        {
        //            pptPresentation.Close();
        //            Util.releaseObject(pptPresentation);
        //            pptPresentation = null;
        //        }
        //        // Quit Word and release the ApplicationClass object.
        //        pptApplication.Quit();
        //        Util.releaseObject(pptApplication);
        //        pptApplication = null;
        //    }



        //    return fOk;
        //}

        

    }

    public class Util
    {
        public static void releaseObject(object obj)
        {
            Console.WriteLine("MethodName: releaseObject of Class: Util started");
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }

            catch (Exception exReleaseObject)
            {
                obj = null;
                //   Console.WriteLine(CMSResourceFile.REALESE_FAILED+ exReleaseObject);  

            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("MethodName: releaseObject of Class: Util ended");
        }

    }
}

