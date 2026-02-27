namespace FloraGuardProje
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtKullaniciAdi = new TextBox();
            txtKullaniciSifre = new TextBox();
            lnkKayitOl = new LinkLabel();
            lnkSifremiUnuttum = new LinkLabel();
            btnGirisYap = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(113, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 365);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(133, 441);
            label1.Name = "label1";
            label1.Size = new Size(134, 28);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(133, 510);
            label2.Name = "label2";
            label2.Size = new Size(145, 28);
            label2.TabIndex = 2;
            label2.Text = "Kullanıcı Şifre :";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtKullaniciAdi.Location = new Point(300, 445);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(188, 30);
            txtKullaniciAdi.TabIndex = 3;
            // 
            // txtKullaniciSifre
            // 
            txtKullaniciSifre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtKullaniciSifre.Location = new Point(300, 510);
            txtKullaniciSifre.Name = "txtKullaniciSifre";
            txtKullaniciSifre.Size = new Size(188, 30);
            txtKullaniciSifre.TabIndex = 4;
            // 
            // lnkKayitOl
            // 
            lnkKayitOl.AutoSize = true;
            lnkKayitOl.BackColor = Color.Transparent;
            lnkKayitOl.LinkColor = Color.Gray;
            lnkKayitOl.Location = new Point(296, 570);
            lnkKayitOl.Name = "lnkKayitOl";
            lnkKayitOl.Size = new Size(65, 20);
            lnkKayitOl.TabIndex = 5;
            lnkKayitOl.TabStop = true;
            lnkKayitOl.Text = "Kayıt Ol ";
            lnkKayitOl.LinkClicked += lnkKayitOl_LinkClicked;
            // 
            // lnkSifremiUnuttum
            // 
            lnkSifremiUnuttum.AutoSize = true;
            lnkSifremiUnuttum.BackColor = Color.Transparent;
            lnkSifremiUnuttum.LinkColor = Color.Gray;
            lnkSifremiUnuttum.Location = new Point(367, 570);
            lnkSifremiUnuttum.Name = "lnkSifremiUnuttum";
            lnkSifremiUnuttum.Size = new Size(121, 20);
            lnkSifremiUnuttum.TabIndex = 6;
            lnkSifremiUnuttum.TabStop = true;
            lnkSifremiUnuttum.Text = "Şifremi Unuttum ";
            lnkSifremiUnuttum.LinkClicked += lnkSifremiUnuttum_LinkClicked;
            // 
            // btnGirisYap
            // 
            btnGirisYap.BackColor = Color.Transparent;
            btnGirisYap.FlatStyle = FlatStyle.Popup;
            btnGirisYap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnGirisYap.Location = new Point(233, 642);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(162, 46);
            btnGirisYap.TabIndex = 7;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = false;
            btnGirisYap.Click += btnGirisYap_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(650, 791);
            Controls.Add(btnGirisYap);
            Controls.Add(lnkSifremiUnuttum);
            Controls.Add(lnkKayitOl);
            Controls.Add(txtKullaniciSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giriş Sayfası";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtKullaniciAdi;
        private TextBox txtKullaniciSifre;
        private LinkLabel lnkKayitOl;
        private LinkLabel lnkSifremiUnuttum;
        private Button btnGirisYap;
    }
}