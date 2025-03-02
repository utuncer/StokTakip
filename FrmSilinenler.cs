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
    public partial class FrmSilinenler : Form
    {
        public FrmSilinenler()
        {
            InitializeComponent();
        }

        private void FrmSilinenler_Load(object sender, EventArgs e)
        {
            cmbTablolar.Items.Add("Kategoriler");
            cmbTablolar.Items.Add("Müşteriler");
            cmbTablolar.Items.Add("Satış");
            cmbTablolar.Items.Add("Ürünler");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
