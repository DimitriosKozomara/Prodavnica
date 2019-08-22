using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class FrmNoviArtikal : Form
    {
        BAZADataSet ds;
        BAZADataSetTableAdapters.ArtikalTableAdapter daArtikli;

        public FrmNoviArtikal()
        {
            InitializeComponent();
        }

        public FrmNoviArtikal(BAZADataSet ds, BAZADataSetTableAdapters.ArtikalTableAdapter daArtikli) : this()
        {
            this.ds = ds;
            this.daArtikli = daArtikli;

            //Grupe ciji id roditelja se ne nalazi u id grupe
            var trazeneGrupe = ds.Grupa.Except(ds.Grupa.Where(x => ds.Grupa.Select(y => y.id_roditelj).Contains(x.id_grupa)));
            cbGrupe.DataSource = trazeneGrupe.ToList();
            cbGrupe.DisplayMember = "naziv";
            cbGrupe.ValueMember = "id_grupa";

            txtPopust.Text = "0";
        }

        private string SrediCenu(string text)
        {
            StringBuilder sb = new StringBuilder(text);
            if (text.Contains("."))
                sb.Replace('.', ',');
            return sb.ToString();
        }

        private void btnDodajArtikal_Click(object sender, EventArgs e)
        {
            Validacija();
        }

        private void Validacija()
        {
            string naziv = txtNaziv.Text;
            string cena = SrediCenu(txtCena.Text);
            string popust = txtPopust.Text;

            if (naziv.Trim().Length != 0 && cena.Trim().Length != 0 && popust.Trim().Length != 0 && cbGrupe.Text.Trim().Length != 0)
            {
                if (!double.TryParse(cena, out double cenaArtikla) || cenaArtikla <= 0)
                {
                    MessageBox.Show("Pogrešan unos cene!", "Greška");
                    return;
                }
                if (!short.TryParse(popust, out short popustArtikla) || popustArtikla < 0 || popustArtikla >= 100)
                {
                    MessageBox.Show("Pogrešan unos popusta!", "Greška");
                    return;
                }
                //Provera poklapanja imena
                var artikalLinq = ds.Artikal.Where(x => x.naziv.Trim().ToLower().Equals(naziv.Trim().ToLower()));

                if (!artikalLinq.Any())
                {
                    naziv = naziv.Trim();
                    naziv = char.ToUpper(naziv[0]) + naziv.Substring(1);

                    DialogResult dr = MessageBox.Show("Dodati artikal u \"" + cbGrupe.Text + "\" grupu?", naziv, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return;

                    BAZADataSet.ArtikalRow red = ds.Artikal.NewArtikalRow();

                    red.naziv = naziv;
                    red.cena = cenaArtikla;
                    red.popust = popustArtikla;
                    red.id_grupa = int.Parse(cbGrupe.SelectedValue.ToString());
                    
                    ds.Artikal.AddArtikalRow(red);
                    daArtikli.Update(ds.Artikal);
                    MessageBox.Show("Artikal uspešno dodat!", naziv);
                }
                else
                    MessageBox.Show("Artikal već postoji!", "Greška");
                
            }
            else if (cbGrupe.Text.Trim().Length == 0)
                MessageBox.Show("Odaberite grupu!", "Greška");
            else
                MessageBox.Show("Niste popunili sva polja!", "Greška");
        }
    }
}
