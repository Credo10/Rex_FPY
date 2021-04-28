using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FPY
{

    public class TypeAhead : TextBox
    {
        #region "Pivate Declares"

        private clsForm _frmParent;
        private Dictionary<int, string> _DataSource;
        private ListBox _listBox;
        private int _SelectedValue = 0;
        private bool _isAdded;
        private bool _HasMouse;
        private String _formerValue = String.Empty;
        private String _DefaultText = String.Empty;
        private int _lstWidth;

        #endregion

        public TypeAhead()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();
            this.KeyDown += this_KeyDown;
            this.KeyUp += this_KeyUp;
            this.Enter += this_Enter;
            this.Leave += this_Leave;
            _listBox.Click += this_Click;
            Font ft = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _listBox.Font = ft;
        }

        #region "Usage"

        //Add the following items to the partent form

        //whenever the selected value is changed the ModifiedChanged event is kicked off
        //use this to invoke some action on the parent form
        //private void ddlLNID_ModifiedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        TypeAhead txt = (TypeAhead)sender;

        //        if (txt.SelectedValue.ToString() + "" != "0")
        //        {
        //            BindGrid(0);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //put this code in the Form Load or Shown events to set he look ahead values
        //SetTypeAhead("DID", txtPQI, "--Select PQI--", 2);

        //this is a function to get the data to poulate the typeahead data
        //private void SetTypeAhead(string strID, TypeAhead txt, string strDefault, Int32 intVal)
        //{
        //    List<p_DropDown_Result> q2 = db.p_DropDown(this.APPID, this.tblNav.NAVID, strID, this.Parm1, this.Associate.ASID).ToList<p_DropDown_Result>();
        //    txt.ParentForm = this;
        //    txt.DefaultText = strDefault;
        //    txt.Text = strDefault;
        //    txt.DataSource = q2.ToDictionary(pl => pl.ID, pl => pl.Display);
        //    txt.lstWidth = txt.Width * intVal;
        //}

        #endregion

        #region "Declares"
        public string DefaultText
        {
            get
            {
                return _DefaultText;
            }
            set
            {
                _DefaultText = value;
            }
        }

      
        public clsForm ParentForm
        {
            get
            {
                return _frmParent;
            }
            set
            {
                _frmParent = value;
            }
        }
        public Dictionary<int, string> DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
            }
        }
        public ListBox ListBox
        {
            get
            {
                return _listBox;
            }
            set
            {
                _listBox = value;
            }
        }
        public int lstWidth
        {
            get
            {
                return _lstWidth;
            }
            set
            {
                _lstWidth = value;
            }
        }
        public int SelectedValue
        {
            get
            {
                return _SelectedValue;
            }
            set
            {
                _SelectedValue = value;
            }
        }

        #endregion
        private void ShowListBox()
        {
            if (!_isAdded)
            {
                this.Modified = false;
                _frmParent.Controls.Add(_listBox); // adds it to the form
                Point positionOnForm = _frmParent.PointToClient(this.Parent.PointToScreen(this.Location)); // absolute position in the form
                _listBox.Left = positionOnForm.X;
                _listBox.Top = positionOnForm.Y + Height;
                _isAdded = true;
                //AddMouseClickEvent(_frmParent); TODOCredo
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
            
        }
        private void ResetListBox()
        {
            _listBox.Visible = false;
            _listBox.SendToBack();
            this.Refresh();
        }
        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }
        private void UpdateSelectedValue()
        {
            Text = _listBox.Text.ToString();
            SelectedValue = Convert.ToInt32(_listBox.SelectedValue.ToString());
            ResetListBox();
            _formerValue = Text;
            this.Modified = true;
            //this.Select(this.Text.Length, 0);
        }
        private void this_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedValue();
               
            }
            catch(Exception ex)
            {

            }


        }
        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            _listBox.Width = _lstWidth;

            SelectedValue = 0;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            UpdateSelectedValue();
                            
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        e.Handled = true;
                        break;
                    }


            }
        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (_listBox.Visible)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }
        private void UpdateListBox()
        {
            if (Text == _formerValue)
                return;

            _formerValue = this.Text;
            string word = this.Text;


            if (_DataSource != null && word.Length > 0)
            {
               
                var matches = _DataSource.Where(z => z.Value.ToLower().Contains(word.ToLower())).ToList();

                if (matches.Count > 0)
                {
                    ShowListBox();
                    _listBox.BeginUpdate();
                    _listBox.DataSource = null;
                    _listBox.DataSource = new BindingSource(matches, null);
                    _listBox.DisplayMember = "Value";
                    _listBox.ValueMember = "Key";
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            if (i < 20)
                                _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            //int itemWidth = (int)graphics.MeasureString(((string)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            //_listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : this.Width; ;
                        }
                    }
                    _listBox.EndUpdate();
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }
        private void this_Enter(object sender, EventArgs e)
        {

            if (this.DefaultText + "" != "" && this.DefaultText == this.Text)
            {
                this.Text = "";
                this.TextAlign = HorizontalAlignment.Left;
            }

        }
        private void this_Leave(object sender, EventArgs e)
        {
            ResetTextbox(false);
        }
        private void this_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }
        public void ResetTextbox(Boolean fForce)
        {
            if (this.Text + "" == "" | fForce)
            {
                this.SelectedValue = 0;
                this.Text = this.DefaultText;
                this.TextAlign = HorizontalAlignment.Center;

            }
        }
        private void AddMouseClickEvent(Control parent)
        {
            //add a mouse click event so that if use clicks anywhere the list is hidden
            if (!_HasMouse)
            {
                _HasMouse = true;
                foreach (Control c in parent.Controls)
                {
                    if (c.HasChildren == true)
                    {
                        c.MouseDown += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                        AddMouseClickEvent(c);
                    }
                    else
                    {
                        string strType = c.GetType().ToString();
                        if (!(strType.Contains("TypeAhead")))
                        {
                            c.MouseDown += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                        }
                    }
                }
            }
        }
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            ResetListBox();
        }

    }
}

