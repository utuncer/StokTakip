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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StokTakip
{
    public partial class FrmSilinenler : Form
    {
        public FrmSilinenler()
        {
            InitializeComponent();
        }
        SatisDTO dto = new SatisDTO();
        SatisBLL satisbll = new SatisBLL();
        private void FrmSilinenler_Load(object sender, EventArgs e)
        {
            cmbTablolar.Items.Add("Kategoriler");
            cmbTablolar.Items.Add("Müşteriler");
            cmbTablolar.Items.Add("Satış");
            cmbTablolar.Items.Add("Ürünler");
            dto = satisbll.Select(true);
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
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTablolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTablolar.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.Kategoriler;
                dataGridView1.Columns[0].Visible = false; //Tablonun ID kısmı
                dataGridView1.Columns[1].HeaderText = "Kategori Adı";
            }
            else if (cmbTablolar.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.Musteriler;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
            }
            else if (cmbTablolar.SelectedIndex == 2)
            {
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
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
            else
            {
                dataGridView1.DataSource = dto.Urunler;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Ürün Adı";
                dataGridView1.Columns[2].HeaderText = "Kategori";
                dataGridView1.Columns[3].HeaderText = "Stok";
                dataGridView1.Columns[4].HeaderText = "Ürün Fiyatı";
            }
        }
        UrunDetayDTO urun = new UrunDetayDTO();
        MusteriDetayDTO musteri = new MusteriDetayDTO();
        KategoriDetayDTO kategori = new KategoriDetayDTO();
        SatisDetayDTO satis = new SatisDetayDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbTablolar.SelectedIndex == 0)
            {
                kategori.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                kategori.KategoriAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbTablolar.SelectedIndex == 1)
            {
                musteri.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                musteri.MusteriAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbTablolar.SelectedIndex == 2)
            {
                satis.UrunAd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                satis.MusteriAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                satis.Fiyat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                satis.SatisID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString().Trim());
                satis.UrunID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().Trim());
                satis.MusteriID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Trim());
                satis.SatisMiktar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Trim());
            }
            else if (cmbTablolar.SelectedIndex == 3)
            {
                urun.UrunAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                urun.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                urun.Fiyat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                urun.KategoriID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                urun.isKategoriDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                // MessageBox.Show("Kategori Silinmiş mi? " + urun.isKategoriDeleted.ToString()); // Test için
                // MessageBox.Show("Cells[7] Değeri: " + dataGridView1.Rows[e.RowIndex].Cells[7]);
            }
        }
        UrunBLL urunbll = new UrunBLL();
        MusteriBLL musteribll = new MusteriBLL();
        KategoriBLL kategoribll = new KategoriBLL();
        private void btnGeriGetir_Click(object sender, EventArgs e)
        {
            if (cmbTablolar.SelectedIndex == 0)
            {
                if (kategoribll.GetBack(kategori))
                {
                    MessageBox.Show("Geri getirildi");
                    satisbll = new SatisBLL();
                    dto = satisbll.Select(true);
                    dataGridView1.DataSource = dto.Kategoriler;
                }
            }
            if (cmbTablolar.SelectedIndex == 1)
            {
                if (musteribll.GetBack(musteri))
                {
                    MessageBox.Show("Geri getirildi");
                    satisbll = new SatisBLL();
                    dto = satisbll.Select(true);
                    dataGridView1.DataSource = dto.Musteriler;
                }
            }
            if (cmbTablolar.SelectedIndex == 2)
            {
                if (satisbll.GetBack(satis))
                {
                    if (!satis.udeleted && !satis.kdeleted && !satis.mdeleted)
                    {
                        MessageBox.Show("Silinemez");
                    }
                    else
                    {
                        MessageBox.Show("Geri getirildi");
                        satisbll = new SatisBLL();
                        dto = satisbll.Select(true);
                        dataGridView1.DataSource = dto.Satislar;
                    }
                }
            }

            if (cmbTablolar.SelectedIndex == 3)
            {
                if (urunbll.GetBack(urun))
                {
                    if (urun.isKategoriDeleted)
                        MessageBox.Show("Kategori silindiğinden dolayı bu ürün geri getirilemez");
                    else
                    {
                        MessageBox.Show("Geri getirildi");
                        satisbll = new SatisBLL();
                        dto = satisbll.Select(true);
                        dataGridView1.DataSource = dto.Urunler;
                    }
                }
            }
        }
    }
}
