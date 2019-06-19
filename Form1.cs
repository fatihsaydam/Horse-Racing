using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisi
{
    public partial class frmAtYarisi : Form
    {

        Random rd = new Random();

        Random bhs = new Random();

        int konum1, konum2, konum3;

        double muhtemelKazanc1, muhtemelKazanc2, muhtemelKazanc3, oran1, oran2, oran3;

        public frmAtYarisi()
        {
            InitializeComponent();
        }

        private void frmAtYarisi_Load(object sender, EventArgs e)
        {
            tmrBaslat.Stop();

            oran1 = bhs.Next(100, 401);
            oran1 = oran1 / 100;
            txtBirinciAtOrani.Text = oran1.ToString();

            oran2 = bhs.Next(100, 401);
            oran2 = oran2 / 100;
            txtIkinciAtOrani.Text = oran2.ToString();

            oran3 = bhs.Next(100, 401);
            oran3 = oran3 / 100;
            txtUcuncuAtOrani.Text = oran3.ToString();

            
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            tmrBaslat.Stop();

            btnBasla.Text = "Devam Et";

            if (btnDurdur.Text == "Sıfırla")
            {
                pcbBirinciAt.Left = konum1;
                pcbIkinciAt.Left = konum2;
                pcbUcuncuAt.Left = konum3;

                btnBasla.Text = "Başla";
            }

            else if (btnDurdur.Text == "Durdur")
            {
                btnDurdur.Text = "Sıfırla";
            }

        }

        private void tmrBaslat_Tick(object sender, EventArgs e)
        {
            pcbBirinciAt.Left += rd.Next(0, 11);
            pcbIkinciAt.Left += rd.Next(0, 11);
            pcbUcuncuAt.Left += rd.Next(0, 11);           

            if (pcbBirinciAt.Right >= btnFinish.Left)
            {
                tmrBaslat.Stop();

                if (cmbAtListele.SelectedIndex == 0)
                {
                    muhtemelKazanc1 = oran1 * (Convert.ToDouble(txtBahisKoy.Text));

                    MessageBox.Show("1.At Kazandı.\n" + muhtemelKazanc1+" TL kazandınız.");
                }

                else
                {
                    MessageBox.Show("1.At Kazandı.\n"+ Convert.ToDouble(txtBahisKoy.Text)+ " TL kaybettiniz.");
                }              
            }

            

            if (pcbIkinciAt.Right >= btnFinish.Left)
            {
                tmrBaslat.Stop();

                if (cmbAtListele.SelectedIndex == 1)
                {
                    muhtemelKazanc2 = oran2 * Convert.ToDouble(txtBahisKoy.Text);

                    MessageBox.Show("2.At Kazandı.\n" + muhtemelKazanc2 + " TL kazandınız.");
                }

                else
                {
                    MessageBox.Show("2.At Kazandı.\n" + Convert.ToDouble(txtBahisKoy.Text) + " TL kaybettiniz.");
                }
            }

            

            if (pcbUcuncuAt.Right >= btnFinish.Left)
            {
                tmrBaslat.Stop();

                if (cmbAtListele.SelectedIndex == 2)
                {
                    muhtemelKazanc3 = oran3 * Convert.ToDouble(txtBahisKoy.Text);

                    MessageBox.Show("3.At Kazandı.\n " + muhtemelKazanc3 + " TL kazandınız.");
                }

                else
                {
                    MessageBox.Show("3.At Kazandı.\n" + Convert.ToDouble(txtBahisKoy.Text) + " TL kaybettiniz.");
                }
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            tmrBaslat.Start();
        }
    }
}
