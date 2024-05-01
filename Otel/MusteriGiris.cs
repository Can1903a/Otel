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
    public partial class MusteriGiris : Form
    {
        private SqlConnection connection;

        public MusteriGiris(SqlConnection baglanti)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void MusteriGiris_Load(object sender, EventArgs e)
        {

        }

        private void MusteriGirisButton_Click(object sender, EventArgs e)
        {
            string musteriTC = txtTC.Text;
            string sifre = txtSifre.Text;

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MusteriTC,Sifre FROM Musteriler WHERE MusteriTC = @MusteriTC AND Sifre = @Sifre", connection))
                {
                    cmd.Parameters.AddWithValue("@MusteriTC", musteriTC);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Okuma işlemleri
                    if (reader.Read()) // Okuyucu bir satır okuyabilirse
                    {
                        // Giriş başarılıysa ana formu aç
                        Anasayfa anaForm = new Anasayfa();
                        anaForm.Show();
                        this.Hide(); // Personel giriş formunu gizle
                    }
                    else
                    {
                        MessageBox.Show("TC Kimlik Numarası veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Kullanıcı adı ve şifre alanlarını temizle
                        txtTC.Text = "";
                        txtSifre.Text = "";
                    }

                    reader.Close(); // Okuyucuyu kapat
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Bağlantıyı her durumda kapatın
            }

        }
    }
}
