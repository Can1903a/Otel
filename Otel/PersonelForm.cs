using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Otel
{
    public partial class PersonelForm : Form
    {
        private SqlConnection connection;
        private int musteriID;
        private decimal tutar;

        public PersonelForm(SqlConnection baglanti)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);

        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            OdalariListele();
            MusterileriListele();
        }

        private void MusterileriListele()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Musteriler";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewMusteri.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler listelenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void MusteriSil(int musteriID)
        {
            try
            {
                connection.Open();

                // Öncelikle rezervasyonun varlığını ve durumunu kontrol et
                string rezervasyonKontrolSorgu = "SELECT COUNT(*) FROM Rezervasyonlar WHERE MusteriID = @MusteriID AND Durum = 'Aktif'";
                SqlCommand rezervasyonKontrolKomut = new SqlCommand(rezervasyonKontrolSorgu, connection);
                rezervasyonKontrolKomut.Parameters.AddWithValue("@MusteriID", musteriID);
                int rezervasyonSayisi = Convert.ToInt32(rezervasyonKontrolKomut.ExecuteScalar());

                if (rezervasyonSayisi > 0)
                {
                    MessageBox.Show("Bu müşteriye ait aktif rezervasyonlar bulunmaktadır. Müşteri silinemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Müşteriyi silme işlemi gerçekleştirilebilir
                string musteriSorgu = "DELETE FROM Musteriler WHERE MusteriID = @MusteriID";
                SqlCommand musteriKomut = new SqlCommand(musteriSorgu, connection);
                musteriKomut.Parameters.AddWithValue("@MusteriID", musteriID);
                musteriKomut.ExecuteNonQuery();

                MessageBox.Show("Müşteri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }




        private void OdalariListele()
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT * FROM Odalar";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewOda.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalari listelerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridViewOda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            PersonelGiris pgris = new PersonelGiris(connection);
            pgris.Show();
            this.Hide(); 
        }
        private void OdaBilgileriniGuncelle(decimal tutar)
        {
            try
            {
                connection.Open();
                string sorgu = "UPDATE Odalar SET OdaTürü = @OdaTürü, Ücret = @Ücret, Durum = @Durum WHERE OdaID = @OdaID";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@OdaTürü", txtOdaTuru.Text);
                if (decimal.TryParse(txtUcret.Text, out tutar))
                {
                    komut.Parameters.AddWithValue("@Ücret", tutar);
                }
                else
                {
                    MessageBox.Show("Geçerli bir ücret değeri girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Metodu burada sonlandır
                }
                komut.Parameters.AddWithValue("@Durum", txtDurum.Text);
                int odaID = Convert.ToInt32(lblOdaID.Text); // Varsayalım ki OdaID değeri bir label kontrolünde tutuluyor
                komut.Parameters.AddWithValue("@OdaID", odaID);

                komut.ExecuteNonQuery();
                MessageBox.Show("Oda özellikleri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdalariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda özellikleri güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OdaBilgileriniGuncelle(tutar);
        }

        private void dataGridViewOda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOda.Rows[e.RowIndex];
                int odaID = Convert.ToInt32(row.Cells["OdaID"].Value);
                string odaTuru = row.Cells["OdaTürü"].Value.ToString();
                string odaUcret = row.Cells["Ücret"].Value.ToString();
                string odaDurum = row.Cells["Durum"].Value.ToString();
                lblOdaID.Text = row.Cells["OdaID"].Value.ToString();

                txtOdaTuru.Text = odaTuru;
                txtUcret.Text = odaUcret;
                txtDurum.Text = odaDurum;
            }
        }


        private void dataGridViewMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMusteri.Rows[e.RowIndex];
                int musteriID = Convert.ToInt32(row.Cells["MusteriID"].Value);
                string musteriAdi = row.Cells["Ad"].Value.ToString();
                string musteriSyd = row.Cells["Soyad"].Value.ToString();
                string musteriTC = row.Cells["MusteriTC"].Value.ToString();
                string musteriEml = row.Cells["Email"].Value.ToString();
                string musteriSfr = row.Cells["Sifre"].Value.ToString();
                string musteriTlf = row.Cells["Telefon"].Value.ToString();
                string musteriAdres = row.Cells["Adres"].Value.ToString();


                DialogResult result = MessageBox.Show(musteriAdi + " adlı müşteriyi silmek istediğinizden emin misiniz?", "Müşteri Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    MusteriSil(musteriID);
                    MusterileriListele(); // Müşterilerin güncel listesini göstermek için
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PersonelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
    }

