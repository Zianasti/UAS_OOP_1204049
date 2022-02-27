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
    public partial class updateMahasiswa : Form
    {
        public updateMahasiswa()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private SqlCommand cmd1;
        private SqlDataAdapter DataAdapter;
        private DataSet DataSet;

        private void updateMahasiswa_Load(object sender, EventArgs e)
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


        private void btnUpdate_Click(object sender, EventArgs e)
        {
                SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");

                
                myConnection.Open();
                
                SqlDataAdapter myAdapter = new SqlDataAdapter("select * from ms_mhs", myConnection);
                SqlCommandBuilder myCmdBuilder = new SqlCommandBuilder(myAdapter);

                
                myAdapter.InsertCommand = myCmdBuilder.GetInsertCommand();
                myAdapter.UpdateCommand = myCmdBuilder.GetUpdateCommand();
                myAdapter.DeleteCommand = myCmdBuilder.GetDeleteCommand();

               
                SqlTransaction myTransaction;
                myTransaction = myConnection.BeginTransaction();
                myAdapter.DeleteCommand.Transaction = myTransaction;
                myAdapter.UpdateCommand.Transaction = myTransaction;
                myAdapter.InsertCommand.Transaction = myTransaction;

                
                try
                {
                   
                    int rowsUpdated = myAdapter.Update(DataSet, "ms_mhs");
                    
                    myTransaction.Commit();
                    
                    MessageBox.Show(rowsUpdated.ToString() + "Baris diperbarui", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update: " + ex.Message);
                  
                    myTransaction.Rollback();
                }
        }

        
    }
}
