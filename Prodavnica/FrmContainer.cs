using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class FrmContainer : Form
    {
        FrmRacun frmRacun;
        FrmMain frmMain;
        public FrmContainer()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            frmRacun = new FrmRacun();
            frmRacun.MdiParent = this;
            frmRacun.Dock = DockStyle.Right;
            frmRacun.Show();

            frmMain = new FrmMain(this, frmRacun);
            frmMain.MdiParent = this;
            frmMain.Dock = DockStyle.Fill;
            frmMain.Show();
        }
    }
}
