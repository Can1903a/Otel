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
    public partial class MusteriForm : Form
    {
        private SqlConnection connection;
        private int musteriID;
        private int odaID;
        public MusteriForm(SqlConnection baglanti, int musteriID)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection = baglanti;
            this.musteriID = musteriID;
            this.odaID = odaID;
        }
        private void MusteriForm_Load(object sender, EventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Rezervasyon rfrom = new Rezervasyon(connection,odaID,musteriID);
            rfrom.Show();
            this.Hide();
        }
    }

}
