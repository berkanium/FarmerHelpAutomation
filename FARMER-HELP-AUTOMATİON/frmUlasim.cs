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
    public partial class frmUlasim : Form
    {
        public frmUlasim()
        {
            InitializeComponent();
        }
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");
        private void frmUlasim_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCeDataAdapter ad = new SqlCeDataAdapter("SELECT * FROM Ulasım", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false;
        }
        Random rastegele = new Random();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string takip = rastegele.Next(500,99999).ToString();
            try
            {
                int
                benzin = Convert.ToInt32(txtBezinFiyat.Text);
                int Arac = Convert.ToInt32(txtAracFiyat.Text);
                int lastik = Convert.ToInt32(txtLastikFiyat.Text);
                baglanti.Open();
                SqlCeCommand Kayit = new SqlCeCommand("insert into Ulasım (Arac,Romork,Lastikler,Ebatlar,lastikFiyat,AracFiyat,DepoBenzin,BenzinFiyati,lastikAdet,TakipID) values ('" +txtArac.Text + "','" + txtRomork.Text + "','" + cmbLastik.SelectedItem + "','" +txtEbat.Text +"','" + lastik + "','" + Arac + "','" + cmbBenzinKonum.SelectedItem + "','" + benzin + "','"+txtLastikAdet.Text+"','"+takip+"')", baglanti);
                Kayit.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.Refresh();
                frmUlasim_Load(null, null);
                MessageBox.Show("Ulaşım Kayıt Bilgileri Kaydedildi.","FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception MESAJ)
            {
                MessageBox.Show(MESAJ.Message.ToString(), "FARMİNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            SqlCeCommand sil = new SqlCeCommand("delete from Ulasım where TakipID='"+txtTakipID.Text+"'",baglanti);
            sil.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.Refresh();
            frmUlasim_Load(null,null);
            MessageBox.Show("Kayıtlar Başarılı Bir Şekilde Silindi","FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

 
   

       
    }
}
