using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magicni_trikotnik
{
    public partial class Form1 : Form
    {
        public void Uredi()
        {
            Gosenica.Stevec = 0;

            for (int indeks = 0; indeks < Gosenica.Pozicije_X.Count; indeks++)
            {
                Gosenica.Moj_Rezultat = Gosenica.Izberi_nakljucno.Next(Gosenica.Stevila.Count);
                Controls[indeks].Location = new Point(Gosenica.Pozicije_X[indeks], Gosenica.Pozicije_Y[indeks]);
                Controls[indeks].Text = Convert.ToString(Gosenica.Stevila[Gosenica.Moj_Rezultat]);
                Gosenica.Stevila.RemoveAt(Gosenica.Moj_Rezultat);
                Controls[indeks].Visible = true;
            }

            for (int indeks = 0; indeks < Gosenica.Stevila.Length; indeks++)
            {
                if ()
            }
        }

        public Form1()
        {
            InitializeComponent();

            Controls.SetChildIndex(button13, 13);
            Controls.SetChildIndex(pictureBox2, 13);
            Controls.SetChildIndex(button13, 13);
            button13.FlatAppearance.BorderSize = 0;

            Gosenica.Uredi_vse();
            Uredi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gosenica.Stevec++;
            Button Sladica = (Button)sender;

            switch (Gosenica.Stevec)
            {
                case 1:
                    Sladica.Location = new Point(467, 592);
                    break;

                case 2:
                    Sladica.Location = new Point(381, 610);
                    break;

                case 3:
                    Sladica.Location = new Point(295, 610);
                    break;

                default:
                    Sladica.Location = new Point(209, 556);

                    if (Gosenica.Preveri_Rezultata())
                    {
                        MessageBox.Show("BRAVO! Okusna števila, hihihi!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gosenica.Uredi_vse();
                        Uredi();
                    }

                    else
                    {
                        MessageBox.Show("NAROBE! Vse sštevilke niso prave!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gosenica.Uredi_vse();
                        Uredi();
                    }
                    break;
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Button Sladica = (Button)sender;
            Sladica.Size = new Size(82, 75);          
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Button Sladica = (Button)sender;
            Sladica.Size = new Size(80, 73);
        }
    }
}
