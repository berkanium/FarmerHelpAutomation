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
    public partial class frmKonumAdres : Form
    {
        public frmKonumAdres()
        {
            InitializeComponent();
        }
        SqlCeConnection baglanti = new SqlCeConnection("Data Source=|DataDirectory|\\Islemler.sdf"); 
        private void frmKonumAdres_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCeCommand Benzin = new SqlCeCommand("select UrunAd,UrunTur,DepoKonum from UrunlerGiris", baglanti);
                SqlCeDataReader Benzinokut = Benzin.ExecuteReader();
                while (Benzinokut.Read()==true)
                {
                    if (Benzinokut[2].ToString() == "BENZİN ÜRÜNLERİ")
                    {
                    
                        lstBenzin.Items.Add("Cinsi :" + Benzinokut[0].ToString() + " - " + "Adeti :" + Benzinokut[1].ToString());
                        lstBenzin.Items.Add("------------------");
                    }
                   

                }
                SqlCeCommand Hayvanlar = new SqlCeCommand("select Cinsi,Adet,YasamAlani from Buyukbas", baglanti);
                SqlCeDataReader okut = Hayvanlar.ExecuteReader();
                while (okut.Read()==true)
                {
                    if (okut[2].ToString()=="HAYVANLAR")
                    {
                  
                    lstHayvanlar.Items.Add("Cinsi :" + okut[0].ToString() + " - " + "Adeti :" + okut[1].ToString());
                    lstHayvanlar.Items.Add("------------------");
                    }
                    

                }
                SqlCeCommand Kucukbas = new SqlCeCommand("select Cinsi,Adet,YasamAlani from Kucukbas", baglanti);
                SqlCeDataReader oku = Hayvanlar.ExecuteReader();
                while (oku.Read()==true)
                {
                    if (oku[2].ToString()=="HAYVANLAR")
                    {
                    
                        lstHayvanlar.Items.Add("Cinsi :" + oku[0].ToString() + " - " + "Adeti :" + oku[1].ToString());
                        lstHayvanlar.Items.Add("------------------");
                    }
                   
                }
                SqlCeCommand Ulasım = new SqlCeCommand("select Arac,Romork,DepoBenzin from Ulasım",baglanti);
                SqlCeDataReader ulas = Ulasım.ExecuteReader();
                while (ulas.Read()==true)
                {
                    if (ulas[2].ToString()=="ULAŞIM")
                    {
                    
                        lstUlasım.Items.Add("Araç :" + ulas[0].ToString() + " - " + "Römörk :" + ulas[1].ToString());
                        lstUlasım.Items.Add("------------------");
                    }
                  
                }
                SqlCeCommand sut = new SqlCeCommand("select UrunAd,Miktar,DepoKonum from UrunlerGiris ",baglanti);
                SqlCeDataReader urunGir = sut.ExecuteReader();
                while (urunGir.Read()==true)
                {
                    if (urunGir[2].ToString() == "SÜT ÜRÜNLERİ")
                    {
                    
                        lstSutUrunleri.Items.Add("Ürün Ad :" + urunGir[0].ToString() + " - " + "Miktar :" + urunGir[1].ToString());
                        lstSutUrunleri.Items.Add("------------------");   
                    }
                   
                }
                SqlCeCommand Harman = new SqlCeCommand("select UrunAd,Miktar,DepoKonum from UrunlerGiris ", baglanti);
                SqlCeDataReader urunGirHarman = Harman.ExecuteReader();
                while (urunGirHarman.Read()==true)
                {
                    if (urunGirHarman[2].ToString() == "HARMAN" )
                    {
                   
                    lstHarman.Items.Add("Ürün Ad :" + urunGirHarman[0].ToString() + " - " + "Miktar :" + urunGirHarman[1].ToString());
                    lstHarman.Items.Add("------------------");
                    }
                 
                }
                SqlCeCommand Tarısmsal = new SqlCeCommand("select UrunAd,Miktar,DepoKonum from UrunlerGiris ", baglanti);
                SqlCeDataReader urunGirTarımsal = Tarısmsal.ExecuteReader();
                while (urunGirTarımsal.Read()==true)
                {
                    if (urunGirTarımsal[2].ToString()=="TARIMSAL ÜRÜNLER")
                    {
                
                        lstAraziMahsulleri.Items.Add("Ürün Ad :" + urunGirTarımsal[0].ToString() + " - " + "Miktar :" + urunGirTarımsal[1].ToString());
                        lstAraziMahsulleri.Items.Add("------------------");  
                    }
                
                }
                SqlCeCommand Et = new SqlCeCommand("select UrunAd,Miktar,DepoKonum from UrunlerGiris ", baglanti);
                SqlCeDataReader urunGirEt = Et.ExecuteReader();
                while (urunGirEt.Read()==true)
                {
                    if (urunGirEt[2].ToString() == "ET-KASAP")
                    {
             
                        lstEtKasap.Items.Add("Ürün Ad :" + urunGirEt[0].ToString() + " - " + "Miktar :" + urunGirEt[1].ToString());
                        lstEtKasap.Items.Add("------------------");
                    }
                   
                }
                SqlCeCommand Diger = new SqlCeCommand("select UrunAd,Miktar,DepoKonum from UrunlerGiris ", baglanti);
                SqlCeDataReader urunGirDiger = Diger.ExecuteReader();
                while (urunGirDiger.Read()==true)
                {
                    if (urunGirDiger[2].ToString() != "ET-KASAP" && urunGirDiger[2].ToString() != "TARIMSAL ÜRÜNLER" && urunGirDiger[2].ToString() != "ULAŞIM" && urunGirDiger[2].ToString() != "HARMAN" && urunGirDiger[2].ToString() != "SÜT ÜRÜNLERİ" && urunGirDiger[2].ToString() != "HAYVANLAR" && urunGirDiger[2].ToString() != "BENZİN ÜRÜNLERİ")
                    {
                   
                        lstDiger.Items.Add("Ürün Ad :" + urunGirDiger[0].ToString() + " - " + "Miktar :" + urunGirDiger[1].ToString());
                        lstDiger.Items.Add("------------------");
                    }
                   
                }
                baglanti.Close();
            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message.ToString(),"UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            } 
        }

        private void pctMain_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.ShowDialog();
        }
    }
}
