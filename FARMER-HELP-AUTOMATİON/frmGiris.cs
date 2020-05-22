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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        public static string KullaniciKontrol;
        string sifreKontrol;
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf");
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                string ad = txtK.Text;
                string sifre = txtSifre.Text;
                baglanti.Open();
                SqlCeCommand Kullanici = new SqlCeCommand("SELECT * FROM Yetkili where Kullanici='"+txtK.Text+"'",baglanti);
                SqlCeDataReader Onay = Kullanici.ExecuteReader();
                while (Onay.Read()==true)
                {
                    KullaniciKontrol=Onay["Kullanici"].ToString();
                    sifreKontrol = Onay["Sifre"].ToString();
                }
                baglanti.Close();
                if (KullaniciKontrol == ad && sifre == sifreKontrol)
                {
                    frmYetkili GİRİS = new frmYetkili();
                    this.Hide();
                    GİRİS.ShowDialog();
                }
                else
                {
                    lblYonetici.Text = "Yetkiliyi Kontrol Edin !!";
                }
                    
            }
            catch (Exception sd)
            {
                MessageBox.Show(sd.Message.ToString(),"FARMİNG",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
