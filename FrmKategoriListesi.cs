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
            frm.isUpdate = false;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;//Yeni açılan form kapatıldığında buradaki kategori listesi formuna gitmesini sağlar olmasaydı menü formuna gidecekti
            Doldur();
        }
        KategoriDTO dto = new KategoriDTO();
        KategoriBLL bll = new KategoriBLL();
        private void FrmKategoriListesi_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void txtKategoriAd_TextChanged(object sender, EventArgs e)
        {
            List<KategoriDetayDTO> list = new List<KategoriDetayDTO>();
            list = dto.Kategoriler;
            list = list.Where(x => x.KategoriAd.Contains(txtKategoriAd.Text)).ToList(); // dinamik filtrelemeye yarar kategori.ad içerisindde Eğer kullanıcı txtKategoriAd alanına yazı yazarsa ona göre gstereceği şeyler değişir
            dataGridView1.DataSource = list;
        }

        public void Doldur()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Kategoriler;
            dataGridView1.Columns[0].Visible = false; //Tablonun ID kısmı
            dataGridView1.Columns[1].HeaderText = "Kategori Adı";
        }

        KategoriDetayDTO detay = new KategoriDetayDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detay.KategoriAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (detay.ID == 0)
                MessageBox.Show("Kategori seçiniz");
            else
            {
                FrmKategori frm = new FrmKategori();
                frm.isUpdate = true;
                frm.detay = detay;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                dto = bll.Select();
                dataGridView1.DataSource = dto.Kategoriler;
            }
        }
    }
}
