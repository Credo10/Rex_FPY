using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using HRLData;
using System.Collections.Generic;
using System;


namespace FPY
{
	public class clsFormUtil
	{

        public static Color GetHeaderColor(tblAppNavigation tbl)
        {
            Color col = new Color();

            try
            {
                string strColor = tbl.NAV_Color;

                col = System.Drawing.ColorTranslator.FromHtml(strColor);
            }
            catch (Exception ex)
            {
                col = Color.Ivory;
            }

            return col;
        }

        public static Color GetHeaderColor(string strColor)
        {
            Color col = new Color();

            try
            {
               
                col = System.Drawing.ColorTranslator.FromHtml(strColor);
            }
            catch (Exception ex)
            {
                col = Color.Ivory;
            }

            return col;
        }

        public static Color AdjustColor(Color colIn, int intTimes, Boolean fLight)
        {
            Color col = colIn;

            for (int i = 0; i <= intTimes; i++)
            {
                try
                {
                    if (fLight)
                    {
                        col = ControlPaint.Light(col);
                    }
                    else
                    {
                        //this didn't work too well
                        //col = ControlPaint.Dark(col);
                        HSLColor hslColor = new HSLColor(col);
                        hslColor.Luminosity *= 0.85; // 0 to 1
                        col = hslColor;
                    }
                }
                catch (Exception ex)
                {

                }
            }


            return col;
        }

        //Get a string containg a predefined system color name or a hex value and returns
        //an integer representing the RGB value of this color.
        public static int ConvertColorNameToValue(string ColorName)
        {

            Color TempColor;
            int result;
            //Check if the string is a system color name or a Hex number
            if (int.TryParse(ColorName, System.Globalization.NumberStyles.HexNumber, null, out result))
                TempColor = Color.FromArgb(result);
            else
                //The string is a system color name
                TempColor = Color.FromName(ColorName);
            return TempColor.ToArgb();
        }

        public static frmNavigate ReturnFormInst(string strForm)
        {

            clsForm frm = new clsForm();

            foreach(clsForm f in Application.OpenForms)
            {
                if (f.Name == strForm)
                {
                    frm = f;
                }
            }

            return (frmNavigate)frm;

        }

        public static DataGridViewCheckBoxColumn AddCheckBoxColumn(string strType, DataGridView gv)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            {

                chk.HeaderText = strType;
                chk.Name = strType;
                chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                chk.FlatStyle = FlatStyle.Standard;
                chk.ThreeState = false;
                chk.DataPropertyName = strType;

            }

            return chk;
        }




	}
}
