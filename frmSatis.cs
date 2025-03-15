using StokTakip.BLL;
using StokTakip.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUrunSatisMiktari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public SatisDTO dto = new SatisDTO();
        public SatisDetayDTO detaydto = new SatisDetayDTO();
        public bool isUpdate = false;
        private void frmSatis_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                panel1.Visible = false;
                txtMusteri.Text = detaydto.MusteriAd.Trim();
                txtUrunAd.Text = detaydto.UrunAd.Trim();
                txtUrunFiyat.Text = detaydto.Fiyat.ToString();
                List<UrunDetayDTO> urunler = dto.Urunler;
                MessageBox.Show("detaydto.UrunID = " + detaydto.UrunID);

                UrunDetayDTO urun = urunler.First(x => x.ID == detaydto.UrunID); //Hata
                txtStok.Text = urun.StokMiktar.ToString();
            }
            else
            {
                gridMusteriler.DataSource = dto.Musteriler;
                gridMusteriler.Columns[0].Visible = false;
                gridMusteriler.Columns[1].HeaderText = "Müşteri Adı";
                gridUrunler.DataSource = dto.Urunler;
                gridUrunler.Columns[0].Visible = false;
                gridUrunler.Columns[5].Visible = false;
                gridUrunler.Columns[6].Visible = false;
                gridUrunler.Columns[3].Visible = false;
                gridUrunler.Columns[4].Visible = false;
                gridUrunler.Columns[1].HeaderText = "Ürün Adı";
                gridUrunler.Columns[2].HeaderText = "Kategori";
                cmbKategori.DataSource = dto.Kategoriler;
                cmbKategori.DisplayMember = "KategoriAd";
                cmbKategori.ValueMember = "ID";
                cmbKategori.SelectedIndex = -1;
                if (dto.Kategoriler.Count > 0)
                    combofull = true;
            }


        }
        bool combofull = false;
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<UrunDetayDTO> list = dto.Urunler;
                if (cmbKategori.SelectedIndex != -1)
                {
                    list = list.Where(x => x.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue)).ToList();
                    gridUrunler.DataSource = list;
                }
            }
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            List<MusteriDetayDTO> list = dto.Musteriler.Where(x => x.MusteriAd.Contains(txtMusteriAd.Text)).ToList();
            gridMusteriler.DataSource = list;
        }
        SatisDetayDTO detay = new SatisDetayDTO();
        private void gridUrunler_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.UrunID = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[0].Value);
            detay.StokMiktar = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[3].Value);
            detay.Fiyat = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[4].Value);
            detay.KategoriID = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[5].Value);
            detay.UrunAd = gridUrunler.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtStok.Text = detay.StokMiktar.ToString();
            txtUrunAd.Text = detay.UrunAd.Trim();
            txtUrunFiyat.Text = detay.Fiyat.ToString();
        }

        private void gridMusteriler_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.MusteriID = Convert.ToInt32(gridMusteriler.Rows[e.RowIndex].Cells[0].Value);
            detay.MusteriAd = gridMusteriler.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtMusteri.Text = detay.MusteriAd.Trim();
        }
        SatisBLL bll = new SatisBLL();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (txtUrunSatisMiktari.Text.Trim() == "")
                MessageBox.Show("Lütfen satış miktarı giriniz");
            else
            {
                if (isUpdate)
                {
                    if (detaydto.SatisMiktar == Convert.ToInt32(txtUrunSatisMiktari.Text))
                        MessageBox.Show("Değişiklik yok");
                    else
                    {
                        int temp = detaydto.SatisMiktar + Convert.ToInt32(txtStok.Text);
                        if (temp <= Convert.ToInt32(txtUrunSatisMiktari.Text))
                            MessageBox.Show("Yeterli stok yok. Stok miktarından fazla ürün satılamaz");
                        else
                        {
                            detaydto.SatisMiktar = Convert.ToInt32(txtUrunSatisMiktari.Text);
                            detaydto.StokMiktar = Convert.ToInt32(txtStok.Text);
                            if (bll.Update(detaydto))
                            {
                                MessageBox.Show("Güncellendi");
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    if (detay.UrunID == 0)
                        MessageBox.Show("Ürün seçiniz");
                    else if (detay.MusteriID == 0)
                        MessageBox.Show("Müşteri seçiniz");
                    else if (detay.StokMiktar <= Convert.ToInt32(txtUrunSatisMiktari.Text))
                        MessageBox.Show("Yeterli stok yok. Stok miktarından fazla ürün satılamaz");
                    else
                    {
                        detay.SatisMiktar = Convert.ToInt32(txtUrunSatisMiktari.Text);
                        if (bll.Insert(detay))
                        {
                            MessageBox.Show("Eklendi");
                            txtUrunSatisMiktari.Clear();
                            dto = bll.Select();
                            gridUrunler.DataSource = dto.Urunler;
                        }
                    }
                }
            }
        }
    }
}
