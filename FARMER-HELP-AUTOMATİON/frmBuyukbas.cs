using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace FARMER_HELP_AUTOMATİON
{
    public partial class frmBuyukbas : Form
    {
        public frmBuyukbas()
        {
            InitializeComponent();
        }
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");
        private void frmBuyukbas_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Buyukbas", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dataGridView1.Columns[5].Visible = false;
        }
        Random rastegele = new Random();
        private void btnGir_Click(object sender, EventArgs e)
        {
            try
            {
                string takip = rastegele.Next(500, 99999).ToString();
                int adet = Convert.ToInt32(txtAdet.Text);
                baglanti.Open();
                SqlCeCommand kayıt = new SqlCeCommand("INSERT INTO Buyukbas (Cinsi,Adet,BesinTuru,YasamAlani,BesinDegeri,EldeEdilenUrun,TakipID) values ('"+txtBuyukbasCins.Text+"','"+adet+"','"+txtTur.Text+"','"+cmbYasamAlani.SelectedItem+"','"+txtBesin.Text+"','"+txtEldeEdilen.Text+"','"+takip+"')",baglanti);
                kayıt.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmBuyukbas_Load(null,null);
                MessageBox.Show("Büyükbaş Hayvan Kaydı Kaydedildi", "FARMİNG", MessageBoxButtons.OK ,MessageBoxIcon.Information);
            }
            catch (Exception MESAJ)
            {
                MessageBox.Show(MESAJ.Message.ToString(),"FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void PctYetkili_Click(object sender, EventArgs e)
        {

            frmGiris yetkili = new frmGiris();
            this.Hide();
            yetkili.ShowDialog();
        }

        private void pctMain_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.ShowDialog();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCeCommand SİL = new SqlCeCommand("delete from Buyukbas where TakipID='" + txtTakipID.Text + "'", baglanti);
                SİL.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmBuyukbas_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
