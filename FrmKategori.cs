using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.BLL;
using StokTakip.DAL.DTO;


namespace StokTakip
{
    
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        KategoriBLL bll = new KategoriBLL();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKategoriAd.Text.Trim() == "")
                MessageBox.Show("Kategori Boş");
            else
            {
                KategoriDetayDTO detay = new KategoriDetayDTO();
                detay.KategoriAd = txtKategoriAd.Text;
                if (bll.Insert(detay))
                {
                    MessageBox.Show("Kategori EKlendi");
                    txtKategoriAd.Clear();
                }
            }

        }
    }
}
