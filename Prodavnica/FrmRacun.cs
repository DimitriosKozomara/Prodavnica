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
    public partial class FrmRacun : Form
    {
        static double racun = 0;
        BAZADataSet.ArtikalRow artikal;
        BAZADataSet ds;
        BAZADataSetTableAdapters.RacunTableAdapter daRacun;

        public FrmRacun()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridView1.Width = ClientRectangle.Width - 10;
            dataGridView1.Height = ClientRectangle.Height - 100;

            ds = new BAZADataSet();
            daRacun = new BAZADataSetTableAdapters.RacunTableAdapter();

            daRacun.Fill(ds.Racun);

            dataGridView1.Columns[0].Visible = false;
        }

        public void DodajNaListu(int kolicina, BAZADataSet.ArtikalRow a)
        {
            int kolicinaZaRacun = kolicina;
            this.artikal = a;
            int row = dataGridView1.Rows.Count;
            bool flag = false;
            if(row > 0)
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {// Ako artikal postoji na racunu
                    if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == artikal.id_artikal)
                    {
                        kolicina += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        dataGridView1.Rows[i].Cells[2].Value = kolicina.ToString();
                        row = i;
                        flag = true;
                        break;
                    }
                }

            //Ako artikal ne postoji
            if (!flag)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[0].Value = artikal.id_artikal;
                dataGridView1.Rows[row].Cells[1].Value = artikal.naziv;
                dataGridView1.Rows[row].Cells[2].Value = kolicina.ToString();
                dataGridView1.Rows[row].Cells[3].Value = artikal.popust;
                dataGridView1.Rows[row].Cells[4].Value = artikal.cena - artikal.cena * (artikal.popust / 100.0); 
            }
            
            if (artikal.popust == 0)
            {
                dataGridView1.Rows[row].Cells[5].Value = artikal.cena * kolicina;
                racun += artikal.cena * kolicinaZaRacun;
            }
            else
            {
                dataGridView1.Rows[row].Cells[5].Value = double.Parse(dataGridView1.Rows[row].Cells[4].Value.ToString()) * kolicina;
                racun += (artikal.cena - artikal.cena * (artikal.popust / 100.0)) * kolicinaZaRacun;
            }

            txtUkupno.Text = racun.ToString("N");

        }

        // Storniranje artikla duplim klikom na artikal u dgv-u
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DialogResult dr = MessageBox.Show("Obrisati odabrani artikal sa računa?", "Storniranje artikla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    racun -= double.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    txtUkupno.Text = (double.Parse(txtUkupno.Text) - double.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString())).ToString("N");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        
        private void btnIzdaj_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount > 0)
            {
                BAZADataSet.RacunRow red = ds.Racun.NewRacunRow();

                red.cena = double.Parse(txtUkupno.Text);
                red.datum = DateTime.Now.Date;
                red.vreme = DateTime.Now;

                ds.Racun.AddRacunRow(red);
                daRacun.Update(ds.Racun);
                MessageBox.Show("Uspešno izdat račun!", "Račun", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1.Rows.Clear();
                txtUkupno.Text = "0,00";
                racun = 0;
            }
            else
                MessageBox.Show("Ne možete izdati prazan račun!", "Greška");
        }
    }
}
