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
    public partial class Daftar_Ulang_Mahasiswa : Form
    {
        public Daftar_Ulang_Mahasiswa()
        {
            InitializeComponent();
        }

        //membuat method updateDB dengan parameter cmd
        private void UpdateDB(string cmd)
        {
            //exception handler
            try
            {
                //connection untuk koneksi ke basisdata P6_1204049
                SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");

                //membuka koneksi, menggunakan object myConnection
                myConnection.Open();

                //membuat objek dengan nama myCommand, inisialisasi dari class sqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata yang digunakan yaitu object myConnection
                myCommand.Connection = myConnection;

                //mengatur query yang digunakan, diambil dari parameter cmd
                myCommand.CommandText = cmd;

                //eksekusi myCommand yang diambil dari parameter cmd
                myCommand.ExecuteNonQuery();

                //menampilkan pesan jika eksekusi berhasil
                MessageBox.Show("Data Berhasil Disubmit !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //penanganan apabila terjadi error pada saat try, exception diset dalam variabel ex
            catch (Exception ex)
            {
                //menampilkan pesan kesalahan
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // perintah SQL untuk menyimpan data inputan user ke basisdata
            string myCmd = "INSERT INTO tr_daftar_ulang VALUES ('"
                + txtNpm.Text + "','"
                + gbGrade.Text + "','"
                + txtTotal.Text + "',')";

            //memanggil method UpdateDB dengan set parameter myCmd
            UpdateDB(myCmd);
        }

        private void clear()
        {
            //mengosongkan isian dalam TextBox
            txtNpm.Text = "";
            gbGrade.Text = "";
            txtTotal.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
