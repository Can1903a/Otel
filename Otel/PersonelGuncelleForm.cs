using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otel
{
    public partial class PersonelGuncelleForm : Form
    {
        private SqlConnection connection;
        private int PersonelID;

        public PersonelGuncelleForm(SqlConnection baglanti, int personelID,string ad,string soyad,string tc,string pozisyon,string email,string sifre,string telefon)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            this.PersonelID = personelID;   
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtTC.Text = tc;
            txtPozisyon.Text = pozisyon;
            txtEmail.Text = email;
            txtSifre.Text = sifre;
            txtTelefon.Text = telefon;
        }

        private void PersonelGuncelleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                // Güncellenecek personelin bilgilerini al
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                string tc = txtTC.Text;
                string pozisyon = txtPozisyon.Text; 
                string email = txtEmail.Text;
                string sifre = txtSifre.Text;
                string telefon = txtTelefon.Text;

                // Veritabanında ilgili personelin bilgilerini güncelleme
                connection.Open();
                string sorgu = "UPDATE Personel SET Ad = @Ad, Soyad = @Soyad, PersonelTC = @TC,Pozisyon =@Pozisyon, Email = @Email,Sifre = @Sifre, Telefon = @Telefon WHERE PersonelID = @PersonelID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@Ad", ad);
                komut.Parameters.AddWithValue("@Soyad", soyad);
                komut.Parameters.AddWithValue("@TC", tc);
                komut.Parameters.AddWithValue("@Pozisyon", pozisyon); 
                komut.Parameters.AddWithValue("@Email", email);
                komut.Parameters.AddWithValue("@Sifre", sifre);
                komut.Parameters.AddWithValue("@Telefon", telefon);
                komut.Parameters.AddWithValue("@PersonelID", PersonelID);
                komut.ExecuteNonQuery();

                MessageBox.Show("Personel bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            YoneticiForm yonetici = new YoneticiForm(connection);
            yonetici.Show();
            this.Close();
        }

        private void PersonelGuncelleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
    }

