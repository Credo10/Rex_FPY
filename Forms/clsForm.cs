using System;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using HRLData;
using RexrothData;


namespace FPY
{
	using System;
	using System.Windows.Forms;

    [Serializable]
    public class clsForm : Form
	{
		public clsForm() : base()
		{

		}
        // These values are shared by every clsForm

        //private static HRLData.tblAssociate _Associate;
        //private static tblAssociate _
	    private static vwAssociate _Associate;
        private static RexrothData.tblAssociate _RexAssoc;
        private static int _APPID;
        private string _AppName;
        tblAppNavigation _tblNav;
        private DataGridViewRow _row;
		private int _LNID;
        private int _TSID;
        private int _Image;
        private int _ECID;
        private int _Opt;
        private string _Form;
	    private int _BIID;
        private DataSet _ds;
        private string _Parm1;
        private string _Parm2;
        private string _Parm3;
        private string _RDL;
        private System.ComponentModel.IContainer components;
        private string _CurUser;
        private string _Token;


		public  int APPID
		{
			get
			{
				return _APPID;
			}
			set
			{
				_APPID = value;
			}
		}


        public DataGridViewRow Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        //public HRLData.tblAssociate Associate
        //{
        //    get
        //    {
        //        return _Associate;
        //    }
        //    set
        //    {
        //        _Associate = value;
        //    }
        //}

	    public vwAssociate Associate
	    {
	        get
	        {
	            return _Associate;
	        }
	        set
	        {
	            _Associate = value;
	        }
	    }

        public RexrothData.tblAssociate RexAssoc
        {
            get
            {
                return _RexAssoc;
            }
            set
            {
                _RexAssoc = value;
            }
        }

        public int Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }


        public tblAppNavigation tblNav
        {
            get
            {
                return _tblNav;
            }
            set
            {
                _tblNav = value;
            }
        }

     

        public int Opt
        {
            get
            {
                return _Opt;
            }
            set
            {
                _Opt = value;
            }
        }


        public DataSet ds
        {
            get
            {
                return _ds;
            }
            set
            {
                _ds = value;
            }
        }



        public string strForm
        {
            get
            {
                return _Form;
            }
            set
            {
                _Form = value;
            }
        }

        public string AppName
        {
            get
            {
                return _AppName;
            }
            set
            {
                _AppName = value;
            }
        }

        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }

        }

	    public int BIID
	    {
	        get
	        {
	            return _BIID;
	        }
	        set
	        {
	            _BIID = value;
	        }

	    }

        public string RDL
        {
            get
            {
                return _RDL;
            }
            set
            {
                _RDL = value;
            }
        }

        public string Parm1
        {
            get
            {
                return _Parm1;
            }
            set
            {
                _Parm1 = value;
            }
        }
 
        public string Parm2
        {
            get
            {
                return _Parm2;
            }
            set
            {
                _Parm2 = value;
            }
        }

        public  int LNID
		{
			get
			{
				return _LNID;
			}
			set
			{
				_LNID = value;
			}
		}

        public int TSID
        {
            get
            {
                return _TSID;
            }
            set
            {
                _TSID = value;
            }
        }


        public string Parm3
        {
            get
            {
                return _Parm3;
            }
            set
            {
                _Parm3 = value;
            }
        }

        public int ECID
        {
            get
            {
                return _ECID;
            }
            set
            {
                _ECID = value;
            }
        }


	    public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // clsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "clsForm";
            this.ResumeLayout(false);

        }

    }
}
