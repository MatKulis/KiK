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
        bool kolejka = true;
        int liczba_kolejek = 0;
            

        public MainForm()
		{
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
        void przycisk_klik(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (kolejka)
            {

                b.Text = "X";

            }
            else
            {
                b.Text = "O";

            }
            kolejka = !kolejka;
            b.Enabled = false;
            liczba_kolejek++;
            SprawdzWygrana();
        }
            private void SprawdzWygrana()
        {
            bool wygrana = false;
            //rzędy
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) wygrana = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) wygrana = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) wygrana = true;
            //kolumny
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) wygrana = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) wygrana = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) wygrana = true;
            //na ukos
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) wygrana = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) wygrana = true;

            if (wygrana)
            {
                WylaczPrzyciski();
                string zwyciezca = "";
                if (!kolejka)
                    zwyciezca = "X";
                else
                    zwyciezca = "O";

                MessageBox.Show(zwyciezca + " wygrywa!", "Koniec gry.");
            }
            else
                if (liczba_kolejek == 9) MessageBox.Show("Remis.", "Koniec gry.");
        }
        private void WylaczPrzyciski()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
            void NowaGraToolStripMenuItemClick(object sender, EventArgs e)
        {
            kolejka = true;
            liczba_kolejek = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
