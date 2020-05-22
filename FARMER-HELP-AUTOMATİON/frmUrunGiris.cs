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
    public partial class frmUrunGiris : Form
    {
        public frmUrunGiris()
        {
            InitializeComponent();
        }
        Random rastgele = new Random();
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");
        private void frmUrunGiris_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM UrunlerGiris", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dataGridView1.Columns[8].Visible = false;
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                int alis = Convert.ToInt32(txtAlıs.Text);
                int satis = Convert.ToInt32(txtSatis.Text);
                int gider = Convert.ToInt32(txtYakitGider.Text);
                int sayi = rastgele.Next(500,99999);
                if (gider<alis)
                {
                    if (gider<satis)
                    {
                        if (alis<satis)
                        {
                            baglanti.Open();
                            SqlCeCommand Kayit = new SqlCeCommand("INSERT INTO UrunlerGiris (UrunAd,Miktar,AlisFiyat,VerisFiyat,UrunTur,StokSekli,DepoKonum,YakitGideri,TakipNo) values ('" + txtUrunAd.Text + "','" + txtMiktar.Text + "','" + alis + "','" + satis + "','" + txtUrunTur.Text + "','" + txtStok.Text+ "','" + cmbKonum.SelectedItem + "','" + gider + "','"+sayi+"') ", baglanti);
                            Kayit.ExecuteNonQuery();
                            baglanti.Close();
                            dataGridView1.Refresh();
                            frmUrunGiris_Load(null,null);
                            MessageBox.Show("Kayıt Eklendi", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                        }
                        else
                        {
                            MessageBox.Show("Alış Fiyatı Satış Ücretinden Az Olmalıdır.\nAksi Takdirde Zarar Etme Sebebidir!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yakıt Gideri Satış Ücretinden Az Olmalıdır.\nAksi Takdirde Zarar Edersiniz!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Yakıt Gideri Alış Ücretinden Az Olmalı.\nAksi Halde Zarar Başlangıcıdır!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
               
            }
            catch (Exception mesaj)
            {
            MessageBox.Show(mesaj.Message.ToString(),"FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void pctAra_Click(object sender, EventArgs e)
        {
            try
            {
               
                            baglanti.Open();
                            SqlCeCommand Getir = new SqlCeCommand("SELECT UrunAd,Miktar,AlisFiyat,VerisFiyat,UrunTur,StokSekli,DepoKonum,YakitGideri FROM UrunlerGiris WHERE TakipNo='"+txtAra.Text+"'", baglanti);
                            SqlCeDataReader oku = Getir.ExecuteReader();
                            while (oku.Read()==true)
                            {
                                txtUrunAd.Text=oku[0].ToString();
                                txtMiktar.Text = oku[1].ToString();
                                txtAlıs.Text = oku[2].ToString();
                                txtSatis.Text = oku[3].ToString();
                                txtUrunTur.Text = oku[4].ToString();
                                txtStok.Text = oku[5].ToString();
                                cmbKonum.SelectedItem = oku[6].ToString();
                                txtYakitGider.Text = oku[7].ToString();
                            }
                            baglanti.Close();
                       

            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            try
            {
                int alis = Convert.ToInt32(txtAlıs.Text);
                int satis = Convert.ToInt32(txtSatis.Text);
                int gider = Convert.ToInt32(txtYakitGider.Text);
                if (gider < alis)
                {
                    if (gider < satis)
                    {
                        if (alis < satis)
                        {
                            baglanti.Open();
                            SqlCeCommand Guncelle = new SqlCeCommand("UPDATE UrunlerGiris SET UrunAd='"+txtUrunAd.Text+"',Miktar='"+txtMiktar.Text+"',AlisFiyat='"+alis+"',VerisFiyat='"+satis+"',UrunTur='"+txtUrunTur.Text+"',StokSekl='"+txtStok.Text+"',DepoKonum='"+cmbKonum.SelectedItem+"',YakitGideri='"+gider+"' WHERE TakipNo='"+txtAra.Text+"' ", baglanti);
                            Guncelle.ExecuteNonQuery();
                            baglanti.Close();
                            dataGridView1.Refresh();
                            frmUrunGiris_Load(null,null);
                            MessageBox.Show("Ürünlerin Kaydı Başarı İle Güncellendi.", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Alış Fiyatı Satış Ücretinden Az Olmalıdır.\nAksi Takdirde Zarar Etme Sebebidir!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yakıt Gideri Satış Ücretinden Az Olmalıdır.\nAksi Takdirde Zarar Edersiniz!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Yakıt Gideri Alış Ücretinden Az Olmalı.\nAksi Halde Zarar Başlangıcıdır!!", "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            baglanti.Open();
            SqlCeCommand sil = new SqlCeCommand("delete from UrunlerGiris where TakipNo='"+txtAra.Text+"'",baglanti);
            sil.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.Refresh();
            frmUrunGiris_Load(null,null);
            MessageBox.Show("Ürün Kaydı Silindi.","FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        
    }
}
