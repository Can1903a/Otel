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
    public partial class RezervasyonDetay : Form
    {
        private SqlConnection connection;
        public RezervasyonDetay(SqlConnection baglanti,int odaID,string musteriAdi)
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-CJ8MO5Q;Initial Catalog=OtelDB;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void RezervasyonDetay_Load(object sender, EventArgs e)
        {

        }
    }
}
