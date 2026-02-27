namespace FloraGuardProje
{
    partial class BitkiBilgileriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitkiBilgileriForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            lblBitkiTur = new Label();
            cmbBitkiTuru = new ComboBox();
            labelBitkiAd = new Label();
            labelEkimT = new Label();
            lblOptSicak = new Label();
            labelOptNem = new Label();
            txtBitkiAdi = new TextBox();
            dtpEkimTarihi = new DateTimePicker();
            nUmSicaklik = new NumericUpDown();
            nUmNem = new NumericUpDown();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            groupBoxBitki = new GroupBox();
            btnGozat = new Button();
            dgvBitkiler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUmSicaklik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUmNem).BeginInit();
            groupBoxBitki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitkiler).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblBitkiTur
            // 
            lblBitkiTur.AutoSize = true;
            lblBitkiTur.BackColor = Color.Transparent;
            lblBitkiTur.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBitkiTur.Location = new Point(62, 54);
            lblBitkiTur.Name = "lblBitkiTur";
            lblBitkiTur.Size = new Size(109, 28);
            lblBitkiTur.TabIndex = 10;
            lblBitkiTur.Text = "Bitki Türü :";
            // 
            // cmbBitkiTuru
            // 
            cmbBitkiTuru.FormattingEnabled = true;
            cmbBitkiTuru.Items.AddRange(new object[] { "Sebze", "Meyve", "Çiçek" });
            cmbBitkiTuru.Location = new Point(177, 54);
            cmbBitkiTuru.Name = "cmbBitkiTuru";
            cmbBitkiTuru.Size = new Size(251, 28);
            cmbBitkiTuru.TabIndex = 11;
            // 
            // labelBitkiAd
            // 
            labelBitkiAd.AutoSize = true;
            labelBitkiAd.BackColor = Color.Transparent;
            labelBitkiAd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelBitkiAd.Location = new Point(62, 106);
            labelBitkiAd.Name = "labelBitkiAd";
            labelBitkiAd.Size = new Size(99, 28);
            labelBitkiAd.TabIndex = 12;
            labelBitkiAd.Text = "Bitki Adı :";
            // 
            // labelEkimT
            // 
            labelEkimT.AutoSize = true;
            labelEkimT.BackColor = Color.Transparent;
            labelEkimT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelEkimT.Location = new Point(62, 162);
            labelEkimT.Name = "labelEkimT";
            labelEkimT.Size = new Size(121, 28);
            labelEkimT.TabIndex = 13;
            labelEkimT.Text = "Ekim Tarihi :";
            // 
            // lblOptSicak
            // 
            lblOptSicak.AutoSize = true;
            lblOptSicak.BackColor = Color.Transparent;
            lblOptSicak.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblOptSicak.Location = new Point(62, 222);
            lblOptSicak.Name = "lblOptSicak";
            lblOptSicak.Size = new Size(183, 28);
            lblOptSicak.TabIndex = 14;
            lblOptSicak.Text = "Optimum Sıcaklık :";
            // 
            // labelOptNem
            // 
            labelOptNem.AutoSize = true;
            labelOptNem.BackColor = Color.Transparent;
            labelOptNem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelOptNem.Location = new Point(62, 286);
            labelOptNem.Name = "labelOptNem";
            labelOptNem.Size = new Size(160, 28);
            labelOptNem.TabIndex = 15;
            labelOptNem.Text = "Optimum Nem :";
            // 
            // txtBitkiAdi
            // 
            txtBitkiAdi.Location = new Point(177, 110);
            txtBitkiAdi.Name = "txtBitkiAdi";
            txtBitkiAdi.Size = new Size(251, 27);
            txtBitkiAdi.TabIndex = 17;
            // 
            // dtpEkimTarihi
            // 
            dtpEkimTarihi.Location = new Point(189, 164);
            dtpEkimTarihi.Name = "dtpEkimTarihi";
            dtpEkimTarihi.Size = new Size(239, 27);
            dtpEkimTarihi.TabIndex = 18;
            // 
            // nUmSicaklik
            // 
            nUmSicaklik.Location = new Point(247, 228);
            nUmSicaklik.Name = "nUmSicaklik";
            nUmSicaklik.Size = new Size(181, 27);
            nUmSicaklik.TabIndex = 19;
            // 
            // nUmNem
            // 
            nUmNem.Location = new Point(228, 291);
            nUmNem.Name = "nUmNem";
            nUmNem.Size = new Size(200, 27);
            nUmNem.TabIndex = 20;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Transparent;
            btnEkle.FlatStyle = FlatStyle.Popup;
            btnEkle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnEkle.Location = new Point(62, 368);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(312, 46);
            btnEkle.TabIndex = 22;
            btnEkle.Text = "EKLE ";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Transparent;
            btnSil.FlatStyle = FlatStyle.Popup;
            btnSil.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnSil.Location = new Point(62, 431);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(312, 46);
            btnSil.TabIndex = 23;
            btnSil.Text = "SİL ";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Transparent;
            btnGuncelle.FlatStyle = FlatStyle.Popup;
            btnGuncelle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnGuncelle.Location = new Point(62, 498);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(312, 46);
            btnGuncelle.TabIndex = 24;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // groupBoxBitki
            // 
            groupBoxBitki.BackColor = Color.Transparent;
            groupBoxBitki.Controls.Add(btnGuncelle);
            groupBoxBitki.Controls.Add(lblBitkiTur);
            groupBoxBitki.Controls.Add(btnSil);
            groupBoxBitki.Controls.Add(cmbBitkiTuru);
            groupBoxBitki.Controls.Add(btnEkle);
            groupBoxBitki.Controls.Add(labelBitkiAd);
            groupBoxBitki.Controls.Add(labelEkimT);
            groupBoxBitki.Controls.Add(nUmNem);
            groupBoxBitki.Controls.Add(lblOptSicak);
            groupBoxBitki.Controls.Add(nUmSicaklik);
            groupBoxBitki.Controls.Add(labelOptNem);
            groupBoxBitki.Controls.Add(dtpEkimTarihi);
            groupBoxBitki.Controls.Add(txtBitkiAdi);
            groupBoxBitki.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxBitki.Location = new Point(75, 264);
            groupBoxBitki.Name = "groupBoxBitki";
            groupBoxBitki.Size = new Size(458, 642);
            groupBoxBitki.TabIndex = 25;
            groupBoxBitki.TabStop = false;
            groupBoxBitki.Text = "Bitkilerim";
            // 
            // btnGozat
            // 
            btnGozat.BackColor = Color.Transparent;
            btnGozat.FlatStyle = FlatStyle.Popup;
            btnGozat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnGozat.Location = new Point(589, 222);
            btnGozat.Name = "btnGozat";
            btnGozat.Size = new Size(223, 46);
            btnGozat.TabIndex = 26;
            btnGozat.Text = "BİTKİLERİME GÖZ AT";
            btnGozat.UseVisualStyleBackColor = false;
            btnGozat.Click += btnGozat_Click;
            // 
            // dgvBitkiler
            // 
            dgvBitkiler.BackgroundColor = SystemColors.ButtonHighlight;
            dgvBitkiler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvBitkiler.DefaultCellStyle = dataGridViewCellStyle1;
            dgvBitkiler.Location = new Point(589, 274);
            dgvBitkiler.Name = "dgvBitkiler";
            dgvBitkiler.RowHeadersWidth = 51;
            dgvBitkiler.Size = new Size(1236, 632);
            dgvBitkiler.TabIndex = 27;
            dgvBitkiler.SelectionChanged += dgvBitkiler_SelectionChanged;
            // 
            // BitkiBilgileriForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 1052);
            Controls.Add(dgvBitkiler);
            Controls.Add(btnGozat);
            Controls.Add(groupBoxBitki);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BitkiBilgileriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitki Bilgileri";
            WindowState = FormWindowState.Maximized;
            Load += BitkiBilgileriForm_Load;
            Shown += BitkiBilgileriForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUmSicaklik).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUmNem).EndInit();
            groupBoxBitki.ResumeLayout(false);
            groupBoxBitki.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitkiler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblBitkiTur;
        private ComboBox cmbBitkiTuru;
        private Label labelBitkiAd;
        private Label labelEkimT;
        private Label lblOptSicak;
        private Label labelOptNem;
        private TextBox txtBitkiAdi;
        private DateTimePicker dtpEkimTarihi;
        private NumericUpDown nUmSicaklik;
        private NumericUpDown nUmNem;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGuncelle;
        private GroupBox groupBoxBitki;
        private Button btnGozat;
        private DataGridView dgvBitkiler;
    }
}