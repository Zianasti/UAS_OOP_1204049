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

     
        private DataSet ds_Mhs;

        public DataSet CreateMhsDataSet()
        {
            DataSet myDataSet = new DataSet();

            try
            {
                
                SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");

                
                SqlCommand myCommand = new SqlCommand();

                
                myCommand.Connection = myConnection;

                
                myCommand.CommandText = "SELECT * FROM ms_mhs";
                myCommand.CommandType = CommandType.Text;

                
                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.TableMappings.Add("Table", "Mahasiswa");

                
                myDataAdapter.Fill(myDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return myDataSet;
        }

        private void RefreshDataSet()
        {
           
            ds_Mhs = CreateMhsDataSet();
            
            dgMhs.DataSource = ds_Mhs.Tables["Mahasiswa"];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSet();
        }
    }
}
