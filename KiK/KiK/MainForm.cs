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
	{	bool kolejka =true;// true = kolejka X false = kolejka O
		int liczba_kolejek=0;
		static String gracz1, gracz2;
		bool zKomputerem=false;
		
		
		public MainForm()
		{
			
			InitializeComponent();
			
			
		}
		public static void UstawNazwy(String g1, String g2){
		
			gracz1=g1;	
			gracz2=g2;
		
		}
		
		void Button3Click(object sender, EventArgs e)
		{
	
		}
		
		void ZasadyGryToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Gracze obejmują pola na przemian dążąc do objęcia trzech pól w jednej linii, przy jednoczesnym uniemożliwieniu tego samego przeciwnikowi." +
			                " Pole pole zajęte przez jednego z graczy nie może zmienić właściciela aż do ukończenia rundy.","Zasady gry");
		}
		
		void AutorzyToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Wiktor Łopatka" +"\nMateusz Kuliś","Autorzy");
		}
		
		void WyjścieToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void przycisk_klik(object sender, EventArgs e)
		{
		 	Button b =(Button)sender;
		 	
			if (kolejka){
		 		
		 		b.Text="X";
				kolej.Text="Kolejka gracza "+gracz2;
			}
			else
			{
				b.Text="O";
				kolej.Text="Kolejka gracza "+gracz1;
			}
			kolejka=!kolejka;
			b.Enabled=false;
			liczba_kolejek++;
			SprawdzWygrana();
			
		}
		
		private void SprawdzWygrana(){
			bool wygrana=false;
			
			//Rzędy
			if((A1.Text==A2.Text)&&(A2.Text==A3.Text)&&(!A1.Enabled)) wygrana=true;
			
			if((B1.Text==B2.Text)&&(B2.Text==B3.Text)&&(!B1.Enabled)) wygrana=true;
			
			if((C1.Text==C2.Text)&&(C2.Text==C3.Text)&&(!C1.Enabled)) wygrana=true;
			
			//Kolumny
			if((A1.Text==B1.Text)&&(B1.Text==C1.Text)&&(!A1.Enabled)) wygrana=true;
			
			if((A2.Text==B2.Text)&&(B2.Text==C2.Text)&&(!A2.Enabled)) wygrana=true;
			
			if((A3.Text==B3.Text)&&(B3.Text==C3.Text)&&(!A3.Enabled)) wygrana=true;
			
			//Na ukos
			if((A1.Text==B2.Text)&&(B2.Text==C3.Text)&&(!A1.Enabled)) wygrana=true;
			
			if((A3.Text==B2.Text)&&(B2.Text==C1.Text)&&(!A3.Enabled)) wygrana=true;
			
		
		
		
			if(wygrana) {
				WylaczPrzyciski();
				string zwyciezca="";
				if (!kolejka)
				{
				zwyciezca=gracz1;
				WygraneX.Text=(Int32.Parse(WygraneX.Text)+1).ToString();
				}
					else
					{
				zwyciezca=gracz2;
				WygraneO.Text=(Int32.Parse(WygraneO.Text)+1).ToString();
					}
				MessageBox.Show(zwyciezca+" wygrywa!","Gratulacje!");
				kolej.Text="Gratulacje!";
						}
			else
			{
				if(liczba_kolejek==9)
				{ MessageBox.Show("Remis.","Koniec gry.");
					Remis.Text=(Int32.Parse(Remis.Text)+1).ToString();
					kolej.Text="Koniec gry.";
				}
			}
		}
		
		
		
		
		
		private void WylaczPrzyciski(){
			
			foreach(Control c in Controls){
				try{
				Button b =(Button)c;
				b.Enabled=false;
			}
				catch{}
			}
			
		}
		void NowaGraToolStripMenuItemClick(object sender, EventArgs e)//Zaczyna nowa gre z resetowaniem liczników
		{	kolejka=true;
			liczba_kolejek=0;
			
			WygraneX.Text="0";
			WygraneO.Text="0";
			Remis.Text="0";
			
			foreach(Control c in Controls){
				try{
				Button b =(Button)c;
				b.Enabled=true;
				b.Text="";
			}
				catch{}
			}
			
				
		}
		void Najazd(object sender, EventArgs e)
		{	Button b =(Button)sender;
		 	
			if (b.Enabled){
				if (kolejka){
		 		
		 		b.Text="X";
		 		

			}
			else
			{	
				b.Text="O";
				
				
			}
			}
	
		}
		void Zjazd(object sender, EventArgs e)
		{	Button b =(Button)sender;
		 	
			if (b.Enabled) b.Text="";
				
				
			
		}
		void NowaRundaToolStripMenuItemClick(object sender, EventArgs e)//Zaczyna nową runde bez resetowania liczników
		{

			kolejka=true;
			liczba_kolejek=0;
			
			foreach(Control c in Controls){
				try{
				Button b =(Button)c;
				b.Enabled=true;
				b.Text="";
			}
				catch{}
		}
	
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			Form okno1 = new Form1();
			okno1.ShowDialog();
			if(string.IsNullOrWhiteSpace(gracz1)) gracz1="X";
			if(string.IsNullOrWhiteSpace(gracz2)) gracz2="O";
			
			kolej.Text="Kolejka gracza "+gracz1;
			label1.Text=gracz1;
			
			
			if (gracz2=="Komputer"){zKomputerem=true;}
			label3.Text=gracz2;
			if(zKomputerem){MessageBox.Show("Grasz z komputerem");}
			
			
		}
		void UruchomPonownieToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Restart();
		}
		void ObjaśnieniaToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Nowa gra - zaczyna grę odnowa zerując licznik wygranych/porażek zachowując nazwy graczy." +
			                "\n Nowa runda - zaczyna grę odnowa zachowując nazwy graczy i licznik wygranych/porażek."+
			               "\nUruchom ponownie - uruchamia ponownie grę dajac możliwośc zmiany nazw graczy lub gry z komputerem."+
			              "\nWyjście - zamyka grę.","Objaśnienia Menu.");
		}

	}

	}

