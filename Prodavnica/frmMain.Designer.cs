namespace Prodavnica
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNazad = new System.Windows.Forms.Button();
            this.btnPocetak = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPregledRacuna = new System.Windows.Forms.Button();
            this.btnNoviArtikal = new System.Windows.Forms.Button();
            this.lblVreme = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(155, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(683, 519);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNazad
            // 
            this.btnNazad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
            this.btnNazad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNazad.Location = new System.Drawing.Point(12, 12);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(115, 49);
            this.btnNazad.TabIndex = 0;
            this.btnNazad.Text = "Nazad";
            this.btnNazad.UseVisualStyleBackColor = false;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // btnPocetak
            // 
            this.btnPocetak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPocetak.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPocetak.Location = new System.Drawing.Point(12, 67);
            this.btnPocetak.Name = "btnPocetak";
            this.btnPocetak.Size = new System.Drawing.Size(115, 49);
            this.btnPocetak.TabIndex = 2;
            this.btnPocetak.Text = "Početak";
            this.btnPocetak.UseVisualStyleBackColor = false;
            this.btnPocetak.Click += new System.EventHandler(this.btnPocetak_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(137, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 519);
            this.panel1.TabIndex = 3;
            // 
            // btnPregledRacuna
            // 
            this.btnPregledRacuna.BackColor = System.Drawing.Color.White;
            this.btnPregledRacuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPregledRacuna.Location = new System.Drawing.Point(12, 386);
            this.btnPregledRacuna.Name = "btnPregledRacuna";
            this.btnPregledRacuna.Size = new System.Drawing.Size(115, 70);
            this.btnPregledRacuna.TabIndex = 4;
            this.btnPregledRacuna.Text = "Pregled računa";
            this.btnPregledRacuna.UseVisualStyleBackColor = false;
            this.btnPregledRacuna.Click += new System.EventHandler(this.btnPregledRacuna_Click);
            // 
            // btnNoviArtikal
            // 
            this.btnNoviArtikal.BackColor = System.Drawing.Color.Azure;
            this.btnNoviArtikal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoviArtikal.Location = new System.Drawing.Point(12, 462);
            this.btnNoviArtikal.Name = "btnNoviArtikal";
            this.btnNoviArtikal.Size = new System.Drawing.Size(115, 70);
            this.btnNoviArtikal.TabIndex = 4;
            this.btnNoviArtikal.Text = "Novi artikal";
            this.btnNoviArtikal.UseVisualStyleBackColor = false;
            this.btnNoviArtikal.Click += new System.EventHandler(this.btnNoviArtikal_Click);
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVreme.Location = new System.Drawing.Point(37, 584);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(71, 25);
            this.lblVreme.TabIndex = 5;
            this.lblVreme.Text = "vreme";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(12, 559);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(71, 25);
            this.lblDatum.TabIndex = 5;
            this.lblDatum.Text = "datum";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 619);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.btnNoviArtikal);
            this.Controls.Add(this.btnPregledRacuna);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPocetak);
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNazad;
        private System.Windows.Forms.Button btnPocetak;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPregledRacuna;
        private System.Windows.Forms.Button btnNoviArtikal;
        private System.Windows.Forms.Label lblVreme;
        private System.Windows.Forms.Label lblDatum;
    }
}