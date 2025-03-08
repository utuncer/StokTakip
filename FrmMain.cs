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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        // this.hide() ile menü sayfamızı gizliyoruz
        // frm.ShowDialog() ile yeni formu açıyoruz
        // this.Visible = true açtığımız form sayfasını kapattığımızda menü formunu gösterir
        /*
         BLL (Business Logic Layer) (İş Mantığı Katmanı)
                  Veri işleme, doğrulama ve uygulama mantığının bulunduğu katmandır.

        DAL (Data Access Layer) (Veri Erişim Katmanı)
                  Veritabanı işlemlerinin yapıldığı katmandır.

        DAO (Data Access Object) (Veri Erişim Nesnesi)
                  DAL içinde kullanılan, veritabanı işlemlerini yöneten nesnedir.

        DTO (Data Transfer Object) (Veri Transfer Nesnesi)
                  Katmanlar arasında veri taşıyan, genellikle sadece veri içeren nesnelerdir.
         */
        private void btnSilinenler_Click(object sender, EventArgs e)
        {
            FrmSilinenler frm = new FrmSilinenler();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            FrmUrunListesi frm = new FrmUrunListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            FrmSatisListesi frm = new FrmSatisListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriListesi frm = new FrmKategoriListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteriListesi frm = new FrmMusteriListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnStokEkleme_Click(object sender, EventArgs e)
        {
            FrmStokEkleme frm = new FrmStokEkleme();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Formu çarpıya basıp kapatmaya çalıştığında komple uygulamayı kapatmış olursun
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
