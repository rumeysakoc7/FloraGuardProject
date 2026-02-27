namespace FloraGuardProje
{
    partial class KullaniciYonetim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciYonetim));
            pictureBox1 = new PictureBox();
            dataGridViewKullanici = new DataGridView();
            cmbKullaniciTuru = new ComboBox();
            txtSifre = new TextBox();
            txtMail = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            BtnEkle = new Button();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGuncelle = new Button();
            btnSil = new Button();
            labelKullniciBilgi = new Label();
            panelKullanici = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullanici).BeginInit();
            panelKullanici.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewKullanici
            // 
            dataGridViewKullanici.BackgroundColor = SystemColors.Control;
            dataGridViewKullanici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKullanici.Location = new Point(78, 249);
            dataGridViewKullanici.Name = "dataGridViewKullanici";
            dataGridViewKullanici.RowHeadersWidth = 51;
            dataGridViewKullanici.Size = new Size(1186, 589);
            dataGridViewKullanici.TabIndex = 24;
            dataGridViewKullanici.CellClick += dataGridView1_CellClick;
            // 
            // cmbKullaniciTuru
            // 
            cmbKullaniciTuru.FormattingEnabled = true;
            cmbKullaniciTuru.Items.AddRange(new object[] { "Yönetici ", "Personel" });
            cmbKullaniciTuru.Location = new Point(242, 406);
            cmbKullaniciTuru.Name = "cmbKullaniciTuru";
            cmbKullaniciTuru.Size = new Size(199, 28);
            cmbKullaniciTuru.TabIndex = 37;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(242, 342);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(199, 27);
            txtSifre.TabIndex = 36;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(246, 280);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(199, 27);
            txtMail.TabIndex = 35;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(246, 220);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(199, 27);
            txtKullaniciAdi.TabIndex = 34;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(246, 165);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(199, 27);
            txtSoyad.TabIndex = 33;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(246, 110);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(199, 27);
            txtAd.TabIndex = 32;
            // 
            // BtnEkle
            // 
            BtnEkle.BackColor = Color.Transparent;
            BtnEkle.FlatStyle = FlatStyle.Flat;
            BtnEkle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnEkle.Location = new Point(14, 482);
            BtnEkle.Name = "BtnEkle";
            BtnEkle.Size = new Size(172, 42);
            BtnEkle.TabIndex = 31;
            BtnEkle.Text = "EKLE";
            BtnEkle.UseVisualStyleBackColor = false;
            BtnEkle.Click += BtnEkle_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(74, 402);
            label5.Name = "label5";
            label5.Size = new Size(144, 28);
            label5.TabIndex = 30;
            label5.Text = "Kullanıcı Türü :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(74, 280);
            label6.Name = "label6";
            label6.Size = new Size(139, 28);
            label6.TabIndex = 29;
            label6.Text = "Mail              :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(73, 338);
            label3.Name = "label3";
            label3.Size = new Size(145, 28);
            label3.TabIndex = 28;
            label3.Text = "Kullanıcı Şifre :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(73, 216);
            label4.Name = "label4";
            label4.Size = new Size(140, 28);
            label4.TabIndex = 27;
            label4.Text = "Kullanıcı Adı  :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(73, 161);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 26;
            label2.Text = "Soyad           :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(78, 110);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 25;
            label1.Text = "Ad               :";
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Transparent;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnGuncelle.Location = new Point(212, 482);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(172, 42);
            btnGuncelle.TabIndex = 38;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Transparent;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnSil.Location = new Point(409, 482);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(172, 42);
            btnSil.TabIndex = 40;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // labelKullniciBilgi
            // 
            labelKullniciBilgi.AutoSize = true;
            labelKullniciBilgi.BackColor = Color.Transparent;
            labelKullniciBilgi.FlatStyle = FlatStyle.Flat;
            labelKullniciBilgi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelKullniciBilgi.ForeColor = Color.Black;
            labelKullniciBilgi.Location = new Point(-1, 0);
            labelKullniciBilgi.Name = "labelKullniciBilgi";
            labelKullniciBilgi.Size = new Size(166, 28);
            labelKullniciBilgi.TabIndex = 41;
            labelKullniciBilgi.Text = "Kullanıcı Bilgileri ";
            // 
            // panelKullanici
            // 
            panelKullanici.BackColor = Color.Transparent;
            panelKullanici.BorderStyle = BorderStyle.FixedSingle;
            panelKullanici.Controls.Add(labelKullniciBilgi);
            panelKullanici.Controls.Add(btnSil);
            panelKullanici.Controls.Add(label1);
            panelKullanici.Controls.Add(btnGuncelle);
            panelKullanici.Controls.Add(label2);
            panelKullanici.Controls.Add(cmbKullaniciTuru);
            panelKullanici.Controls.Add(label4);
            panelKullanici.Controls.Add(txtSifre);
            panelKullanici.Controls.Add(label3);
            panelKullanici.Controls.Add(txtMail);
            panelKullanici.Controls.Add(label6);
            panelKullanici.Controls.Add(txtKullaniciAdi);
            panelKullanici.Controls.Add(label5);
            panelKullanici.Controls.Add(txtSoyad);
            panelKullanici.Controls.Add(BtnEkle);
            panelKullanici.Controls.Add(txtAd);
            panelKullanici.Location = new Point(1301, 261);
            panelKullanici.Name = "panelKullanici";
            panelKullanici.Size = new Size(591, 577);
            panelKullanici.TabIndex = 43;
            // 
            // KullaniciYonetim
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 947);
            Controls.Add(panelKullanici);
            Controls.Add(dataGridViewKullanici);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Name = "KullaniciYonetim";
            Text = "Kullanıcı Yönetim";
            WindowState = FormWindowState.Maximized;
            Load += KullaniciYonetim_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKullanici).EndInit();
            panelKullanici.ResumeLayout(false);
            panelKullanici.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewKullanici;
        private ComboBox cmbKullaniciTuru;
        private TextBox txtSifre;
        private TextBox txtMail;
        private TextBox txtKullaniciAdi;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Button BtnEkle;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private Button btnGuncelle;
        private Button btnSil;
        private Label labelKullniciBilgi;
        private Panel panelKullanici;
    }
}