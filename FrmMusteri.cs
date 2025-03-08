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

namespace StokTakip
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MusteriDetayDTO detay = new MusteriDetayDTO();
        MusteriBLL bll = new MusteriBLL();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtMusteriAd.Text.Trim() == "")
                MessageBox.Show("Müşteri adı boş");
            else
            {
                detay.MusteriAd = txtMusteriAd.Text;
                if(bll.Insert(detay))
                {
                    MessageBox.Show("Müşteri Eklendi");
                    txtMusteriAd.Clear();
                }
            }
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {

        }
    }
}
