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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
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

        private void txtSatisMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmSatis frm = new frmSatis();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Satislar;
            Temizle();
        }
        SatisDTO dto = new SatisDTO();
        SatisBLL bll = new SatisBLL();
        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbKategori.DataSource = dto.Kategoriler;
            cmbKategori.DisplayMember = "KategoriAd";
            cmbKategori.ValueMember = "ID";
            cmbKategori.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Satislar;
            dataGridView1.Columns[0].HeaderText = "Ürün Adı";
            dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori";
            dataGridView1.Columns[3].HeaderText = "Fiyat";
            dataGridView1.Columns[4].HeaderText = "Satış Tarihi";
            dataGridView1.Columns[5].HeaderText = "Satış Miktarı";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<SatisDetayDTO> list = dto.Satislar;
            if (txtUrunAd.Text.Trim() != "")
                list = list.Where(x => x.UrunAd.Contains(txtUrunAd.Text)).ToList();
            if (txtMusteriAd.Text.Trim() != "")
                list = list.Where(x => x.MusteriAd.Contains(txtMusteriAd.Text)).ToList();
            if (cmbKategori.SelectedIndex != -1)
                list = list.Where(x => x.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue)).ToList();
            if (rbFiyatBuyuk.Checked)
                list = list.Where(x => x.Fiyat > Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbFiyatEsit.Checked)
                list = list.Where(x => x.Fiyat == Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbFiyatKucuk.Checked)
                list = list.Where(x => x.Fiyat < Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbSatisBuyuk.Checked)
                list = list.Where(x => x.SatisMiktar > Convert.ToInt32(txtSatisMiktar.Text)).ToList();
            if (rbSatisEsit.Checked)
                list = list.Where(x => x.SatisMiktar == Convert.ToInt32(txtSatisMiktar.Text)).ToList();
            if (rbSatisKucuk.Checked)
                list = list.Where(x => x.SatisMiktar < Convert.ToInt32(txtSatisMiktar.Text)).ToList();
            if (cbTarih.Checked)
                list = list.Where(x => x.SatisTarihi > dtpBaslangic.Value && x.SatisTarihi < dtpBitis.Value).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtUrunAd.Clear();
            txtUrunFiyat.Clear();
            txtSatisMiktar.Clear();
            txtUrunFiyat.Clear();
            cmbKategori.SelectedIndex = -1;
            rbFiyatBuyuk.Checked = false;
            rbFiyatEsit.Checked = false;
            rbFiyatKucuk.Checked = false;
            rbSatisBuyuk.Checked = false;
            rbSatisEsit.Checked = false;
            rbSatisKucuk.Checked = false;
            dtpBaslangic.Value = DateTime.Today;
            dtpBitis.Value = DateTime.Today;
            cbTarih.Checked = false;
            dataGridView1.DataSource = dto.Satislar;
        }
    }
}
