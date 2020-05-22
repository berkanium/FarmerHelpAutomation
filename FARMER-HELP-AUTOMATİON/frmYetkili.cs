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
    public partial class frmYetkili : Form
    {
        public frmYetkili()
        {
            InitializeComponent();
          
        }
  
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");

        private void frmYetkili_Load(object sender, EventArgs e)
        {
           
       
        }
       

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCeCommand Yetkili = new SqlCeCommand("INSERT INTO Yetkili (Kullanici,Sifre) values ('"+txtKullanici.Text+"','"+txtSifre.Text+"')",baglanti);
                Yetkili.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmYetkili_Load(null, null);
                MessageBox.Show("Yetkili Kişi Eklendi","FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Information);
             
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

  
        private void pctYetkili_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Yetkili", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[2].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctSatis_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM UrunlerSatis", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[5].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctGiris_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM UrunlerGiris", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[8].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctUlasim_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Ulasım", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctBuyukbas_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Buyukbas", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[5].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctKucukbas_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Kucukbas", baglanti);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                dataGridView1.Columns[6].Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pctKonum_Click(object sender, EventArgs e)
        {
            frmKonumAdres konum = new frmKonumAdres();
            this.Hide();
            konum.ShowDialog();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCeCommand komut = new SqlCeCommand("Delete from Yetkili where Kullanici='"+txtKullanici.Text+"'",baglanti);
            komut.ExecuteNonQuery();
    
            baglanti.Close();
            dataGridView1.Refresh();
            frmYetkili_Load(null, null);
            MessageBox.Show("Yetkili Kaydı Silindi","FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Information);
           
        }

    
    }
}
