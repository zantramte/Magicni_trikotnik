using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
                ControlExtension.Draggable(Controls[indeks], true);
            }
        }

        public Form1()
        {
            InitializeComponent();

            foreach (Control Kontrola in Controls)
            {
                if (Kontrola is Button)
                {
                    ControlExtension.Draggable(Kontrola, true);
                    Gosenica.Pozicije_X.Add(Kontrola.Location.X);
                    Gosenica.Pozicije_Y.Add(Kontrola.Location.Y);
                }
            }

            Gosenica.Uredi_vse();
            Uredi();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox Jabolko = (PictureBox)sender;
            Jabolko.Image = Properties.Resources.jabolko_2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox Jabolko = (PictureBox)sender;
            Jabolko.Image = Properties.Resources.jabolko;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Gosenica.Stevec++;
            Button Sladica = (Button)sender;
            ControlExtension.Draggable(Sladica, false);
            Gosenica.Rezultat += Convert.ToInt32(Sladica.Text);

            switch (Gosenica.Stevec)
            {
                case 1:
                    Sladica.Location = new Point(458, 601);
                    break;

                case 2:
                    Sladica.Location = new Point(341, 614);
                    break;

                default:
                    Sladica.Location = new Point(224, 568);
                    await Task.Delay(200);

                    if (Gosenica.Preveri_Rezultata())
                    {
                        MessageBox.Show("BRAVO! Okusna sladica, hihihi!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gosenica.Uredi_vse();
                        Uredi();
                    }

                    else
                    {
                        MessageBox.Show("NAROBE! Vse sladice niso prave!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
