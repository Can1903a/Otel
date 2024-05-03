using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Otel
{
    public partial class Rezervasyon : Form
    {
        private SqlConnection connection;
        private object baglanti;
        private object odaID;
        private object musteriID;
        private int secilenOdaID;
        public Rezervasyon(SqlConnection baglanti, int odaID,int musteriID)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            this.odaID = odaID;
            this.musteriID =musteriID; 
        }

        public Rezervasyon()
        {
          
        }

        public Rezervasyon(SqlConnection connection)
        {
            this.connection = connection;
        }


        private void Rezervasyon_Load(object sender, EventArgs e)
        {
            OdalariYukle();
        }

        private void OdalariYukle()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT OdaID, Durum FROM Odalar";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataReader reader = komut.ExecuteReader();

                int pictureBoxIndex = 1;
                int x = 20; // PictureBox'ın başlangıç x koordinatı
                int y = 20; // PictureBox'ın başlangıç y koordinatı
                int pictureBoxPerRow = 4; // Her sırada kaç PictureBox olacağı
                int pictureBoxWidth = 100; // PictureBox genişliği
                int pictureBoxHeight = 100; // PictureBox yüksekliği

                while (reader.Read())
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "pictureBox" + pictureBoxIndex.ToString();
                    pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = reader["Durum"].ToString() == "Boş" ? Properties.Resources.yesil_yatak3 : Properties.Resources.kirmizi_yatak3;
                    pictureBox.Tag = reader["OdaID"]; // PictureBox'ın Tag özelliğine OdaID'yi ekleyerek odanın ID'sini sakla

                    // Picturebox'a tıklama olayı ekleme
                    pictureBox.Click += new EventHandler(pictureBox_Click);

                    // Picturebox'ı forma ekleme
                    this.Controls.Add(pictureBox);

                    // Picturebox'ın pozisyonunu belirleme
                    pictureBox.Location = new Point(x, y);

                    pictureBoxIndex++;

                    // PictureBox'ın yatay konumunu güncelleme
                    x += pictureBoxWidth + 10; // 10 piksel boşluk bırakarak PictureBox'ları yan yana yerleştir

                    // Her satırda belirtilen sayıda PictureBox varsa, bir sonraki satıra geç
                    if (pictureBoxIndex % pictureBoxPerRow == 0)
                    {
                        x = 20; // X koordinatını başa al
                        y += pictureBoxHeight + 10; // Y koordinatını bir sonraki satıra taşı
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalari yuklerken bir hata olustu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void OdaninOzellikleriniYukle(int odaID)
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Odalar WHERE OdaID = @OdaID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@OdaID", odaID);
                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    // Oda özelliklerini form kontrollerine yerleştirme
                    lblOdaID.Text = "Oda ID: " + reader["OdaID"].ToString();
                    lblOdaTuru.Text = "Oda Türü: " + reader["OdaTürü"].ToString();
                    lblUcret.Text = "Ücret: " + reader["Ücret"].ToString();
                    lblDurum.Text = "Durum: " + reader["Durum"].ToString();
                    lblKat.Text = "Kat: " + reader["Kat"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda özellikleri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            secilenOdaID = (int)pictureBox.Tag;
            int odaID = (int)pictureBox.Tag; // Seçilen odanın ID'sini al

            OdaninOzellikleriniYukle(odaID);

        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            if (secilenOdaID == 0)
            {
                MessageBox.Show("Lütfen bir oda seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Rezervasyon için gerekli verileri al
                DateTime girisTarihi = dateTimePickerGirisTarihi.Value;
                DateTime cikisTarihi = dateTimePickerCikisTarihi.Value;

                decimal toplamUcret = HesaplaToplamUcret(girisTarihi, cikisTarihi);

                // Rezervasyon kaydını veritabanına ekleme
                connection.Open();
                string insertQuery = "INSERT INTO Rezervasyonlar (MusteriID,OdaID, GirişTarihi, ÇıkışTarihi, ToplamÜcret, Durum) VALUES (@MusteriID,@OdaID, @GirisTarihi, @CikisTarihi, @ToplamUcret, @Durum)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@MusteriID", musteriID);
                insertCommand.Parameters.AddWithValue("@OdaID", secilenOdaID);
                insertCommand.Parameters.AddWithValue("@GirisTarihi", girisTarihi);
                insertCommand.Parameters.AddWithValue("@CikisTarihi", cikisTarihi);
                insertCommand.Parameters.AddWithValue("@ToplamUcret", toplamUcret);
                insertCommand.Parameters.AddWithValue("@Durum", "Aktif"); // Varsayılan olarak rezervasyonun durumu "Aktif" olarak ayarlanabilir
                int affectedRows = insertCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Rezervasyon başarıyla yapıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Rezervasyon sırasında bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private decimal HesaplaToplamUcret(DateTime girisTarihi, DateTime cikisTarihi)
        {
            decimal toplamUcret = 0;

            try
            {
                // Giriş ve çıkış tarihleri arasındaki gün sayısını hesapla
                int gunSayisi = (int)(cikisTarihi - girisTarihi).TotalDays;

                // Veritabanından oda ücretini al
                connection.Open();
                string query = "SELECT Ücret FROM Odalar WHERE OdaID = @OdaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OdaID", secilenOdaID);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    decimal gunlukUcret = Convert.ToDecimal(result);

                    // Günlük ücreti toplam ücrete ekleyerek hesapla
                    toplamUcret = gunSayisi * gunlukUcret;
                }
                else
                {
                    MessageBox.Show("Seçilen oda için ücret bilgisi bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplam ücret hesaplanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return toplamUcret;
        }

    }
}

