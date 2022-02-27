using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1204049
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mahasiswa TampilMahasiswa = new Mahasiswa();
            TampilMahasiswa.MdiParent = this;
            TampilMahasiswa.Show();
        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input_Program_Studi TampilProdi = new Input_Program_Studi();
            TampilProdi.MdiParent = this;
            TampilProdi.Show();
        }

        private void daftarUlangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Daftar_Ulang_Mahasiswa TampilDaftarUlang = new Daftar_Ulang_Mahasiswa();
            TampilDaftarUlang.MdiParent = this;
            TampilDaftarUlang.Show();
        }

        private void mahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viewMahasiswa LihatMahasiswa = new viewMahasiswa();
            LihatMahasiswa.MdiParent = this;
            LihatMahasiswa.Show();
        }

        private void prodiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viewProdi LihatProdi = new viewProdi();
            LihatProdi.MdiParent = this;
            LihatProdi.Show();
        }

        private void mahasiswaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateMahasiswa EditMahasiswa = new updateMahasiswa();
            EditMahasiswa.MdiParent = this;
            EditMahasiswa.Show();
        }

        private void prodiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateProdi EditProdi = new updateProdi();
            EditProdi.MdiParent = this;
            EditProdi.Show();
        }

        private void daftarUlangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewDaftarUlang LihatDaftarUlang = new viewDaftarUlang();
            LihatDaftarUlang.MdiParent = this;
            LihatDaftarUlang.Show();
        }

        private void daftarUlangToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateDaftarUlang EditDaftarUlang = new updateDaftarUlang();
            EditDaftarUlang.MdiParent = this;
            EditDaftarUlang.Show();
        }
    }
}
