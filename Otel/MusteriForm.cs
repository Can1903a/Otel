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
    public partial class MusteriForm : Form
    {
        private SqlConnection connection;
        private int musteriID;
        private int odaID;

        public MusteriForm( int musteriID)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            this.musteriID = musteriID;

            // Hoşgeldin mesajını yükle
            string hoşgeldinMesaji = GetHoşgeldinMesaji(musteriID);
            labelHoşgeldiniz.Text = hoşgeldinMesaji;
            RezervasyonGecmisiGoster();
        }

        private void GosterMusteriBilgileri(int musteriID)
        {
            try
            {
                connection.Open();
                string query = "SELECT Ad, Soyad, MusteriTC FROM Musteriler WHERE MusteriID = @MusteriID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MusteriID", musteriID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string ad = reader["Ad"].ToString();
                    string soyad = reader["Soyad"].ToString();
                    string tc = reader["MusteriTC"].ToString();

                    // Müşteri bilgilerini formda göster
                    lblAd.Text = $"Ad: {ad}";
                    lblSoyad.Text = $"Soyad: {soyad}";
                    lblTC.Text = $"TC Kimlik Numarası: {tc}";

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool RezervasyonKontrolü(int musteriID)
        {
            bool rezervasyonVarMi = false;
            try
            {
                connection.Open();
                string komut = "SELECT COUNT(*) FROM Rezervasyonlar WHERE MusteriID = @MusteriID";
                SqlCommand command = new SqlCommand(komut, connection);
                command.Parameters.AddWithValue("@MusteriID", musteriID);

                int rezervasyon = (int)command.ExecuteScalar();
                rezervasyonVarMi = rezervasyon > 0;
            }

            finally
            {
                connection.Close();
            }

            return rezervasyonVarMi;
        }


        private void RezervasyonGecmisiGoster()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Rezervasyonlar WHERE MusteriID = @MusteriID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MusteriID", musteriID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable rezervasyonlar = new DataTable();
                adapter.Fill(rezervasyonlar);

                dgvRezervasyonlar.DataSource = rezervasyonlar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon geçmişi getirilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private string GetHoşgeldinMesaji(int musteriID)
        {
            string hoşgeldinMesaji = "";

            // Veritabanından müşteri adını ve soyadını al
            string query = "SELECT Ad, Soyad FROM Musteriler WHERE MusteriID = @MusteriID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MusteriID", musteriID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string ad = reader["Ad"].ToString();
                    string soyad = reader["Soyad"].ToString();
                    hoşgeldinMesaji = $"Hoşgeldiniz, {ad} {soyad}..";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return hoşgeldinMesaji;
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            GosterMusteriBilgileri(musteriID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rezervasyon rfrom = new Rezervasyon(connection,musteriID);
            rfrom.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MusteriGiris mg = new MusteriGiris(connection);
            mg.Show();
            this.Close();
        }
        private bool KullaniciDogrula(string sifre)
        {
            bool dogrulandi = false;
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Musteriler WHERE MusteriID = @MusteriID AND Sifre = @Sifre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MusteriID", musteriID);
                command.Parameters.AddWithValue("@Sifre", sifre);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    dogrulandi = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı doğrulanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return dogrulandi;
        }
        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            string eskiSifre = txtEskiSifre.Text;
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            // Eski şifrenin doğru olup olmadığını kontrol et
            if (!KullaniciDogrula(eskiSifre))
            {
                MessageBox.Show("Mevcut şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yeni şifrelerin aynı olup olmadığını kontrol et
            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Yeni şifreler birbiriyle eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                // Yeni şifreyi güncelle
                string query = "UPDATE Musteriler SET Sifre = @YeniSifre WHERE MusteriID = @MusteriID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                command.Parameters.AddWithValue("@MusteriID", musteriID);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Şifre başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Şifre güncellendikten sonra alanları temizle
                    txtEskiSifre.Text = "";
                    txtYeniSifre.Text = "";
                    txtYeniSifreTekrar.Text = "";
                }
                else
                {
                    MessageBox.Show("Şifre güncellenirken bir hata oluştu veya etkilenen satır yok!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifre güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private int OdaIDGetir(int musteriID)
        {
            int odaID = -1;
            try
            {
                connection.Open();
                string query = "SELECT OdaID FROM Rezervasyonlar WHERE MusteriID = @MusteriID AND Durum = 'Aktif'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MusteriID", musteriID);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    odaID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda kontrolü sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return odaID;
        }


        private void GelirTablosunaEkle(string aciklama, decimal tutar)
        {

            int odaID = OdaIDGetir(musteriID);
            if (odaID == -1)
            {
                MessageBox.Show("Geçersiz OdaID veya rezervasyon bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
                {
                    connection.Open();
                    string query = "INSERT INTO Gelir (MusteriID, Tutar, Tarih, Aciklama, OdaID) VALUES (@MusteriID, @Tutar, @Tarih, @Aciklama, @OdaID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", musteriID);
                    command.Parameters.AddWithValue("@Tutar", tutar);
                    command.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    command.Parameters.AddWithValue("@Aciklama", aciklama);
                    command.Parameters.AddWithValue("@OdaID", odaID);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gelir tablosuna kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
               

            
           
        }
            private void lblAd_Click(object sender, EventArgs e)
        {

        }

        private void btnEkstraTemizlik_Click(object sender, EventArgs e)
        {

            if (RezervasyonKontrolü(musteriID))
            {
                // Gelir tablosuna ekstra temizlik için ücreti kaydetme (opsiyonel)
                decimal ekstraTemizlikUcreti = 300.00m; // Örnek bir ücret
                GelirTablosunaEkle("Ekstra Temizlik", ekstraTemizlikUcreti);
                // Ekstra temizlik işlemi gerçekleştirme kodu buraya gelecek
                MessageBox.Show("Ekstra temizlik hizmeti sağlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Lütfen ilk önce herhangi bir oda için REZERVASYON yapınız..");

            }




        }

        private void btnOdayaYemek_Click(object sender, EventArgs e)
        {

        }

        private void btnOdayaYemek_Click_1(object sender, EventArgs e)
        {
            if (RezervasyonKontrolü(musteriID))
            {
                // Gelir tablosuna odaya yemek servisi için ücreti kaydetme (opsiyonel)
                decimal yemekServisiUcreti = 500.00m; // Örnek bir ücret
                GelirTablosunaEkle("Odaya Yemek Servisi", yemekServisiUcreti);
                // Odaya yemek servisi işlemi gerçekleştirme kodu buraya gelecek
                MessageBox.Show("Odaya yemek servisi sağlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen ilk önce herhangi bir oda için REZERVASYON yapınız..");

            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
