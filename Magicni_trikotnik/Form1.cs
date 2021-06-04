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
        public Form1()
        {
            InitializeComponent();
            button13.FlatAppearance.BorderSize = 0;
            Gosenica.Izmisli();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button Sladica = (Button)sender;
            Gosenica.Sadje_imena.Add(Sladica.Text);
            Gosenica.Moje_sadje = Sladica.Text;

            if (Gosenica.Preveri_Rezultata())
            {
                MessageBox.Show("Mmmm njammm, " + Gosenica.Izbrano_sadje + " mi danes zelo tekne! Igraj naprej!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Gosenica.Izmisli();
                Gosenica.Poskusi = 0;
                label1.Text = Convert.ToString(Gosenica.Poskusi);
            }

            else
            {
                if (Gosenica.Poskusi > 0)
                {
                    Gosenica.Poskusi--;
                    label1.Text = Convert.ToString(Gosenica.Poskusi);

                    if (Gosenica.Poskusi == 2)
                    {
                        MessageBox.Show("Ne, " + Gosenica.Moje_sadje + " mi danes ne tekne! Imaš še " + Gosenica.Poskusi + " poskusa!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gosenica.Izmisli();
                    }

                    else if (Gosenica.Poskusi == 1)
                    {
                        MessageBox.Show("Ne, " + Gosenica.Moje_sadje + " mi danes ne tekne! Imaš še " + Gosenica.Poskusi + " poskus!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gosenica.Izmisli();
                    }

                    else
                    {
                        DialogResult Vprašaj = MessageBox.Show("Konec! Danes mi tekne " + Gosenica.Izbrano_sadje + "! Želiš ponovno igro?", "Gosenica Grita sporoča", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (Vprašaj == DialogResult.Yes)
                        {
                            Gosenica.Izmisli();
                            Gosenica.Poskusi = 0;
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
                MessageBox.Show("Sem že povedala, da mi " + Sladica.Text + " ne tekne danes!", "Gosenica Grita sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }

            else
            {
                Cursor = Cursors.Hand;
                Sladica.Size = new Size(102, 102);
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Button Sladica = (Button)sender;
            Sladica.Size = new Size(100, 100);
        }
    }
}
