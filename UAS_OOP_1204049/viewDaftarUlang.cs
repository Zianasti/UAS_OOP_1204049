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

namespace UAS_OOP_1204049
{
    public partial class viewDaftarUlang : Form
    {
        public viewDaftarUlang()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private SqlCommand cmd1;
        private SqlDataAdapter DataAdapter;
        private DataSet DataSet;

        private void viewDaftarUlang_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True";
            conn = new SqlConnection(constr);
            conn.Open();
            cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from tr_daftar_ulang";
            DataSet = new DataSet();
            DataAdapter = new SqlDataAdapter(cmd1);
            DataAdapter.Fill(DataSet, "tr_daftar_ulang");
            dgDU.DataSource = DataSet;
            dgDU.DataMember = "tr_daftar_ulang";
            dgDU.Refresh();
            conn.Close();
        }
    }
}
