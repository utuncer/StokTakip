using StokTakip.BLL;
using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUrunFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUrunStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmUrun frm = new FrmUrun();
            this.Hide();
            frm.dto = dto;
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Urunler;
        }
        UrunBLL bll = new UrunBLL();
        UrunDTO dto = new UrunDTO();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Urunler;
            cmbKategori.DataSource = dto.Kategoriler;
            cmbKategori.DisplayMember = "KategoriAd";
            cmbKategori.ValueMember = "ID";
            cmbKategori.SelectedIndex = -1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori";
            dataGridView1.Columns[3].HeaderText = "Stok";
            dataGridView1.Columns[4].HeaderText = "Ürün Fiyatı";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<UrunDetayDTO> list = new List<UrunDetayDTO>();
            list = dto.Urunler;
            if (txtUrunAd.Text.Trim() != "")
                list = list.Where(x => x.UrunAd.Contains(txtUrunAd.Text)).ToList();
            if (cmbKategori.SelectedIndex != -1)
                list = list.Where(x => x.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue)).ToList();
            if (rbFiyatBuyuk.Checked)
                list = list.Where(x => x.Fiyat > Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbFiyatEsit.Checked)
                list = list.Where(x => x.Fiyat == Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbFiyatKucuk.Checked)
                list = list.Where(x => x.Fiyat < Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbStokBuyuk.Checked)
                list = list.Where(x => x.StokMiktar > Convert.ToInt32(txtUrunStok.Text)).ToList();
            if (rbStokEsit.Checked)
                list = list.Where(x => x.StokMiktar == Convert.ToInt32(txtUrunStok.Text)).ToList();
            if (rbStokKucuk.Checked)
                list = list.Where(x => x.StokMiktar < Convert.ToInt32(txtUrunStok.Text)).ToList();


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtUrunAd.Clear();
            txtUrunFiyat.Clear();
            txtUrunStok.Clear();
            cmbKategori.SelectedIndex = -1;
            rbFiyatBuyuk.Checked = false;
            rbFiyatEsit.Checked = false;
            rbFiyatKucuk.Checked = false;
            rbStokBuyuk.Checked = false;
            rbStokEsit.Checked = false;
            rbStokKucuk.Checked = false;
            dataGridView1.DataSource = dto.Urunler;
        }
    }
}
