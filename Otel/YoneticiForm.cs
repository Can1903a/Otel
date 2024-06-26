﻿using System;
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
    public partial class YoneticiForm : Form
    {
        private SqlConnection connection;
        public YoneticiForm(SqlConnection baglanti)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            PersonelBilgileriniYukle();
        }

        private void YoneticiForm_Load(object sender, EventArgs e)
        {
            PersonelBilgileriniYukle();
            GelirleriGoruntule();
            GelirGiderHesapla();
            GiderleriGoruntule();
        }

        private void GiderleriGoruntule()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Gider";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGider.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelirleri görüntülerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void GelirleriGoruntule()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Gelir";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewGelir.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelirleri görüntülerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void GiderEkle(string aciklama, decimal tutar, int? personelID)
        {
            try
            {
                connection.Open();
                string sorgu = "INSERT INTO Gider (Aciklama, Tutar, Tarih, PersonelID) VALUES (@Aciklama, @Tutar, @Tarih, @PersonelID)";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@Aciklama", aciklama);
                komut.Parameters.AddWithValue("@Tutar", tutar);
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                if (personelID.HasValue)
                {
                    komut.Parameters.AddWithValue("@PersonelID", personelID);
                }
                else
                {
                    komut.Parameters.AddWithValue("@PersonelID", DBNull.Value);
                }
                komut.ExecuteNonQuery();
                MessageBox.Show("Gider başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void GelirGiderHesapla()
        {
            try
            {
                connection.Open();

                // Gelir hesaplama
                string gelirSorgu = "SELECT SUM(Tutar) FROM Gelir";
                SqlCommand gelirKomut = new SqlCommand(gelirSorgu, connection);
                object gelirObj = gelirKomut.ExecuteScalar();
                decimal gelir = gelirObj != DBNull.Value ? Convert.ToDecimal(gelirObj) : 0;

                // Gider hesaplama
                string giderSorgu = "SELECT SUM(Tutar) FROM Gider";
                SqlCommand giderKomut = new SqlCommand(giderSorgu, connection);
                object giderObj = giderKomut.ExecuteScalar();
                decimal gider = giderObj != DBNull.Value ? Convert.ToDecimal(giderObj) : 0;

                // Kar hesaplama
                decimal kar = gelir - gider;

                lblGelir.Text = "Toplam Gelir: " + gelir.ToString("C2");
                lblGider.Text = "Toplam Gider: " + gider.ToString("C2");
                lblKar.Text = "Kar: " + kar.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelir-gider hesaplanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void PersonelBilgileriniYukle()
        {
            // Personel bilgilerini DataGridView'e yükleme işlemi
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Personel";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewPersonel.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel bilgilerini yüklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void PersonelEkle(string ad, string soyad, string tc,string pozisyon,string email,string sifre,string telefon)
        {
            // Yeni personel eklemek için SQL sorgusu
            try
            {
                connection.Open();
                string sorgu = "INSERT INTO Personel (Ad, Soyad, PersonelTC, Pozisyon, Email, Sifre, Telefon) VALUES (@Ad, @Soyad,@PersonelTC, @Pozisyon,@Email,@Sifre,@Telefon)";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@Ad", ad);
                komut.Parameters.AddWithValue("@Soyad", soyad);
                komut.Parameters.AddWithValue("@PersonelTC", tc);
                komut.Parameters.AddWithValue("@Pozisyon", pozisyon);
                komut.Parameters.AddWithValue("@Email", email);
                komut.Parameters.AddWithValue("@Sifre", sifre);
                komut.Parameters.AddWithValue("@Telefon", telefon);
                

                komut.ExecuteNonQuery();
                MessageBox.Show("Personel başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void PersonelSil(int personelID)
        {
            // Personel silme işlemi
            try
            {
                connection.Open();
                string sorgu = "DELETE FROM Personel WHERE PersonelID = @PersonelID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@PersonelID", personelID);
                komut.ExecuteNonQuery();
                MessageBox.Show("Personel başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridViewPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewPersonel_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView hücresine çift tıklanarak personel güncelleme işlemi yapılabilir
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPersonel.Rows[e.RowIndex];
                int personelID = Convert.ToInt32(row.Cells["PersonelID"].Value);
                string ad = row.Cells["Ad"].Value.ToString();
                string soyad = row.Cells["Soyad"].Value.ToString();
                string tc = row.Cells["PersonelTC"].Value.ToString();
                string pozisyon = row.Cells["Pozisyon"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string sifre = row.Cells["Sifre"].Value.ToString();
                string telefon = row.Cells["Telefon"].Value.ToString();


                PersonelGuncelleForm personelGuncelleForm = new PersonelGuncelleForm(connection, personelID, ad, soyad, tc, pozisyon, email, sifre,telefon);
                personelGuncelleForm.ShowDialog();
                this.Hide();

                // Güncelleme işleminden sonra personel bilgilerini yeniden yükle
                PersonelBilgileriniYukle();
            }
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string tc = txtTC.Text;
            string pozisyon = txtPozisyon.Text;
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;
            string telefon = txtTelefon.Text;



            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(pozisyon) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PersonelEkle(ad, soyad, tc, pozisyon, email, sifre, telefon);

            // Ekleme işleminden sonra personel bilgilerini yeniden yükle
            PersonelBilgileriniYukle();
        }

        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            YoneticiGiris yonetici2 = new YoneticiGiris(connection);
            yonetici2.Show();
            this.Close();
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewPersonel.SelectedRows[0];
            int personelID = Convert.ToInt32(selectedRow.Cells["PersonelID"].Value);

            // Silme işlemi
            DialogResult result = MessageBox.Show("Seçilen personeli silmek istediğinizden emin misiniz?", "Personel Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PersonelSil(personelID);

                // Silme işleminden sonra personel bilgilerini yeniden yükle
                PersonelBilgileriniYukle();
            }
        }

        private void btnGiderEkle_Click(object sender, EventArgs e)
        {
            string aciklama = txtGiderAciklama.Text;
            decimal tutar;

            if (string.IsNullOrEmpty(aciklama))
            {
                MessageBox.Show("Lütfen geçerli bir açıklama girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiderTutar.Text, out tutar) || tutar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir tutar girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? personelID = null;

            if (aciklama.StartsWith("Personel Maaşı - "))
            {
                // Gider açıklaması "Personel Maaşı - " ile başlıyorsa, o zaman PersonelID'yi al
                personelID = Convert.ToInt32(dataGridViewPersonel.CurrentRow.Cells["PersonelID"].Value);
            }

            GiderEkle(aciklama, tutar, personelID);

            // Ekleme işleminden sonra gider bilgilerini yeniden yükle
            GelirGiderHesapla();
        }

        private void dataGridViewPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewPersonel.Rows[e.RowIndex];
                int personelID = Convert.ToInt32(selectedRow.Cells["PersonelID"].Value);
                string adSoyad = selectedRow.Cells["Ad"].Value.ToString() + " " + selectedRow.Cells["Soyad"].Value.ToString();

                // Herhangi bir hücreye tıkladığında, seçilen personele gider eklemeyi sağlar
                txtGiderAciklama.Text = "Personel Maaşı - " + adSoyad;
                txtGiderTutar.Text = ""; // Tutarı kullanıcıya girmesi için boşalt
            }
        }

    }

}

