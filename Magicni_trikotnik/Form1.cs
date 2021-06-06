using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Threading;

namespace Magicni_trikotnik
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer Igralnik = new WindowsMediaPlayer();
        WindowsMediaPlayer Igralnik_2 = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            button13.FlatAppearance.BorderSize = 0;
            Gosenica.Izmisli();
            Cursor = new Cursor(Application.StartupPath + "\\Miska\\gosenica_1.ico");
            Igralnik_2.settings.setMode("loop", true);
            Igralnik_2.settings.volume = 50;
            Igralnik_2.URL = "ozadje.mp3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button Sladica = (Button)sender;
            Gosenica.Sadje_imena.Add(Sladica.Text);
            Gosenica.Moje_sadje = Sladica.Text;

            if (Gosenica.Preveri_Rezultata())
            {
                Igralnik.URL = "ja.wav";
                MessageBox.Show("Mmmm njammm, " + Gosenica.Izbrano_sadje + " mi danes zelo tekne! Igraj naprej!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Gosenica.Izmisli();
                Gosenica.Poskusi = 3;
                label2.Visible = false;
                label1.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label1.Text = Convert.ToString(Gosenica.Poskusi);
            }

            else
            {
                if (Gosenica.Poskusi > 0)
                {
                    Igralnik.URL = "ne.wav";
                    Gosenica.Poskusi--;
                    label1.Text = Convert.ToString(Gosenica.Poskusi);

                    if (Gosenica.Poskusi == 2)
                    {
                        MessageBox.Show("Ne, " + Gosenica.Moje_sadje + " mi danes ne tekne! Imaš še " + Gosenica.Poskusi + " poskusa!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Gosenica.Poskusi == 1)
                    {
                        label2.Visible = true;
                        label1.ForeColor = Color.Red;
                        label3.ForeColor = Color.Red;
                        MessageBox.Show("Ne, " + Gosenica.Moje_sadje + " mi danes ne tekne! Imaš še " + Gosenica.Poskusi + " poskus!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        Igralnik.URL = "konec_igre.wav";
                        label2.Visible = false;
                        DialogResult Vprašaj = MessageBox.Show("Konec! Danes mi tekne " + Gosenica.Izbrano_sadje + "! Želiš ponovno igro?", "Gosenica Grita sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (Vprašaj == DialogResult.Yes)
                        {
                            Gosenica.Izmisli();
                            Gosenica.Poskusi = 3;
                            label3.ForeColor = Color.Black;
                            label1.ForeColor = Color.Black;
                            label1.Text = Convert.ToString(Gosenica.Poskusi);
                        }

                        else
                        {
                            MessageBox.Show("Lepo se imej in adijo!", "Gosenica Grita pozdravlja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Button Sladica = (Button)sender;

            if (Gosenica.Sadje_imena.Contains(Sladica.Text))
            {
                Igralnik.URL = "nonono.wav";
                MessageBox.Show("Sem že povedala, da mi " + Sladica.Text + " ne tekne danes!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }

            else
            {
                Igralnik.URL = "klik.wav";
                Sladica.Size = new Size(102, 102);
                Cursor = new Cursor(Application.StartupPath + "\\Miska\\gosenica_2.ico");
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Button Sladica = (Button)sender;
            Sladica.Size = new Size(100, 100);
            Cursor = new Cursor(Application.StartupPath + "\\Miska\\gosenica_1.ico");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Igralnik.URL = "klik.wav";
            Cursor = new Cursor(Application.StartupPath + "\\Miska\\gosenica_2.ico");
            Thread.Sleep(300);
            Cursor = new Cursor(Application.StartupPath + "\\Miska\\gosenica_1.ico");
        }
    }
}
