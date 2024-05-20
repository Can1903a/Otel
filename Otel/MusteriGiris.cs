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
            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTC.Text = "";
                txtSifre.Text = "";
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MusteriTC, MusteriID FROM Musteriler WHERE MusteriTC = @MusteriTC AND Sifre = @Sifre", connection))
                {
                    cmd.Parameters.AddWithValue("@MusteriTC", musteriTC);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() && txtTC.Text.Length == 11)
                    {
                        int musteriID = reader.GetInt32(reader.GetOrdinal("MusteriID"));
                        MusteriForm mform = new MusteriForm(musteriID);
                        mform.Show();

                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("TC Kimlik Numarası veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTC.Text = "";
                        txtSifre.Text = "";
                    }

                    reader.Close();
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

        private void MusteriGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
