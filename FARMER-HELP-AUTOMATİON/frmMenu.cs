using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FARMER_HELP_AUTOMATİON
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
        MEDİAPLAYER.Ctlenabled = false;
        MEDİAPLAYER.URL = Application.StartupPath + "\\CIFTCİ.mp4";
        }
        private void pctOynat_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.URL = Application.StartupPath + "\\CIFTCİ.mp4";
        }

        private void pctDurdur_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.pause();
        }
        private void pctUrunGiris_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmUrunGiris uGiris = new frmUrunGiris();
            this.Hide();
            uGiris.ShowDialog();
        }

        private void pctUlasim_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmUlasim uGiris = new frmUlasim();
            this.Hide();
            uGiris.ShowDialog();
        }

        private void pctYetkiliAlan_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmGiris uGiris = new frmGiris();
            this.Hide();
            uGiris.ShowDialog();
        }

        private void pctSatis_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmUrunSatis uGiris = new frmUrunSatis();
            this.Hide();
            uGiris.ShowDialog();

        }

        private void ğctKucukbas_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmKucukBas uGiris = new frmKucukBas();
            this.Hide();
            uGiris.ShowDialog();
        }

        private void pctBuyukbas_Click(object sender, EventArgs e)
        {
            MEDİAPLAYER.Ctlcontrols.stop();
            frmBuyukbas uGiris = new frmBuyukbas();
            this.Hide();
            uGiris.ShowDialog();
        }
 
        
    }
}
