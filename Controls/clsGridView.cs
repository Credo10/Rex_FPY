using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace FPY
{

    using System;
	using System.Windows.Forms;

    [Serializable]
	public class clsGridView : DataGridView
	{
		public clsGridView() : base()
		{


            //this.Name = "gv1";
            DoubleBuffered = true;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllowUserToDeleteRows = false;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.DarkKhaki;
            this.RowHeadersVisible = false;
            this.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#" + "FFFFFA");
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            DataGridViewCellStyle AltRowStyle = new DataGridViewCellStyle();
            AltRowStyle.BackColor = Color.AliceBlue;
            AltRowStyle.SelectionBackColor = Color.LightBlue;
            AltRowStyle.SelectionForeColor = Color.Black;
            this.AlternatingRowsDefaultCellStyle = AltRowStyle;

            DataGridViewCellStyle VisibleHeadStyle = new DataGridViewCellStyle();
            VisibleHeadStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            VisibleHeadStyle.BackColor = Color.Beige;
            VisibleHeadStyle.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VisibleHeadStyle.ForeColor = Color.Black;
            VisibleHeadStyle.SelectionBackColor = Color.DarkKhaki;
            VisibleHeadStyle.SelectionForeColor = Color.Black;
            VisibleHeadStyle.WrapMode = DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = VisibleHeadStyle;

            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CellStyle.BackColor = System.Drawing.Color.White;
            CellStyle.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            CellStyle.SelectionBackColor = Color.LightBlue;
            CellStyle.SelectionForeColor = Color.Black;
            CellStyle.WrapMode = DataGridViewTriState.False;
            this.DefaultCellStyle = CellStyle;

           

        }
      
        const int WM_KEYDOWN = 0x0100;

        private  int _NAVID;
        private  int _PK;

        public int NAVID
        {
            get
            {
                return _NAVID;
            }
            set
            {
                _NAVID = value;
            }
        }

        public int PK
        {
            get
            {
                return _PK;
            }
            set
            {
                _PK = value;
            }
        }
      
    }
}


