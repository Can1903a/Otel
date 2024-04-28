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
        private SqlConnection baglanti;

        public YoneticiGiris(SqlConnection baglanti)
        {
            this.baglanti = baglanti;
        }
        public YoneticiGiris()
        {
            InitializeComponent();
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
    }
}
