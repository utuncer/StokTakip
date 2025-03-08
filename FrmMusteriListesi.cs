using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.DAL.DTO;
using StokTakip.BLL;
using StokTakip.DAL.DAO;

namespace StokTakip
{
    public partial class FrmMusteriListesi : Form
    {
        public FrmMusteriListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmMusteri frm = new FrmMusteri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Musteriler;
        }
        MusteriBLL bll = new MusteriBLL();
        MusteriDTO dto = new MusteriDTO();
        private void FrmMusteriListesi_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Musteriler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
        }
    }
}
