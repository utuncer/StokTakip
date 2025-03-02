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
using StokTakip.DAL;
using StokTakip.BLL;
using StokTakip.DAL.DAO;

namespace StokTakip
{
    public partial class FrmKategoriListesi : Form
    {
        public FrmKategoriListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKategori frm = new FrmKategori();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
        KategoriDTO dto = new KategoriDTO();
        KategoriBLL bll = new KategoriBLL();
        private void FrmKategoriListesi_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Kategoriler;
            dataGridView1.Columns[0].Visible = false; //Tablonun ID kısmı
            dataGridView1.Columns[1].HeaderText = "Kategori Adı";
        }

        private void txtKategoriAd_TextChanged(object sender, EventArgs e)
        {
            List<KategoriDetayDTO> list = new List<KategoriDetayDTO>();
            list = dto.Kategoriler;
            list = list.Where(x => x.KategoriAd.Contains(txtKategoriAd.Text)).ToList();
            dataGridView1.DataSource = list;
        }
    }
}
