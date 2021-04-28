using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace FPY
{
    /// <summary>
    /// Summary description for clsCombo.
    /// </summary>
    public class clsCombo : System.Windows.Forms.ComboBox
    {
        public event System.ComponentModel.CancelEventHandler NotInList;
        private const int WM_KEYUP = 0x101;
        private bool _limitToList = true;
        private bool _inEditMode = false;

        public clsCombo()
            : base()
        {
        }

        [Category("Behavior")]
        public bool LimitToList
        {
            get { return _limitToList; }
            set { _limitToList = value; }
        }

        private int _windows7CorrectedSelectedIndex = -1;

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            _windows7CorrectedSelectedIndex = SelectedIndex;
            base.OnSelectionChangeCommitted(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            _windows7CorrectedSelectedIndex = SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)13)
        //    {
        //        //SendKeys.Send("{TAB}");
        //        e.Handled = true;
        //    }
        //    else
        //        base.OnKeyPress(e);
        //}

        //protected override void OnDropDownClosed(EventArgs e)
        //{
        //    base.OnDropDownClosed(e);
        //    if (SelectedIndex != _windows7CorrectedSelectedIndex) SelectedIndex = _windows7CorrectedSelectedIndex;
        //}

        protected virtual void
            OnNotInList(System.ComponentModel.CancelEventArgs e)
        {
            if (NotInList != null)
            {
                NotInList(this, e);
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_KEYUP)
            {
                //ignore keyup to avoid problem with tabbing & dropdownlist;
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            if (_inEditMode)
            {
                string input = Text;
                int index = FindString(input);

                if (index >= 0)
                {
                    _inEditMode = false;
                    SelectedIndex = index;
                    _inEditMode = true;
                    Select(input.Length, Text.Length);
                }
            }

            base.OnTextChanged(e);
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (this.LimitToList)
            {
                int pos = this.FindStringExact(this.Text);

                if (pos == -1)
                {
                    OnNotInList(e);
                }
                else
                {
                    this.SelectedIndex = pos;
                }
            }

            base.OnValidating(e);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            //_inEditMode = (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete);

            if (e.KeyCode == Keys.Enter &&  SelectedValue != null && SelectedIndex != 0)
            {
                OnSelectedValueChanged(e);
            }
            //SelectedValueChanged(sender, e);
            base.OnKeyDown(e);
        }
    }
}
