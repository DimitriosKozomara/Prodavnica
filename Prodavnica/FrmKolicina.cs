using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class FrmKolicina : Form
    {
        BAZADataSet ds;
        string preth = "1";
        int tag;
        int kolicina;
        BAZADataSet.ArtikalRow artikal;
        FrmRacun frmRacun;
        public FrmKolicina()
        {
            InitializeComponent();
        }

        public FrmKolicina(BAZADataSet ds, FrmRacun frmRacun, int tag) : this()
        {
            this.tag = tag;
            this.ds = ds;
            this.frmRacun = frmRacun;

            var linq = this.ds.Artikal.Where(x => x.id_artikal == tag).First();
            this.artikal = linq;

            this.Text = artikal.naziv;
            this.kolicina = 1;

        }
        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            kolicina = int.Parse(txtKolicina.Text) + 1;
            txtKolicina.Text = kolicina.ToString();
        }
        

        private void txtKolicina_TextChanged(object sender, EventArgs e)
        {
            bool test = int.TryParse(txtKolicina.Text, out int broj);

            if (txtKolicina.Text.Length == 0)
            {
                txtKolicina.Text = "1";
                txtKolicina.SelectionStart = txtKolicina.Text.Length;
            }

            if (test && !txtKolicina.Text.Contains("-"))
            {
                txtKolicina.Text = broj.ToString();
                preth = txtKolicina.Text;
            }
            else
            {
                txtKolicina.Text = preth;
                txtKolicina.SelectionStart = txtKolicina.Text.Length;
            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        { 
            if(int.Parse(txtKolicina.Text) > 1)
            {
                kolicina = int.Parse(txtKolicina.Text) - 1;
                txtKolicina.Text = kolicina.ToString();
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            kolicina = int.Parse(txtKolicina.Text);
            frmRacun.DodajNaListu(kolicina, artikal);
            this.Close();
        }
    }
}
