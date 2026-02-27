namespace FloraGuardProje
{
    partial class KayitOlForm
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            BtnKayitOl = new Button();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtMail = new TextBox();
            txtSifre = new TextBox();
            cmbKullaniciTuru = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(97, 188);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 4;
            label2.Text = "Soyad           :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(102, 137);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 3;
            label1.Text = "Ad               :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(97, 365);
            label3.Name = "label3";
            label3.Size = new Size(145, 28);
            label3.TabIndex = 6;
            label3.Text = "Kullanıcı Şifre :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(97, 243);
            label4.Name = "label4";
            label4.Size = new Size(140, 28);
            label4.TabIndex = 5;
            label4.Text = "Kullanıcı Adı  :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(98, 429);
            label5.Name = "label5";
            label5.Size = new Size(144, 28);
            label5.TabIndex = 8;
            label5.Text = "Kullanıcı Türü :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(98, 307);
            label6.Name = "label6";
            label6.Size = new Size(139, 28);
            label6.TabIndex = 7;
            label6.Text = "Mail              :";
            // 
            // BtnKayitOl
            // 
            BtnKayitOl.BackColor = Color.Transparent;
            BtnKayitOl.FlatStyle = FlatStyle.Flat;
            BtnKayitOl.Location = new Point(251, 533);
            BtnKayitOl.Name = "BtnKayitOl";
            BtnKayitOl.Size = new Size(153, 42);
            BtnKayitOl.TabIndex = 10;
            BtnKayitOl.Text = "KAYIT OL";
            BtnKayitOl.UseVisualStyleBackColor = false;
            BtnKayitOl.Click += BtnKayitOl_Click;
            // 
            // txtAd
            // 
            txtAd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtAd.Location = new Point(251, 137);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(177, 30);
            txtAd.TabIndex = 11;
            // 
            // txtSoyad
            // 
            txtSoyad.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSoyad.Location = new Point(251, 192);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(177, 30);
            txtSoyad.TabIndex = 12;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtKullaniciAdi.Location = new Point(251, 247);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(177, 30);
            txtKullaniciAdi.TabIndex = 13;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtMail.Location = new Point(251, 307);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(177, 30);
            txtMail.TabIndex = 14;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSifre.Location = new Point(248, 369);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(177, 30);
            txtSifre.TabIndex = 15;
            // 
            // cmbKullaniciTuru
            // 
            cmbKullaniciTuru.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cmbKullaniciTuru.FormattingEnabled = true;
            cmbKullaniciTuru.Items.AddRange(new object[] { "Yönetici ", "Personel" });
            cmbKullaniciTuru.Location = new Point(248, 433);
            cmbKullaniciTuru.Name = "cmbKullaniciTuru";
            cmbKullaniciTuru.Size = new Size(177, 31);
            cmbKullaniciTuru.TabIndex = 16;
            // 
            // KayitOlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(569, 731);
            Controls.Add(cmbKullaniciTuru);
            Controls.Add(txtSifre);
            Controls.Add(txtMail);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(BtnKayitOl);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "KayitOlForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kayıt Ol";
            FormClosing += KayitOlForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button BtnKayitOl;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtKullaniciAdi;
        private TextBox txtMail;
        private TextBox txtSifre;
        private ComboBox cmbKullaniciTuru;
    }
}