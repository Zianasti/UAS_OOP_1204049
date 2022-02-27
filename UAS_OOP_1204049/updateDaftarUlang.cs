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
    public partial class updateDaftarUlang : Form
    {
        private DataSet DataSet;
        public updateDaftarUlang()
        {
            InitializeComponent();
            refreshDataSet();
        }
        

        public DataSet DuDataSet()
        {
            DataSet DataSet = new DataSet();

            try
            {
                SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = "SELECT * FROM tr_daftar_ulang";
                myCommand.CommandType = CommandType.Text;

                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.TableMappings.Add("Table", "Daftar Ulang");

                myDataAdapter.Fill(DataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return DataSet;

        }

        private void refreshDataSet()
        {
            DataSet = DuDataSet();
            dgDu.DataSource = DataSet.Tables["Daftar Ulang"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");


            myConnection.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter("select * from tr_daftar_ulang ", myConnection);
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

                int rowsUpdated = myAdapter.Update(DataSet, "Daftar Ulang");

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
