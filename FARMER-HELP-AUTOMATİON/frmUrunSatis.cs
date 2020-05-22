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
    public partial class frmUrunSatis : Form
    {
        public frmUrunSatis()
        {
            InitializeComponent();
        }
        Random rastgele = new Random();
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");
        private void frmUrunSatis_Load(object sender, EventArgs e)
        {
            txtAdi.Enabled = false;
            txtBirimFiyat.Enabled = false;
            txtFirma.Enabled = false;
            txtGider.Enabled = false;
            txtMiktar.Enabled = false;
            txtUrunTur.Enabled = false;
            btnSat.Enabled = false;
            timer1.Start();
            lblTarih.Text = DateTime.Now.ToLongDateString();
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM UrunlerSatis", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dataGridView1.Columns[5].Visible = false;
        }
     
        private void btnSat_Click(object sender, EventArgs e)
        {
            int TakipNum = rastgele.Next(500, 999999);
            int fiyat = Convert.ToInt32(txtBirimFiyat.Text);
            int gider = Convert.ToInt32(txtGider.Text);
            try
            {

                baglanti.Open();
                SqlCeCommand silKayit = new SqlCeCommand("DELETE from UrunlerGiris where TakipNo='" + txtAra.Text + "'", baglanti);
                silKayit.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
                frmUrunSatis_Load(null, null); 
                baglanti.Open();
                SqlCeCommand satisEkle = new SqlCeCommand("insert into UrunlerSatis(UrunAd,UrunTur,UrunMiktar,KgFiyat,YakitGideri,SatilanFirma,TakipNo)values('" + txtAdi.Text + "','" + txtUrunTur.Text + "','" + txtMiktar.Text + "','" + fiyat + "','" + gider + "','" + txtFirma.Text + "','" + TakipNum + "')", baglanti);
                satisEkle.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmUrunSatis_Load(null, null);
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi.", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message.ToString(),"FARMİNG",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txtAdi.Enabled = true ;
                txtBirimFiyat.Enabled = true;
                txtFirma.Enabled = true;
                txtGider.Enabled = true;
                txtMiktar.Enabled = true;
                txtUrunTur.Enabled = true;
                btnSat.Enabled = true ;
                baglanti.Open();
                SqlCeCommand Getir = new SqlCeCommand("SELECT UrunAd,Miktar,VerisFiyat,UrunTur,YakitGideri FROM UrunlerGiris WHERE TakipNo='" + txtAra.Text + "'", baglanti);
                SqlCeDataReader oku = Getir.ExecuteReader();
                while (oku.Read() == true)
                {
                    txtAdi.Text = oku[0].ToString();
                    txtMiktar.Text = oku[1].ToString();
                    txtBirimFiyat.Text = oku[2].ToString();
                    txtUrunTur.Text = oku[3].ToString();
                    txtGider.Text = oku[4].ToString();
                }
                baglanti.Close();


            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSistemSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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
                SqlCeCommand SİL = new SqlCeCommand("delete from UrunlerSatis where TakipNo='" + txtAra.Text + "'", baglanti);
                SİL.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmUrunSatis_Load(null, null);
                MessageBox.Show("Kayıt Başarıyla Silindi", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

 
    
    }
}
