namespace FloraGuardProje
{
    partial class HastalikTespitleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastalikTespitleri));
            resim = new PictureBox();
            pictureBoxgoruntu = new PictureBox();
            btnAnalizEt = new Button();
            buttoncanlianaliz = new Button();
            labelhastalikbilgi = new Label();
            labelbelirtiler = new Label();
            labelneden = new Label();
            labelcozum = new Label();
            txtBelirtiler = new TextBox();
            txtNedenler = new TextBox();
            txtCozumler = new TextBox();
            txtAnalizGirdi = new TextBox();
            buttonhastaliktani = new Button();
            openFileDialog1 = new OpenFileDialog();
            buttonkamerabaslat = new Button();
            textBoxhastalikAdi = new TextBox();
            labelhastalikAdi = new Label();
            buttonkapat = new Button();
            buttonmudahalegecis = new Button();
            labelguvenorani = new Label();
            textBoxguvenOrani = new TextBox();
            labelsorusor = new Label();
            ((System.ComponentModel.ISupportInitialize)resim).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxgoruntu).BeginInit();
            SuspendLayout();
            // 
            // resim
            // 
            resim.Image = (Image)resources.GetObject("resim.Image");
            resim.Location = new Point(1, 1);
            resim.Name = "resim";
            resim.Size = new Size(232, 196);
            resim.SizeMode = PictureBoxSizeMode.StretchImage;
            resim.TabIndex = 3;
            resim.TabStop = false;
            // 
            // pictureBoxgoruntu
            // 
            pictureBoxgoruntu.Location = new Point(1011, 145);
            pictureBoxgoruntu.Name = "pictureBoxgoruntu";
            pictureBoxgoruntu.Size = new Size(870, 657);
            pictureBoxgoruntu.TabIndex = 4;
            pictureBoxgoruntu.TabStop = false;
            pictureBoxgoruntu.Click += pictureBox1_Click;
            // 
            // btnAnalizEt
            // 
            btnAnalizEt.BackColor = Color.Transparent;
            btnAnalizEt.FlatStyle = FlatStyle.Popup;
            btnAnalizEt.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnAnalizEt.Location = new Point(766, 270);
            btnAnalizEt.Name = "btnAnalizEt";
            btnAnalizEt.Size = new Size(194, 55);
            btnAnalizEt.TabIndex = 6;
            btnAnalizEt.Text = "Analiz et ";
            btnAnalizEt.UseVisualStyleBackColor = false;
            btnAnalizEt.Click += btnAnalizEt_Click;
            // 
            // buttoncanlianaliz
            // 
            buttoncanlianaliz.BackColor = Color.Transparent;
            buttoncanlianaliz.FlatStyle = FlatStyle.Popup;
            buttoncanlianaliz.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            buttoncanlianaliz.Location = new Point(1660, 870);
            buttoncanlianaliz.Name = "buttoncanlianaliz";
            buttoncanlianaliz.Size = new Size(221, 55);
            buttoncanlianaliz.TabIndex = 7;
            buttoncanlianaliz.Text = "Canlı Analiz Et";
            buttoncanlianaliz.UseVisualStyleBackColor = false;
            buttoncanlianaliz.Click += button2_Click;
            // 
            // labelhastalikbilgi
            // 
            labelhastalikbilgi.AutoSize = true;
            labelhastalikbilgi.BackColor = Color.Transparent;
            labelhastalikbilgi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelhastalikbilgi.Location = new Point(1011, 99);
            labelhastalikbilgi.Name = "labelhastalikbilgi";
            labelhastalikbilgi.Size = new Size(180, 28);
            labelhastalikbilgi.TabIndex = 8;
            labelhastalikbilgi.Text = "BİTKİ ANALİZLERİ";
            // 
            // labelbelirtiler
            // 
            labelbelirtiler.AutoSize = true;
            labelbelirtiler.BackColor = Color.Transparent;
            labelbelirtiler.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelbelirtiler.Location = new Point(22, 362);
            labelbelirtiler.Name = "labelbelirtiler";
            labelbelirtiler.Size = new Size(134, 28);
            labelbelirtiler.TabIndex = 9;
            labelbelirtiler.Text = "BELİRTİLERİ :";
            // 
            // labelneden
            // 
            labelneden.AutoSize = true;
            labelneden.BackColor = Color.Transparent;
            labelneden.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelneden.Location = new Point(333, 362);
            labelneden.Name = "labelneden";
            labelneden.Size = new Size(132, 28);
            labelneden.TabIndex = 10;
            labelneden.Text = "NEDENLERİ :";
            // 
            // labelcozum
            // 
            labelcozum.AutoSize = true;
            labelcozum.BackColor = Color.Transparent;
            labelcozum.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelcozum.Location = new Point(661, 362);
            labelcozum.Name = "labelcozum";
            labelcozum.Size = new Size(135, 28);
            labelcozum.TabIndex = 11;
            labelcozum.Text = "ÇÖZÜMLERİ :";
            // 
            // txtBelirtiler
            // 
            txtBelirtiler.BorderStyle = BorderStyle.FixedSingle;
            txtBelirtiler.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            txtBelirtiler.Location = new Point(22, 393);
            txtBelirtiler.Multiline = true;
            txtBelirtiler.Name = "txtBelirtiler";
            txtBelirtiler.Size = new Size(274, 559);
            txtBelirtiler.TabIndex = 12;
            // 
            // txtNedenler
            // 
            txtNedenler.BorderStyle = BorderStyle.FixedSingle;
            txtNedenler.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            txtNedenler.Location = new Point(333, 393);
            txtNedenler.Multiline = true;
            txtNedenler.Name = "txtNedenler";
            txtNedenler.Size = new Size(293, 559);
            txtNedenler.TabIndex = 13;
            // 
            // txtCozumler
            // 
            txtCozumler.BorderStyle = BorderStyle.FixedSingle;
            txtCozumler.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCozumler.Location = new Point(661, 393);
            txtCozumler.Multiline = true;
            txtCozumler.Name = "txtCozumler";
            txtCozumler.Size = new Size(299, 559);
            txtCozumler.TabIndex = 14;
            // 
            // txtAnalizGirdi
            // 
            txtAnalizGirdi.BorderStyle = BorderStyle.FixedSingle;
            txtAnalizGirdi.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            txtAnalizGirdi.Location = new Point(22, 254);
            txtAnalizGirdi.Multiline = true;
            txtAnalizGirdi.Name = "txtAnalizGirdi";
            txtAnalizGirdi.Size = new Size(718, 86);
            txtAnalizGirdi.TabIndex = 15;
            // 
            // buttonhastaliktani
            // 
            buttonhastaliktani.BackColor = Color.Transparent;
            buttonhastaliktani.FlatStyle = FlatStyle.Popup;
            buttonhastaliktani.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            buttonhastaliktani.Location = new Point(1011, 870);
            buttonhastaliktani.Name = "buttonhastaliktani";
            buttonhastaliktani.Size = new Size(254, 55);
            buttonhastaliktani.TabIndex = 16;
            buttonhastaliktani.Text = "Hastalık Tanıma";
            buttonhastaliktani.UseVisualStyleBackColor = false;
            buttonhastaliktani.Click += buttonhastaliktani_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonkamerabaslat
            // 
            buttonkamerabaslat.BackColor = Color.Transparent;
            buttonkamerabaslat.FlatStyle = FlatStyle.Popup;
            buttonkamerabaslat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            buttonkamerabaslat.Location = new Point(1351, 870);
            buttonkamerabaslat.Name = "buttonkamerabaslat";
            buttonkamerabaslat.Size = new Size(229, 55);
            buttonkamerabaslat.TabIndex = 17;
            buttonkamerabaslat.Text = "Kamerayı Başlat";
            buttonkamerabaslat.UseVisualStyleBackColor = false;
            buttonkamerabaslat.Click += buttonkamerabaslat_Click;
            // 
            // textBoxhastalikAdi
            // 
            textBoxhastalikAdi.Enabled = false;
            textBoxhastalikAdi.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            textBoxhastalikAdi.Location = new Point(1173, 819);
            textBoxhastalikAdi.Multiline = true;
            textBoxhastalikAdi.Name = "textBoxhastalikAdi";
            textBoxhastalikAdi.Size = new Size(283, 45);
            textBoxhastalikAdi.TabIndex = 18;
            // 
            // labelhastalikAdi
            // 
            labelhastalikAdi.AutoSize = true;
            labelhastalikAdi.BackColor = Color.Transparent;
            labelhastalikAdi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelhastalikAdi.Location = new Point(1015, 836);
            labelhastalikAdi.Name = "labelhastalikAdi";
            labelhastalikAdi.Size = new Size(138, 28);
            labelhastalikAdi.TabIndex = 19;
            labelhastalikAdi.Text = "Hastalık Adı :";
            // 
            // buttonkapat
            // 
            buttonkapat.BackColor = Color.Transparent;
            buttonkapat.FlatStyle = FlatStyle.Popup;
            buttonkapat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            buttonkapat.Location = new Point(1819, 99);
            buttonkapat.Name = "buttonkapat";
            buttonkapat.Size = new Size(62, 40);
            buttonkapat.TabIndex = 20;
            buttonkapat.Text = "X";
            buttonkapat.UseVisualStyleBackColor = false;
            buttonkapat.Click += buttonkapat_Click;
            // 
            // buttonmudahalegecis
            // 
            buttonmudahalegecis.BackColor = Color.Transparent;
            buttonmudahalegecis.FlatStyle = FlatStyle.Popup;
            buttonmudahalegecis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            buttonmudahalegecis.Location = new Point(1597, 945);
            buttonmudahalegecis.Name = "buttonmudahalegecis";
            buttonmudahalegecis.Size = new Size(284, 40);
            buttonmudahalegecis.TabIndex = 21;
            buttonmudahalegecis.Text = "Müdahale Sayfasına Geçiş ➝";
            buttonmudahalegecis.UseVisualStyleBackColor = false;
            buttonmudahalegecis.Click += buttonmudahalegecis_Click;
            // 
            // labelguvenorani
            // 
            labelguvenorani.AutoSize = true;
            labelguvenorani.BackColor = Color.Transparent;
            labelguvenorani.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelguvenorani.Location = new Point(1545, 836);
            labelguvenorani.Name = "labelguvenorani";
            labelguvenorani.Size = new Size(141, 28);
            labelguvenorani.TabIndex = 23;
            labelguvenorani.Text = "Güven Oranı :";
            // 
            // textBoxguvenOrani
            // 
            textBoxguvenOrani.Enabled = false;
            textBoxguvenOrani.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            textBoxguvenOrani.Location = new Point(1692, 819);
            textBoxguvenOrani.Multiline = true;
            textBoxguvenOrani.Name = "textBoxguvenOrani";
            textBoxguvenOrani.Size = new Size(189, 45);
            textBoxguvenOrani.TabIndex = 22;
            // 
            // labelsorusor
            // 
            labelsorusor.AutoSize = true;
            labelsorusor.BackColor = Color.Transparent;
            labelsorusor.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelsorusor.Location = new Point(22, 228);
            labelsorusor.Name = "labelsorusor";
            labelsorusor.Size = new Size(355, 23);
            labelsorusor.TabIndex = 24;
            labelsorusor.Text = "Bitkinizin sorunu ile ilgili soru sorabilirsiniz";
            // 
            // HastalikTespitleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 1014);
            Controls.Add(labelsorusor);
            Controls.Add(labelguvenorani);
            Controls.Add(textBoxguvenOrani);
            Controls.Add(buttonmudahalegecis);
            Controls.Add(buttonkapat);
            Controls.Add(labelhastalikAdi);
            Controls.Add(textBoxhastalikAdi);
            Controls.Add(buttonkamerabaslat);
            Controls.Add(buttonhastaliktani);
            Controls.Add(txtAnalizGirdi);
            Controls.Add(txtCozumler);
            Controls.Add(txtNedenler);
            Controls.Add(txtBelirtiler);
            Controls.Add(labelcozum);
            Controls.Add(labelneden);
            Controls.Add(labelbelirtiler);
            Controls.Add(labelhastalikbilgi);
            Controls.Add(buttoncanlianaliz);
            Controls.Add(btnAnalizEt);
            Controls.Add(pictureBoxgoruntu);
            Controls.Add(resim);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HastalikTespitleri";
            Text = "HastalikTespitleri";
            WindowState = FormWindowState.Maximized;
            FormClosing += HastalikTespitleri_FormClosing;
            ((System.ComponentModel.ISupportInitialize)resim).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxgoruntu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox resim;
        private PictureBox pictureBoxgoruntu;
        private Label labelhastalikAdi;
        private Button btnAnalizEt;
        private Button buttoncanlianaliz;
        private Label labelhastalikbilgi;
        private Label labelbelirtiler;
        private Label labelneden;
        private Label labelcozum;
        private TextBox txtBelirtiler;
        private TextBox txtNedenler;
        private TextBox txtCozumler;
        private TextBox txtAnalizGirdi;
        private Button buttonhastaliktani;
        private OpenFileDialog openFileDialog1;
        private Button buttonkamerabaslat;
        private TextBox textBoxhastalikAdi;
        private Button buttonkapat;
        private Button buttonmudahalegecis;
        private Label labelguvenorani;
        private TextBox textBoxguvenOrani;
        private Label labelsorusor;
    }
}