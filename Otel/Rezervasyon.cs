using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Otel
{   
    public partial class Rezervasyon : Form
    {
        private SqlConnection connection;
        private object musteriID;
        private int secilenOdaID;
        private object odaID;

        public Rezervasyon(SqlConnection baglanti,int musteriID)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            this.musteriID = musteriID;
            dateTimePickerCikisTarihi.MinDate = DateTime.Today;
            dateTimePickerGirisTarihi.MinDate = DateTime.Today;


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

            dateTimePickerGirisTarihi.ValueChanged += new EventHandler(dateTimePickerGirisTarihi_ValueChanged);
            dateTimePickerCikisTarihi.ValueChanged += new EventHandler(dateTimePickerCikisTarihi_ValueChanged);

            OdalariYukle();
            RezervasyonSonlandir();

        }


private void FaturaOlustur(object musteriID, int secilenOdaID, DateTime girisTarihi, DateTime cikisTarihi, decimal toplamUcret)
    {
        try
        {
            // PDF belgesini oluşturma
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Projenin çalıştırıldığı dizini alma
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string pdfDirectory = Path.Combine(projectDirectory, "Fatura");

            // Klasör yoksa oluştur
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            // Dosya yolunu oluştur
            string filePath = Path.Combine(pdfDirectory, $"Fatura_{musteriID}_{DateTime.Now.Ticks}.pdf");

            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Başlık ve stil tanımları
            iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font bodyFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);

            // Fatura başlığı
            Paragraph title = new Paragraph("Fatura", titleFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            };
            document.Add(title);

            // Fatura detaylarını tablo ile ekleme
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1, 2 });

                Ekle(table, "Müşteri ID:", headerFont);
                Ekle(table, musteriID.ToString(), bodyFont);

                Ekle(table, "Oda ID:", headerFont);
                Ekle(table, secilenOdaID.ToString(), bodyFont);

                Ekle(table, "Giriş Tarihi:", headerFont);
                Ekle(table, girisTarihi.ToString("dd.MM.yyyy"), bodyFont);

                Ekle(table, "Çıkış Tarihi:", headerFont);
                Ekle(table, cikisTarihi.ToString("dd.MM.yyyy"), bodyFont);

                Ekle(table, "Toplam Ücret:", headerFont);
                Ekle(table, toplamUcret.ToString("C"), bodyFont);

                Ekle(table, "Tarih:", headerFont);
                Ekle(table, DateTime.Now.ToString("dd.MM.yyyy"), bodyFont);

            document.Add(table);

            // Kapanış
            document.Close();

            MessageBox.Show("Fatura başarıyla oluşturuldu. Fatura konumu: " + filePath, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fatura oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Yardımcı metot: Tablo hücresi ekleme
    private void Ekle(PdfPTable table, string text, iTextSharp.text.Font font)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, font))
        {
            Border = iTextSharp.text.Rectangle.NO_BORDER,
            Padding = 5
        };
        table.AddCell(cell);
    }




    private void OdalariYukle()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT OdaID, Durum, OdaTürü FROM Odalar";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataReader reader = komut.ExecuteReader();

                int pictureBoxIndex = 1;
                int x = 80; // PictureBox'ın başlangıç x koordinatı
                int y = 30; // PictureBox'ın başlangıç y koordinatı
                int pictureBoxPerRow = 6; // Her sırada kaç PictureBox olacağı
                int pictureBoxWidth = 100; // PictureBox genişliği
                int pictureBoxHeight = 100; // PictureBox yüksekliği

                while (reader.Read())
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "pictureBox" + reader["OdaID"].ToString();
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

                    // Odanın türünü gösteren bir Label oluştur
                    Label label = new Label();
                    label.Text = reader["OdaTürü"].ToString();
                    label.AutoSize = true;
                    label.Location = new Point(x, y + pictureBoxHeight + 5); // PictureBox'ın altında 5 piksel boşluk bırakarak yerleştir
                    this.Controls.Add(label);

                    pictureBoxIndex++;

                    // PictureBox'ın yatay konumunu güncelleme
                    x += pictureBoxWidth + 10; // 10 piksel boşluk bırakarak PictureBox'ları yan yana yerleştir

                    // Her satırda belirtilen sayıda PictureBox varsa, bir sonraki satıra geç
                    if (pictureBoxIndex % pictureBoxPerRow == 0)
                    {
                        x = 20; // X koordinatını başa al
                        y += pictureBoxHeight + 10 + label.Height; // Y koordinatını bir sonraki satıra taşı
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


        private void OdaninOzellikleriniYukle(int secilenOdaID)
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Odalar WHERE OdaID = @OdaID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@OdaID", secilenOdaID);
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
        private bool OdaDoluMu(int odaID)
        {
            bool odaDolu = false;
            try
            {
                connection.Open();
                string sorgu = "SELECT Durum FROM Odalar WHERE OdaID = @OdaID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@OdaID", odaID);
                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    string durum = reader["Durum"].ToString();
                    if (durum == "Dolu")
                    {
                        odaDolu = true;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda durumu kontrol edilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return odaDolu;
        }
        private void OdaDurumunuGuncelle(int odaID)
        {
            string sorgu = "SELECT O.Durum FROM Odalar O JOIN Rezervasyonlar R ON R.OdaID = O.OdaID WHERE O.OdaID = @OdaID";
            SqlCommand komut = new SqlCommand(sorgu, connection);
            komut.Parameters.AddWithValue("@OdaID", odaID);
            string odaDurumu = komut.ExecuteScalar().ToString(); // Oda durumu bilgisini al

            if (odaDurumu == "Boş")
            {
                // Oda dolu olarak güncelleniyor
                string guncelle = "UPDATE Odalar SET Durum = 'Dolu' WHERE OdaID = @OdaID";
                SqlCommand cmd = new SqlCommand(guncelle, connection);
                cmd.Parameters.AddWithValue("@OdaID", odaID);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Oda durumu başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oda durumu güncellenirken bir hata oluştu veya etkilenen satır yok!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seçilen oda zaten dolu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool OdaKiralamayaUygunMu(int musteriID)
        {
            bool uygun = true;

            try
            {
                connection.Open();

                // Müşterinin aktif bir rezervasyonu var mı kontrol ediyoruz
                string sorgu = "SELECT COUNT(*) FROM Rezervasyonlar WHERE MusteriID = @MusteriID AND Durum = 'Aktif'";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@MusteriID", musteriID);
                int rezervasyonSayisi = Convert.ToInt32(komut.ExecuteScalar());

                // Eğer müşterinin aktif bir rezervasyonu varsa uygun değişkenini false olarak ayarlıyoruz
                if (rezervasyonSayisi > 0)
                {
                    uygun = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşterinin rezervasyon durumu kontrol edilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return uygun;
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {

            if (secilenOdaID == 0)
            {
                MessageBox.Show("Lütfen bir oda seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (OdaDoluMu(secilenOdaID))
            {
                MessageBox.Show("Seçilen oda dolu olduğu için rezervasyon yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (OdaKiralamayaUygunMu((int)musteriID))
            {

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
                        // Rezervasyon başarıyla yapıldı, toplam miktarı Gelir tablosuna ekleyin
                        string gelirInsertQuery = "INSERT INTO Gelir (MusteriID, Tutar, Tarih, Aciklama) VALUES (@MusteriID, @GelirMiktari, @Tarih, @Aciklama)";
                        SqlCommand gelirInsertCommand = new SqlCommand(gelirInsertQuery, connection);
                        gelirInsertCommand.Parameters.AddWithValue("@MusteriID", musteriID);
                        gelirInsertCommand.Parameters.AddWithValue("@GelirMiktari", toplamUcret);
                        gelirInsertCommand.Parameters.AddWithValue("@Tarih", DateTime.Now);
                        gelirInsertCommand.Parameters.AddWithValue("@Aciklama", "Oda ücreti");
                        gelirInsertCommand.ExecuteNonQuery();

                        // Fatura oluşturma işlemi
                        FaturaOlustur(musteriID,secilenOdaID,girisTarihi,cikisTarihi,toplamUcret);


                        MessageBox.Show("Rezervasyon başarıyla yapıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OdaDurumunuGuncelle(secilenOdaID);
                        PictureBox pictureBox = this.Controls.Find("pictureBox" + secilenOdaID.ToString(), true).FirstOrDefault() as PictureBox;
                        if (pictureBox != null)
                        {
                            pictureBox.Image = Properties.Resources.kirmizi_yatak3;
                        }

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
            else
            {
                MessageBox.Show("Müşterinin aktif bir rezervasyonu bulunduğu için oda kiralama işlemi yapılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            RezervasyonSonlandir();
        }


        private void RezervasyonSonlandir()
        {
            try
            {
                connection.Open();

                // Aktif rezervasyonların sona erme tarihini kontrol et
                string sorgu = "SELECT RezervasyonID, ÇıkışTarihi FROM Rezervasyonlar WHERE Durum = 'Aktif'";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    int rezervasyonID = (int)reader["RezervasyonID"];
                    DateTime cikisTarihi = (DateTime)reader["ÇıkışTarihi"];

                    // Mevcut tarihi al
                    DateTime mevcutTarih = DateTime.Now;

                    // Eğer mevcut tarih çıkış tarihinden büyük veya eşitse, rezervasyon sona ermiştir
                    if (mevcutTarih >= cikisTarihi)
                    {
                        // Rezervasyon durumunu deaktif olarak güncelle
                        string guncelleSorgu = "UPDATE Rezervasyonlar SET Durum = 'Deaktif' WHERE RezervasyonID = @RezervasyonID";
                        SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, connection);
                        guncelleKomut.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);
                        guncelleKomut.ExecuteNonQuery();

                        // İlgili odayı boş olarak güncelle
                        string odaGuncelleSorgu = "UPDATE Odalar SET Durum = 'Boş' WHERE OdaID = (SELECT OdaID FROM Rezervasyonlar WHERE RezervasyonID = @RezervasyonID)";
                        SqlCommand odaGuncelleKomut = new SqlCommand(odaGuncelleSorgu, connection);
                        odaGuncelleKomut.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);
                        odaGuncelleKomut.ExecuteNonQuery();
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonları kontrol ederken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            MusteriForm mform = new MusteriForm((int)musteriID);
            mform.Show();
            this.Close();
        }

        private void dateTimePickerGirisTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerGirisTarihi.Value > dateTimePickerCikisTarihi.Value)
            {
                MessageBox.Show("Giriş tarihi, çıkış tarihinden sonra olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerGirisTarihi.Value = dateTimePickerCikisTarihi.Value;
            }
        }

        private void dateTimePickerCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerCikisTarihi.Value < dateTimePickerGirisTarihi.Value)
            {
                MessageBox.Show("Çıkış tarihi, giriş tarihinden önce olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerCikisTarihi.Value = dateTimePickerGirisTarihi.Value;
            }
        }

        private void Rezervasyon_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}

