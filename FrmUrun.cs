﻿using StokTakip.BLL;
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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
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

        public UrunDTO dto = new UrunDTO();
        public UrunDetayDTO detaydto = new UrunDetayDTO();
        public bool isUpdate = false;
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = dto.Kategoriler;
            cmbKategori.DisplayMember = "KategoriAd";
            cmbKategori.ValueMember = "ID";
            cmbKategori.SelectedIndex = -1;
            if (isUpdate)
            {
                txtUrunAd.Text = detaydto.UrunAd;
                txtUrunFiyat.Text = detaydto.Fiyat.ToString();
                cmbKategori.SelectedValue = detaydto.KategoriID;
            }
        }
        UrunBLL bll = new UrunBLL();

        UrunDetayDTO detay = new UrunDetayDTO();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUrunAd.Text.Trim() == "")
                MessageBox.Show("Ürün Adı Boş");
            else if (txtUrunFiyat.Text.Trim() == "")
                MessageBox.Show("Fiyat Alanı Boş");
            else if (cmbKategori.SelectedIndex == -1)
                MessageBox.Show("Kategori Seçiniz");
            else
            {
                if (isUpdate)
                {
                    if (detaydto.UrunAd == txtUrunAd.Text && detaydto.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue) && detaydto.Fiyat == Convert.ToInt32(txtUrunFiyat.Text))
                        MessageBox.Show("Değişiklik yok");
                    else
                    {
                        detaydto.UrunAd= txtUrunAd.Text;
                        detaydto.KategoriID = Convert.ToInt32(cmbKategori.SelectedValue);
                        detaydto.Fiyat = Convert.ToInt32(txtUrunFiyat.Text);
                        if(bll.Update(detaydto))
                        {
                            MessageBox.Show("Güncellendi");
                            this.Close();
                        }
                    }
                }
                else
                {
                    detay.UrunAd = txtUrunAd.Text;
                    detay.Fiyat = Convert.ToInt32(txtUrunFiyat.Text);
                    detay.KategoriID = Convert.ToInt32(cmbKategori.SelectedValue);
                    if (bll.Insert(detay))
                    {
                        MessageBox.Show("Ürün Eklendi");
                        txtUrunAd.Clear();
                        txtUrunFiyat.Clear();
                        cmbKategori.SelectedIndex = -1;
                    }
                }
            }
        }
    }
}
