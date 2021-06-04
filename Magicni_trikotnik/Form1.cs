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
