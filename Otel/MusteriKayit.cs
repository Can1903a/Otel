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

namespace Otel
{
    public partial class MusteriKayit : Form
    {
        private SqlConnection connection;

        public MusteriKayit(SqlConnection baglanti)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void MusteriKayit_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya yazılabilir
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
            this.Close();
        }


        private void Temizle()
        {
            // TextBox kontrolündeki metinleri temizle
            txtAd.Clear();
            txtSoyad.Clear();
            txtTC.Clear();
            txtEmail.Clear();
            txtSifre.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTC.Text = "";
                return;
            }
            try
            {
                connection.Open();

                // Müşteri bilgilerini veritabanına ekleme sorgusu
                string sorgu = "INSERT INTO Musteriler (Ad, Soyad, MusteriTC, Email, Sifre, Telefon, Adres) VALUES (@Ad, @Soyad, @MusteriTC, @Email, @Sifre, @Telefon, @Adres)";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@Ad", txtAd.Text);
                komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@MusteriTC", txtTC.Text);
                komut.Parameters.AddWithValue("@Email", txtEmail.Text);
                komut.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@Adres", txtAdres.Text);

                int etkilenenSatirSayisi = komut.ExecuteNonQuery();
                if (etkilenenSatirSayisi > 0)
                {
                    MessageBox.Show("Müşteri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Kayıt işlemi başarılıysa, formu temizle
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Müşteri kaydedilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Bağlantıyı kapat
            }
        }

        private void MusteriKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
