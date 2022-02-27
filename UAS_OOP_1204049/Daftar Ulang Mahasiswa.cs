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

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            int potbiaya = (Int32.Parse(txtBikul.Text.ToString()) * 50) / 100;
            txtPotBiaya.Text = potbiaya.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - potbiaya;
            txtTotal.Text = totalbiaya.ToString();
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            int potbiaya = (Int32.Parse(txtBikul.Text.ToString()) * 25) / 100;
            txtPotBiaya.Text = potbiaya.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - potbiaya;
            txtTotal.Text = totalbiaya.ToString();
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            int potbiaya = (Int32.Parse(txtBikul.Text.ToString()) * 10) / 100;
            txtPotBiaya.Text = potbiaya.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - potbiaya;
            txtTotal.Text = totalbiaya.ToString();
        }

        private void UpdateDB(string cmd)
        {
            try
            {
              
                SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True");
                
                myConnection.Open();
 
                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConnection;
                
                myCommand.CommandText = cmd;
                
                myCommand.ExecuteNonQuery();
                
                MessageBox.Show("Data Berhasil Disubmit !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void clear()
        {
            
            txtNpm.Text = "";
            TxtNamaMhs.Text = "";
            txtProdi.Text = "";
            txtBikul.Text = "";
            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            txtPotBiaya.Text = "";
            txtTotal.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtNpm.Text != "")
            {
                if (rbA.Checked != false || rbB.Checked != false || rbC.Checked != false)
                {
                    string grade = "";
                    if (rbA.Checked)
                    {
                        grade = "A";
                    }
                    if (rbB.Checked)
                    {
                        grade = "B";
                    }
                    if (rbC.Checked)
                    {
                        grade = "C";
                    }

                    string cmd = "INSERT INTO tr_daftar_ulang VALUES ('"
                       + txtNpm.Text + "','"
                       + grade + "','"
                       + txtTotal.Text + "')";
                    UpdateDB(cmd);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Grade Seleksi harus dipilih !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("NPM harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void txtNpm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        

        private void btnCari_Click(object sender, EventArgs e)
        {
            string getSql = "SELECT nama_mhs,nama_prodi,biaya_kuliah FROM ms_mhs " +
                "JOIN ms_prodi ON ms_mhs.kode_prodi=ms_prodi.kode_prodi WHERE npm='" + txtNpm.Text + "'";

            string connection = @"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = UAS; Integrated Security = True";
            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand sc = new SqlCommand(getSql, myConnection);
            SqlDataReader Result;

            Result = sc.ExecuteReader();
            if (Result.HasRows)
            {
                while (Result.Read())
                {
                    TxtNamaMhs.Text = Result["nama_mhs"].ToString();
                    txtProdi.Text = Result["nama_prodi"].ToString();
                    txtBikul.Text = Result["biaya_kuliah"].ToString();
                }
            }
        }
    }
}
