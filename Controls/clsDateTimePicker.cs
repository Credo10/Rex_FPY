using System;

namespace FPY
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	public class basDateTimePicker : DateTimePicker
	{
		private SolidBrush m_BackBrush;

		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override Color BackColor 
		{
			get 
			{
				return base.BackColor;
			}
			set 
			{
				if (!(m_BackBrush == null)) 
				{
					m_BackBrush.Dispose();
				}
				base.BackColor = BackColor;
				m_BackBrush = new SolidBrush(this.BackColor);
				this.Invalidate();
			}
		}

		protected override void WndProc(ref Message m)
		{
			const Int32 WM_ERASEBKGND = 20;
			if (m.Msg == WM_ERASEBKGND) 
			{
				Graphics g = Graphics.FromHdc(m.WParam);
				if (m_BackBrush == null) 
				{
					m_BackBrush = new SolidBrush(this.BackColor);
				}
				g.FillRectangle(m_BackBrush, this.ClientRectangle);
				g.Dispose();
			} 
			else 
			{
				base.WndProc(ref m);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !(m_BackBrush == null)) 
			{
				m_BackBrush.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	
}
