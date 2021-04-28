using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.IO;
using HRLData;

namespace FPY
{
    public partial class frmNavigate : clsForm
    {
        public frmNavigate()
        {
            InitializeComponent();
        }


        #region declares

        private ListViewItem m_pItem = null;
        private int m_iMouseX = -1;
        private int m_iMouseY = -1;
        private static int intHeight;
        HRLEntities db = clsStart.efdb();
        private static List<vwAppButton> dsNav = new List<vwAppButton>();
        private static List<vwAppNavigation> dsIcon = new List<vwAppNavigation>();
        private bool loggedIn = false;
        private Color AppColor = Color.White;
        private Color AppColorDarker = Color.White;
        private Color AppColorDarkest = Color.Beige;



        #endregion

        #region Load

        private void frmNavigate_Load(object sender, EventArgs e)
        {
            //Int32 intASID = 0;

            try
            {
                Int32 intImage = Convert.ToInt32(this.Image);

                this.Icon = Icon.FromHandle(((Bitmap)this.lstImage.Images[intImage]).GetHicon());


            }
            catch (Exception ex)
            {

            }


          
            try
            {
                Random r = new Random();
                int x = r.Next(56);//Max range

                int i = 0;

                var assembly = Assembly.GetExecutingAssembly();
                foreach (var resourceName in assembly.GetManifestResourceNames())
                {

                    Debug.WriteLine(resourceName.ToString());

                    if (resourceName.ToString().EndsWith(".jpg"))
                    {



                        if (i == x)
                        {

                            Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName.ToString());
                            System.Console.WriteLine(stm.ToString());
                            Bitmap myIcon = new Bitmap(stm);
                            this.MDI.BackgroundImage = myIcon;
                        }

                        i = i + 1;
                    }
                }


            }
            catch (Exception ex)
            {

            }


            SetButtons();


        }

        public void SetButtons()
        {

            try
            {

                var controlsToRemove = pnlButtons.Controls.OfType<Button>().ToArray();
                foreach (var control in controlsToRemove)
                {
                    pnlButtons.Controls.Remove(control);
                }

            }
            catch (Exception ex)
            {

            }

            dsNav.RemoveAll((x) => x.APPID > 0);
            dsIcon.RemoveAll((x) => x.BTID > 0);

            //if user has the Menu rights then add the BTID of 1 to the button lists
            Int32 intBTID = 0;
            try
            {
                var qryMenu = (from ct in db.tblAppUser
                               join rl in db.tblAppRoles on ct.ARID equals rl.ARID
                               where ct.ASID == this.Associate.ASID
                               && rl.RLID == 1
                               select ct).First();

                intBTID = 1;
            }
            catch (Exception ex)
            {

            }


            if (intBTID == 1) //menu user
            {

                //find the use with the highest priveledges

                Int32 intARID = 0;

                var qryTop = (from app in db.vwAppButton
                              where app.APPID == this.APPID
                              orderby app.AB_Order descending
                              select app).First();

                intARID = qryTop.ARID;

                List<vwAppButton> qryBtn1 = (from app in db.vwAppButton
                                             where app.BTID == intBTID
                                             | app.ARID == intARID
                                             orderby app.AB_Order
                                             select app).ToList<vwAppButton>();

                dsNav = qryBtn1;


            }
            else
            {
                List<vwAppButton> qryBtn2 = new List<vwAppButton>();
                var multRoleList = new List<int>()
                    {
                        68, 76, 81, 82
                    };

               
                    qryBtn2 = (from app in db.vwAppButton
                        where app.ARID == this.Associate.ARID
                        orderby app.AB_Order
                        select app).ToList<vwAppButton>();
              


                dsNav = qryBtn2;
            }

            try
            {

                List<vwAppNavigation> qryIcons = (from nav in db.vwAppNavigation
                                                  where nav.NAV_Deleted.HasValue == false
                                                  && nav.NAV_Active == true
                                                  orderby nav.NAV_Order
                                                  select nav).ToList<vwAppNavigation>();

                dsIcon = qryIcons;

               

            }
            catch (Exception ex)
            {


            }



            try
            {
                AppColorDarkest = clsFormUtil.GetHeaderColor(Parm1);

                if (!(AppColor.IsEmpty))
                {

                    AppColorDarker = clsFormUtil.AdjustColor(AppColorDarkest, 5, true);              
                    AppColor = clsFormUtil.AdjustColor(AppColorDarker, 2, true);
                    lstIcons.BackColor = AppColor;
                   

                }
            }
            catch (Exception ex)
            {

            }


            if (dsNav != null)
            {
                Int32 i = 0;
                foreach (var r in dsNav)
                {

                    GradientPanel gp = new GradientPanel();
                    gp.BorderStyle = BorderStyle.FixedSingle;
                    
                    gp.PageEndColor = AppColorDarkest;
                    Label lbl = new Label();
                    lbl.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl.ForeColor = Color.Black;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.AutoSize = false;
                    lbl.BackColor = Color.Transparent;


                    gp.Height = 20;
                    intHeight = intHeight + 20;
                    gp.Name = i.ToString();
                    gp.Tag = r.AB_Order;
                    lbl.Text = r.BT_Desc;
                    lbl.Dock = DockStyle.Fill;
                    gp.Controls.Add(lbl);

                    this.pnlButtons.Controls.Add(gp);
                    


                    lbl.Click += new System.EventHandler(myButtonClickProc);
                    if (i == 0)
                    {
                        gp.Dock = DockStyle.Top;
                        Outlook(r.BTID);

                        //var lstLoadFirstForm = new int[] { 31 }; 

                        //if (lstLoadFirstForm.Contains(this.Associate.ARID))
                        //{
                           
                        //}
                        //else if (this.Associate.ASID == 1)
                        //{
                        //    try
                        //    {
                        //        ListViewItem clickedItem = lstIcons.Items[0];
                        //        Int32 intNAVID = Convert.ToInt32(clickedItem.Name);

                        //        tblAppNavigation tbl = (from ct in db.tblAppNavigation
                        //                                where ct.NAVID == intNAVID
                        //                                select ct).First<tblAppNavigation>();

                        //        OpenForm(tbl);
                        //    }
                        //    catch (Exception)
                        //    {

                        //    }
                        //}
                    }
                    else
                    {
                        gp.Dock = DockStyle.Bottom;
                    }
                    i = i + 1;

                }

            }

          

            this.pnlButtons.Visible = true;

        }


