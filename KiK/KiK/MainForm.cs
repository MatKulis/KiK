using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KiK
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
            bool kolejka = true;
            int liczba_kolejek = 0;
            InitializeComponent();
			
			
		}
		void Button3Click(object sender, EventArgs e)
		{
	
		}
		void ZasadyGryToolStripMenuItemClick(object sender, EventArgs e)
		{
            MessageBox.Show("Jeden gracz jest krzyzykiem, drugi gracz kolkiem. Wygrywa gracz ktory bedzie mial 3 krzyzyki lub kolka w pionowej, poziomowej lub ukosnej lini.");
		}
		void AutorzyToolStripMenuItemClick(object sender, EventArgs e)
		{
            MessageBox.Show("Wiktor Łopatka, Mateusz Kulis");
		}
		void WyjścieToolStripMenuItemClick(object sender, EventArgs e)
		{
            Application.Exit();
        }

        private void A1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
