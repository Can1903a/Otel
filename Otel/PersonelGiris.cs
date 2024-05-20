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
    public partial class PersonelGiris : Form
    {
        private SqlConnection connection;

        public PersonelGiris(SqlConnection baglanti)
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

        private void PersonelGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            string personelTC = PTCtxt.Text;
            string sifre = Psifretxt.Text;
            if (PTCtxt.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PTCtxt.Text = "";
                Psifretxt.Text = "";
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PersonelTC,Sifre FROM Personel WHERE PersonelTC = @PersonelTC AND Sifre = @Sifre", connection))
                {
                    cmd.Parameters.AddWithValue("@PersonelTC", personelTC);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Okuma işlemleri
                    if (reader.Read() && PTCtxt.Text.Length == 11) // Okuyucu bir satır okuyabilirse
                    {
                        // Giriş başarılıysa ana formu aç
                        PersonelForm personelform = new PersonelForm(connection);
                        personelform.Show();
                        this.Hide(); // Personel giriş formunu gizle

                    }
                    else
                    {
                        MessageBox.Show("TC Kimlik Numarası veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Kullanıcı adı ve şifre alanlarını temizle
                        PTCtxt.Text = "";
                        Psifretxt.Text = "";
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

        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anaForm = new Anasayfa();
            anaForm.Show();
            this.Hide(); // Personel giriş formunu gizle
        }

        private void PersonelGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
