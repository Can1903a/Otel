using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Otel
{
    public partial class YoneticiGiris : Form
    {
        private SqlConnection connection;

        public YoneticiGiris(SqlConnection baglanti)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }


        private void YoneticiGiris_Load(object sender, EventArgs e)
        {

        }

        private void pictureboxGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            string adminKullaniciAdi = "admin";
            string adminSifre = "123";

            string girilenKullaniciAdi = txtKullaniciAdi.Text;
            string girilenSifre = txtSifre.Text;

            if (girilenKullaniciAdi == adminKullaniciAdi && girilenSifre == adminSifre)
            {
                YoneticiForm yoneticiForm = new YoneticiForm(connection);
                yoneticiForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
        }

        private void YoneticiGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
