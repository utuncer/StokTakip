namespace StokTakip
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnUrun = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.btnStokEkleme = new System.Windows.Forms.Button();
            this.btnSilinenler = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusteri
            // 
            this.btnMusteri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteri.Image = global::StokTakip.Properties.Resources.musteri;
            this.btnMusteri.Location = new System.Drawing.Point(68, 27);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(197, 204);
            this.btnMusteri.TabIndex = 0;
            this.btnMusteri.Text = "Müşteriler";
            this.btnMusteri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.BackColor = System.Drawing.Color.Lime;
            this.btnUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrun.Image = global::StokTakip.Properties.Resources.urun;
            this.btnUrun.Location = new System.Drawing.Point(287, 27);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(197, 204);
            this.btnUrun.TabIndex = 0;
            this.btnUrun.Text = "Ürünler";
            this.btnUrun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUrun.UseVisualStyleBackColor = false;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.BackColor = System.Drawing.Color.Yellow;
            this.btnSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.Image = global::StokTakip.Properties.Resources.satis;
            this.btnSatis.Location = new System.Drawing.Point(506, 27);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(197, 204);
            this.btnSatis.TabIndex = 0;
            this.btnSatis.Text = "Satış";
            this.btnSatis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSatis.UseVisualStyleBackColor = false;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // btnStokEkleme
            // 
            this.btnStokEkleme.BackColor = System.Drawing.Color.Silver;
            this.btnStokEkleme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokEkleme.Image = global::StokTakip.Properties.Resources.stok;
            this.btnStokEkleme.Location = new System.Drawing.Point(68, 255);
            this.btnStokEkleme.Name = "btnStokEkleme";
            this.btnStokEkleme.Size = new System.Drawing.Size(197, 204);
            this.btnStokEkleme.TabIndex = 0;
            this.btnStokEkleme.Text = "Stok Ekleme";
            this.btnStokEkleme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStokEkleme.UseVisualStyleBackColor = false;
            this.btnStokEkleme.Click += new System.EventHandler(this.btnStokEkleme_Click);
            // 
            // btnSilinenler
            // 
            this.btnSilinenler.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnSilinenler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSilinenler.Image = global::StokTakip.Properties.Resources.Silinenler;
            this.btnSilinenler.Location = new System.Drawing.Point(287, 255);
            this.btnSilinenler.Name = "btnSilinenler";
            this.btnSilinenler.Size = new System.Drawing.Size(197, 204);
            this.btnSilinenler.TabIndex = 0;
            this.btnSilinenler.Text = "Silinenler";
            this.btnSilinenler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSilinenler.UseVisualStyleBackColor = false;
            this.btnSilinenler.Click += new System.EventHandler(this.btnSilinenler_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.BackColor = System.Drawing.Color.Cyan;
            this.btnKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategori.Image = global::StokTakip.Properties.Resources.kategori;
            this.btnKategori.Location = new System.Drawing.Point(506, 255);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(197, 204);
            this.btnKategori.TabIndex = 0;
            this.btnKategori.Text = "Kategoriler";
            this.btnKategori.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKategori.UseVisualStyleBackColor = false;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Tomato;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Image = global::StokTakip.Properties.Resources.cikis;
            this.btnCikis.Location = new System.Drawing.Point(287, 483);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(197, 204);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 722);
            this.Controls.Add(this.btnSatis);
            this.Controls.Add(this.btnUrun);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSilinenler);
            this.Controls.Add(this.btnStokEkleme);
            this.Controls.Add(this.btnMusteri);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.Button btnStokEkleme;
        private System.Windows.Forms.Button btnSilinenler;
        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnCikis;
    }
}