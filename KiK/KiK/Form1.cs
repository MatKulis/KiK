using System;
using System.Drawing;
using System.Windows.Forms;

namespace KiK
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public Form1()
		{

			InitializeComponent();
			

		}
		void GrajClick(object sender, EventArgs e)
		{
			MainForm.UstawNazwy(gracz1.Text,gracz2.Text);
			this.Close();
	
		}
		void Gracz2KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() =="\r")
				Graj.PerformClick();
	
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
