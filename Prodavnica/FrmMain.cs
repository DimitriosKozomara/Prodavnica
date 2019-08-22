using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class FrmMain : Form
    {
        List<BAZADataSet.ArtikalRow> listaArtikla;
        FrmContainer frmContainer;
        FrmRacun frmRacun;
        private delegate void promeniLabelu();

        BAZADataSet ds;
        BAZADataSetTableAdapters.GrupaTableAdapter daGrupe;
        BAZADataSetTableAdapters.ArtikalTableAdapter daArtikli;

        Size size;
        Font font;
        public FrmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            size = new Size(150, 80);
            font = new Font("Arial", 14);
            listaArtikla = new List<BAZADataSet.ArtikalRow>();

            ds = new BAZADataSet();
            daGrupe = new BAZADataSetTableAdapters.GrupaTableAdapter();
            daArtikli = new BAZADataSetTableAdapters.ArtikalTableAdapter();

            daGrupe.Fill(ds.Grupa);
            daArtikli.Fill(ds.Artikal);
        }
        public FrmMain(FrmContainer frmContainer, FrmRacun frmRacun) : this()
        {
            this.frmContainer = frmContainer;
            this.frmRacun = frmRacun;
        }
        
        private void GlavneGrupe()
        {
            Button b = null;

            //Grupe koje nemaju nadgrupu
            var linq = ds.Grupa.Where(x => x.id_roditelj == 0).OrderBy(x => x.id_grupa);
            this.flowLayoutPanel1.Controls.Clear();
            NapraviGrupe(b, linq);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GlavneGrupe();
            new Task(PostaviVreme).Start();
        }

        public void DugmiciGrupe(object sender, EventArgs e)
        {
            listaArtikla = new List<BAZADataSet.ArtikalRow>();
            Button prethodnoDugme = sender as Button; 
            Button b = null;
            var linq = ds.Grupa.Where(x => x.id_roditelj == int.Parse(prethodnoDugme.Tag.ToString())).OrderBy(x => x.id_grupa);
            this.flowLayoutPanel1.Controls.Clear();

            if (!linq.Any()) // ARTIKLI čija je grupa kliknutog dugmeta
            {
                var linq2 = ds.Artikal.Where(x => x.id_grupa == int.Parse(prethodnoDugme.Tag.ToString())).OrderBy(x => x.naziv);
                listaArtikla = linq2.ToList();
                foreach (BAZADataSet.ArtikalRow x in linq2)
                {
                    b = new Button
                    {
                        Size = size,
                        Font = font,
                        Text = x.naziv,
                        Tag = x.id_artikal
                    };
                    b.Click += PozoviKolicinu;
                    this.flowLayoutPanel1.Controls.Add(b);
                }
                return;
            }
            NapraviGrupe(b, linq); // Ako ne postoje artikli, napravi grupe
        }

        private void PozoviKolicinu(object sender, EventArgs e)
        {
            Button b = sender as Button;
            FrmKolicina frmKolicina = new FrmKolicina(ds, frmRacun, int.Parse(b.Tag.ToString()));
            frmKolicina.StartPosition = FormStartPosition.CenterParent;
            frmKolicina.ShowDialog();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count != 0)
            {
                Button b = flowLayoutPanel1.Controls[0] as Button;
                int id = int.Parse(b.Tag.ToString());

                //Nazad iz artikla
                if (listaArtikla != null && listaArtikla.Count != 0)
                {
                    listaArtikla = new List<BAZADataSet.ArtikalRow>();
                    flowLayoutPanel1.Controls.Clear();
                    //Uzimam id_grupe artikla
                    var artLinq = ds.Artikal.Where(x => x.id_artikal == id).Select(x => x.id_grupa).First();
                    //Uzimam id_roditelja grupe ^
                    var grupaLinq = ds.Grupa.Where(x => x.id_grupa == artLinq).Select(x => x.id_roditelj).First();
                    //Uzimam roditelja grupe
                    var grupe = ds.Grupa.Where(x => x.id_roditelj == grupaLinq);

                    NapraviGrupe(b, grupe);
                    return;
                }

                //Nazad iz grupa
                listaArtikla = new List<BAZADataSet.ArtikalRow>();
                var linq = ds.Grupa.Where(x => x.id_grupa == id).First();
                if (linq.id_roditelj != 0)
                {
                    flowLayoutPanel1.Controls.Clear();

                    var linq2 = ds.Grupa.Where(x => x.id_grupa == linq.id_roditelj).Select(x => x.id_roditelj).First();
                    var linq3 = ds.Grupa.Where(x => x.id_roditelj == linq2);
                    NapraviGrupe(b, linq3);
                }
            }
        }

        private void NapraviGrupe(Button b, EnumerableRowCollection<BAZADataSet.GrupaRow> grupe)
        {
            foreach (BAZADataSet.GrupaRow x in grupe)
            {
                b = new Button
                {
                    Size = size,
                    Font = font,
                    Text = x.naziv,
                    Tag = x.id_grupa
                };
                b.Click += DugmiciGrupe;
                this.flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void btnPocetak_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count != 0)
            {
                Button b = flowLayoutPanel1.Controls[0] as Button;
                int id = int.Parse(b.Tag.ToString());
                int linq = -1;
                if (listaArtikla == null || listaArtikla.Count == 0)
                    linq = ds.Grupa.Where(x => x.id_grupa == id).Select(x => x.id_roditelj).FirstOrDefault();

                if (linq == 0) // Ako je glavna grupa, ne osvežavaj
                    return;
            }
            GlavneGrupe();
            listaArtikla = new List<BAZADataSet.ArtikalRow>();
        }

        private void btnNoviArtikal_Click(object sender, EventArgs e)
        {
            FrmNoviArtikal frmNoviArtikal = new FrmNoviArtikal(ds, daArtikli);
            frmNoviArtikal.StartPosition = FormStartPosition.CenterParent;
            frmNoviArtikal.ShowDialog();

        }

        private void btnPregledRacuna_Click(object sender, EventArgs e)
        {
            FrmPregledRacuna frmPregledRacuna = new FrmPregledRacuna(ds);
            frmPregledRacuna.StartPosition = FormStartPosition.CenterParent;
            frmPregledRacuna.ShowDialog();
        }

        private void vreme()
        {
            lblDatum.Text = DateTime.Now.ToString("dd.MM.yyyy.");
            lblVreme.Text = DateTime.Now.ToString("HH:mm");
            Invalidate();
        }

        private void PostaviVreme()
        {
            while (!IsDisposed)
            {
                Invoke(new promeniLabelu(vreme));
                Thread.Sleep(1000);
            }
        }
    }
}
