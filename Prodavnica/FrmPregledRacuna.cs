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
    public partial class FrmPregledRacuna : Form
    {
        BAZADataSet ds;
        BAZADataSetTableAdapters.RacunTableAdapter daRacun;
        public FrmPregledRacuna()
        {
            InitializeComponent();
        }
        public FrmPregledRacuna(BAZADataSet ds) : this()
        {
            this.ds = ds;   
            daRacun = new BAZADataSetTableAdapters.RacunTableAdapter();

            daRacun.Fill(ds.Racun);
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            DateTime datumOd = dtDatumOd.Value.Date;
            DateTime datumDo = dtDatumDo.Value.Date;
            TimeSpan vremeOd = dtVremeOd.Value.TimeOfDay;
            TimeSpan vremeDo = dtVremeDo.Value.TimeOfDay;

            if (dataGridView1.DataSource != null)
                dataGridView1.DataSource = null;

            if (datumOd > datumDo)
            {
                MessageBox.Show("Pogrešan opseg datuma!", "Greška");
                return;
            }

            if (vremeOd >= vremeDo)
            {
                MessageBox.Show("Pogrešan opseg vremena!", "Greška");
                return;
            }

            var linq = ds.Racun.Where(x => x.datum.Date >= datumOd && x.datum.Date <= datumDo &&
                                       x.vreme.TimeOfDay >= vremeOd && x.vreme.TimeOfDay <= vremeDo);

            
            if (linq.Any())
            {
                dataGridView1.DataSource = linq.CopyToDataTable();
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
                dataGridView1.Columns["vreme"].DefaultCellStyle.Format = "HH:mm:ss";
                
                dataGridView1.Font = new Font("Arial", 12);
                dataGridView1.Columns[0].HeaderText = "Broj računa";
                dataGridView1.Columns[1].HeaderText = "Cena";
                dataGridView1.Columns[2].HeaderText = "Datum";
                dataGridView1.Columns[3].HeaderText = "Vreme";

                dataGridView1.Columns[0].Width = 140;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 140;
                dataGridView1.Columns[3].Width = 120;
            }
            else
            {
                MessageBox.Show("Nema računa u zadatom vremenu!", "Nema rezultata");
            }

        }
    }
}
