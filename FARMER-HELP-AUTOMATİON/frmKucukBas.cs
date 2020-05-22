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
    public partial class frmKucukBas : Form
    {
        public frmKucukBas()
        {
            InitializeComponent();
        }
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf"); 
        private void frmKucukBas_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Kucukbas", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dataGridView1.Columns[6].Visible = false;
        }

        Random rastegele = new Random();
        private void btnGir_Click(object sender, EventArgs e)
        {
            try
            {
                string takip = rastegele.Next(500,99999).ToString();
                int adet = Convert.ToInt32(txtAdet.Text);
                baglanti.Open();
                SqlCeCommand kayıt = new SqlCeCommand("INSERT INTO Kucukbas (Cinsi,Adet,BesinTuru,YasamAlani,BesinDegeri,EldeEdilenUrun,TakipID) values ('" + txtBuyukbasCinsi.Text + "','" + adet + "','" + txtBesinDeger.Text + "','" + cmbYasamAlani.SelectedItem + "','" + txtBes.Text + "','" + txtEldeEdilen.Text + "','"+takip+"')", baglanti);
                kayıt.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmKucukBas_Load(null, null);
                MessageBox.Show("Küçükbaş Hayvan Kaydı Kaydedildi", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception MESAJ)
            {
                MessageBox.Show(MESAJ.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctMain_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.ShowDialog();
        }

        private void PctYetkili_Click(object sender, EventArgs e)
        {
            frmGiris yetkili = new frmGiris();
            this.Hide();
            yetkili.ShowDialog();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCeCommand SİL = new SqlCeCommand("delete from Kucukbas where TakipID='" + txtTakipID.Text + "'", baglanti);
                SİL.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmKucukBas_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
       
        }

      
    }
}
