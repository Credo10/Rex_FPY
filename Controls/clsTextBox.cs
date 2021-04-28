using System;

namespace FPY
{
	using System;
	using System.Windows.Forms;

	public class clsTextBox : TextBox
	{

        public clsTextBox() : base()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

			protected override void OnKeyPress( KeyPressEventArgs e )
			{
				if ( e.KeyChar == (char) 13 )
				{
					SendKeys.Send ("{TAB}");
					e.Handled = true;
				}
				else
					base.OnKeyPress( e );
			}
	}
}

