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
    public partial class Anasayfa : Form
    {
        private SqlConnection baglanti;

        public Anasayfa()
        {
            InitializeComponent();
            baglanti = new SqlConnection("Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True");
            baglanti.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            // Giris formunu aç
            MusteriGiris musterigiris = new MusteriGiris(baglanti);
            musterigiris.Show();
            this.Hide();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            // Kayit formunu aç
            MusteriKayit musterikayit = new MusteriKayit(baglanti);
            musterikayit.Show();
            this.Hide();
        }

        private void BtnYonetici_Click(object sender, EventArgs e)
        {
            // Yönetici Giris formunu aç
            YoneticiGiris yoneticigiris = new YoneticiGiris();
            yoneticigiris.Show();
            this.Hide();
        }

        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            // Personel Giris formunu aç
            PersonelGiris personelgiris = new PersonelGiris(baglanti);
            personelgiris.Show();
            this.Hide();
        }
    }
}
