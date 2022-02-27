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
    public partial class viewMahasiswa : Form
    {
        public viewMahasiswa()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private SqlCommand cmd1;
        private SqlDataAdapter DataAdapter;
        private DataSet DataSet;

        private void viewMahasiswa_Load(object sender, EventArgs e)
        {
             
            string constr = @"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True";
            conn = new SqlConnection(constr);
            conn.Open();
            cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from ms_mhs";
            DataSet = new DataSet();
            DataAdapter = new SqlDataAdapter(cmd1);
            DataAdapter.Fill(DataSet, "ms_mhs");
            dgMhs.DataSource = DataSet;
            dgMhs.DataMember = "ms_mhs";
            dgMhs.Refresh();
            conn.Close();
        }
    
    }
}