        private void frmNavigate_Shown(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    ListViewItem clickedItem = lstIcons.Items[0];
                    Int32 intNAVID = Convert.ToInt32(clickedItem.Name);

                    tblAppNavigation tbl = (from ct in db.tblAppNavigation
                                            where ct.NAVID == intNAVID
                                            select ct).First<tblAppNavigation>();

                    OpenForm(tbl);
                }
                catch (Exception)
                {

                }
                //var lstOpen = new int[] { 5, 6, 7, 16};
                //if (lstOpen.Contains(this.APPID))
                //{
                //    Int32 intItem = Convert.ToInt32(lstIcons.Items[0].Name.ToString());

                //    tblAppNavigation tbl = (from ct in db.tblAppNavigation
                //                            where ct.NAVID == intItem
                //                            select ct).First<tblAppNavigation>();

                //    OpenForm(tbl);
                //}
            }
            catch (Exception ex)
            {

            }

        }

        private void frmNavigate_SizeChanged(object sender, EventArgs e)
        {
            //base.OnSizeChanged(e);
            //this.Refresh();
        }

        #endregion

        #region formitems

        private void OpenForm(tblAppNavigation tbl)
        {
            string appName = Application.ProductName;
            string mForm = tbl.NAV_Item;


            try
            {
                

                if (tbl.NAV_Option == 1) //open form
                {

                    if (clsUtility.IsOpen(tbl) == false)
                    {


                       

                            Type oFormType = Type.GetType(appName + "." + mForm);
                            ConstructorInfo oConstructorInfo = oFormType.GetConstructor(System.Type.EmptyTypes);
                            //clsForm frm = (clsForm)oConstructorInfo.Invoke(null);

                            clsForm frm = (clsForm)Activator.CreateInstance(oFormType);

                            frm.Icon = Icon.FromHandle(((Bitmap)lstImage.Images[tbl.NAV_Image]).GetHicon());
                            frm.tblNav = tbl;
                            frm.Text = tbl.NAV_Desc;

                            frm.Token = this.Token;
                            frm.Associate = this.Associate;
                            frm.AppName = this.AppName;
                            frm.LNID = this.LNID;
                            frm.TSID = this.TSID;
                            frm.APPID = this.APPID;

                            string strDev = clsUtility.ConfigVal("DEV");

                          

                            var lstNav = new int[] { 51, 196, 198, 326, 374, 729};

                            if (lstNav.Contains(tbl.NAVID))
                            {
                                frm.WindowState = FormWindowState.Maximized;
                                this.Cursor = Cursors.WaitCursor;
                                frm.Show();
                                this.Cursor = Cursors.Default;
                            }
                            else if (tbl.NAVID == 311 && this.LNID==1)
                            {
                                frm.WindowState = FormWindowState.Maximized;
                                this.Cursor = Cursors.WaitCursor;
                                frm.Show();
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                frm.MdiParent = this;
                                this.Cursor = Cursors.WaitCursor;
                                frm.Show();
                                this.Cursor = Cursors.Default;
                                FillActiveChildFormToClient();
                            }

      
                        //}
                    }
                    else
                    {
                        clsUtility.Restore(tbl);
                    }
                }

                else if (tbl.NAV_Option == 7) //open help
                {

                    var qry = (from ct in db.tblApp
                               where ct.APPID == this.APPID
                               select ct).First();

                    string strNav = tbl.NAV_Item + this.Associate.AS_User + "&ORGID=" + qry.APP_HelpdeskOrg.ToString();

                    Process training = new Process();
                    training.StartInfo.FileName = strNav;
                    training.Start();

                }
            }
            catch (System.NullReferenceException Err)
            {
                Debug.WriteLine(Err.Message.ToString());
            }
            catch (Exception ErrorObject)
            {

                MessageBox.Show("Error opening form " + tbl.NAV_Item + " " + ErrorObject.Message, this.AppName);
            }

            finally
            {

            }

        }

        
        private void FillActiveChildFormToClient()
        {

            Form child = this.ActiveMdiChild;
            Rectangle mdiClientArea = Rectangle.Empty;

            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    mdiClientArea = c.ClientRectangle;
            }

            child.Bounds = mdiClientArea;

        }

        #endregion

        #region Icons


      
        public void myButtonClickProc(object sender, System.EventArgs e)
        {

            Label lbl = (Label)sender;
            Panel pnl = (Panel)lbl.Parent;
            int i = 0;

            try
            {
                var q = (from ct in dsNav
                        where ct.BT_Desc == lbl.Text
                        select ct).First();

                Outlook(Convert.ToInt32(q.BTID));


            }
            catch (System.ArgumentOutOfRangeException exArg)
            {
                Debug.WriteLine(exArg.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
            }

            //get sort for current button
            vwAppButton query = (from ds in dsNav
                                 where ds.BT_Desc == lbl.Text
                                 select ds).First();

            i = Convert.ToInt32(query.AB_Order);

            //set proper dock of buttons
            foreach (Control ctl in pnlButtons.Controls)
            {
                if (Convert.ToInt32(ctl.Tag) <= i && ctl.Name != "lstIcons")
                {
                    ctl.Dock = DockStyle.Top;
                }
                else if (Convert.ToInt32(ctl.Tag) > i && ctl.Name != "lstIcons")
                {
                    ctl.Dock = DockStyle.Bottom;
                }
            }

            //set order original
            Int32 k = 1;
            foreach (var it in dsNav)
            {
                Panel pnl2 = (Panel)pnlButtons.Controls[k];
                pnl2.Controls[0].Text = it.BT_Desc;
                k = k + 1;
            }

            ////set text of buttons in revsere order, if order is less than or equal to current button
            var query2 = from ds in dsNav
                         where ds.AB_Order <= i
                         orderby ds.AB_Order descending
                         select ds;

            Int32 j = 1;
            foreach (var it in query2)
            {
                Panel pnl2 = (Panel)pnlButtons.Controls[j];
                pnl2.Controls[0].Text = it.BT_Desc;
                j = j + 1;
            }

        }

        public void Outlook(int intBut)
        {

            this.lstIcons.Clear();
            this.Cursor = Cursors.WaitCursor;

            HRLEntities db = clsStart.efdb();


            //select from previosly saved query
            var query = from nav in dsIcon
                        where nav.BTID == intBut
                        orderby nav.NAV_Order
                        select nav;


            try
            {
                Int32 i = 0;
                foreach (var r in query)
                {
                    this.lstIcons.Items.Add(r.NAV_Desc);
                    this.lstIcons.Items[i].ImageIndex = r.NAV_Image;
                    this.lstIcons.Items[i].Name = r.NAVID.ToString();

                    i = i + 1;
                }
            }
            catch (System.ArgumentOutOfRangeException exc)
            {
                Debug.WriteLine("Out of range" + exc.Message);
            }
            if (this.lstIcons.Items.Count > 9)
            {
                this.pnlButtons.Width = 115;
            }
            else
            {
                this.pnlButtons.Width = 88;
            }
            this.Cursor = Cursors.Arrow;

        }

        private void lstIcons_MouseLeave(object sender, EventArgs e)
        {
            m_iMouseX = -1;
            m_iMouseY = -1;
            RefreshItem();
        }

        private void lstIcons_MouseMove(object sender, MouseEventArgs e)
        {
            m_iMouseX = e.X;
            m_iMouseY = e.Y;
            RefreshItem();
        }

        private void lstIcons_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            ListViewItem clickedItem = lstIcons.GetItemAt(m_iMouseX, m_iMouseY);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
                Int32 intNAVID = Convert.ToInt32(clickedItem.Name);

                tblAppNavigation tbl = (from ct in db.tblAppNavigation
                                        where ct.NAVID == intNAVID
                                        select ct).First<tblAppNavigation>();

                OpenForm(tbl);
            }
        }

        private void RefreshItem()
        {
            ListViewItem pItem = lstIcons.GetItemAt(m_iMouseX, m_iMouseY);

            if (pItem != m_pItem)
            {
                lstIcons.BeginUpdate();
                if (m_pItem != null)
                {
                    // m_pItem.Font = m_pFontRegular;
                    m_pItem.ForeColor = Color.Black;
                }

                //now point to current item (may be nothing)
                m_pItem = pItem;

                // update current item, if any
                if (m_pItem != null)
                {
                    //m_pItem.Font = m_pFontUnderline; //doesn't work for some reason
                    m_pItem.ForeColor = Color.Blue;
                }
                lstIcons.EndUpdate();
            }
            // now update the cursor
            if (m_pItem != null)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

    }
}
