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
    public partial class Input_Program_Studi : Form
    {
        public Input_Program_Studi()
        {
            InitializeComponent();
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

        

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (txtKodeProdi.Text != "")
            {
                if (txtNamaProdi.Text != "")
                {
                    if (txtSingkatan.Text != "")
                    {
                        if (txtBikul.Text != "")
                        {
                            string myCmd = "INSERT INTO ms_prodi VALUES ('"
                            + txtKodeProdi.Text + "','"
                            + txtNamaProdi.Text + "','"
                            + txtSingkatan.Text + "','"
                            + txtBikul.Text + "')";
                            UpdateDB(myCmd);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Biaya Kuliah harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Singkatan Program Studi harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nama Program Studi harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Kode Program Studi harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clear()
        {
            txtKodeProdi.Text = "";
            txtNamaProdi.Text = "";
            txtSingkatan.Text = "";
            txtBikul.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtBikul_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtNamaProdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSingkatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
