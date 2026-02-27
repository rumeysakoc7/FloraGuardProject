namespace FloraGuardProje
{
    partial class SensorVerileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorVerileri));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pictureBox1 = new PictureBox();
            dataGridViewsensor = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dateTimePbitis = new DateTimePicker();
            datetimePbaslangic = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            txtNem = new TextBox();
            buttonSulama = new Button();
            labelnemyuzde = new Label();
            labelmanuelpompa = new Label();
            buttonpompaAc = new Button();
            buttonpompakapa = new Button();
            cmbComSec = new ComboBox();
            labelCom = new Label();
            btnBaglan = new Button();
            labelBitkiSec = new Label();
            cmbBitkiSec = new ComboBox();
            buttonGrafik = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsensor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewsensor
            // 
            dataGridViewsensor.BackgroundColor = SystemColors.Control;
            dataGridViewsensor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewsensor.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewsensor.Location = new Point(1246, 234);
            dataGridViewsensor.Name = "dataGridViewsensor";
            dataGridViewsensor.RowHeadersWidth = 51;
            dataGridViewsensor.Size = new Size(592, 595);
            dataGridViewsensor.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            label1.Location = new Point(57, 254);
            label1.Name = "label1";
            label1.Size = new Size(310, 34);
            label1.TabIndex = 4;
            label1.Text = "ANLIK SENSÖR VERİLERİ ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold);
            label2.Location = new Point(645, 234);
            label2.Name = "label2";
            label2.Size = new Size(290, 35);
            label2.TabIndex = 10;
            label2.Text = "GRAFİKSEL GÖSTERİM";
            // 
            // dateTimePbitis
            // 
            dateTimePbitis.Location = new Point(836, 815);
            dateTimePbitis.Name = "dateTimePbitis";
            dateTimePbitis.Size = new Size(250, 27);
            dateTimePbitis.TabIndex = 11;
            // 
            // datetimePbaslangic
            // 
            datetimePbaslangic.Location = new Point(494, 815);
            datetimePbaslangic.Name = "datetimePbaslangic";
            datetimePbaslangic.Size = new Size(250, 27);
            datetimePbaslangic.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(779, 815);
            label3.Name = "label3";
            label3.Size = new Size(20, 28);
            label3.TabIndex = 13;
            label3.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(33, 430);
            label4.Name = "label4";
            label4.Size = new Size(134, 28);
            label4.TabIndex = 15;
            label4.Text = "Toprak Nem :";
            // 
            // txtNem
            // 
            txtNem.Enabled = false;
            txtNem.Location = new Point(173, 430);
            txtNem.Name = "txtNem";
            txtNem.Size = new Size(147, 27);
            txtNem.TabIndex = 18;
            // 
            // buttonSulama
            // 
            buttonSulama.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSulama.BackColor = Color.Transparent;
            buttonSulama.FlatStyle = FlatStyle.Flat;
            buttonSulama.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSulama.Location = new Point(69, 536);
            buttonSulama.Name = "buttonSulama";
            buttonSulama.Size = new Size(251, 90);
            buttonSulama.TabIndex = 22;
            buttonSulama.Text = "Sulama Yap";
            buttonSulama.UseVisualStyleBackColor = false;
            buttonSulama.Click += buttonSulama_Click;
            // 
            // labelnemyuzde
            // 
            labelnemyuzde.AutoSize = true;
            labelnemyuzde.BackColor = Color.Transparent;
            labelnemyuzde.FlatStyle = FlatStyle.Flat;
            labelnemyuzde.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelnemyuzde.ForeColor = Color.Black;
            labelnemyuzde.Location = new Point(120, 480);
            labelnemyuzde.Name = "labelnemyuzde";
            labelnemyuzde.Size = new Size(122, 28);
            labelnemyuzde.TabIndex = 29;
            labelnemyuzde.Text = "Nem Oranı :";
            // 
            // labelmanuelpompa
            // 
            labelmanuelpompa.AutoSize = true;
            labelmanuelpompa.BackColor = Color.Transparent;
            labelmanuelpompa.FlatStyle = FlatStyle.Flat;
            labelmanuelpompa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelmanuelpompa.ForeColor = Color.Black;
            labelmanuelpompa.Location = new Point(120, 646);
            labelmanuelpompa.Name = "labelmanuelpompa";
            labelmanuelpompa.Size = new Size(155, 28);
            labelmanuelpompa.TabIndex = 32;
            labelmanuelpompa.Text = "Manuel Pompa ";
            // 
            // buttonpompaAc
            // 
            buttonpompaAc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonpompaAc.BackColor = Color.Transparent;
            buttonpompaAc.FlatStyle = FlatStyle.Flat;
            buttonpompaAc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonpompaAc.Location = new Point(78, 703);
            buttonpompaAc.Name = "buttonpompaAc";
            buttonpompaAc.Size = new Size(101, 53);
            buttonpompaAc.TabIndex = 34;
            buttonpompaAc.Text = "Aç";
            buttonpompaAc.UseVisualStyleBackColor = false;
            buttonpompaAc.Click += buttonpompaAc_Click;
            // 
            // buttonpompakapa
            // 
            buttonpompakapa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonpompakapa.BackColor = Color.Transparent;
            buttonpompakapa.FlatStyle = FlatStyle.Flat;
            buttonpompakapa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonpompakapa.Location = new Point(222, 703);
            buttonpompakapa.Name = "buttonpompakapa";
            buttonpompakapa.Size = new Size(98, 53);
            buttonpompakapa.TabIndex = 33;
            buttonpompakapa.Text = "Kapat";
            buttonpompakapa.UseVisualStyleBackColor = false;
            buttonpompakapa.Click += buttonpompakapa_Click;
            // 
            // cmbComSec
            // 
            cmbComSec.FormattingEnabled = true;
            cmbComSec.Location = new Point(173, 376);
            cmbComSec.Name = "cmbComSec";
            cmbComSec.Size = new Size(151, 28);
            cmbComSec.TabIndex = 38;
            // 
            // labelCom
            // 
            labelCom.AutoSize = true;
            labelCom.BackColor = Color.Transparent;
            labelCom.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelCom.Location = new Point(54, 372);
            labelCom.Name = "labelCom";
            labelCom.Size = new Size(102, 28);
            labelCom.TabIndex = 39;
            labelCom.Text = "Com Seç :";
            // 
            // btnBaglan
            // 
            btnBaglan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBaglan.BackColor = Color.Transparent;
            btnBaglan.FlatStyle = FlatStyle.Flat;
            btnBaglan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBaglan.Location = new Point(330, 372);
            btnBaglan.Name = "btnBaglan";
            btnBaglan.Size = new Size(79, 36);
            btnBaglan.TabIndex = 40;
            btnBaglan.Text = "Bağlan";
            btnBaglan.UseVisualStyleBackColor = false;
            btnBaglan.Click += btnBaglan_Click;
            // 
            // labelBitkiSec
            // 
            labelBitkiSec.AutoSize = true;
            labelBitkiSec.BackColor = Color.Transparent;
            labelBitkiSec.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelBitkiSec.Location = new Point(57, 321);
            labelBitkiSec.Name = "labelBitkiSec";
            labelBitkiSec.Size = new Size(100, 28);
            labelBitkiSec.TabIndex = 42;
            labelBitkiSec.Text = "Bitki Seç :";
            // 
            // cmbBitkiSec
            // 
            cmbBitkiSec.FormattingEnabled = true;
            cmbBitkiSec.Location = new Point(173, 321);
            cmbBitkiSec.Name = "cmbBitkiSec";
            cmbBitkiSec.Size = new Size(151, 28);
            cmbBitkiSec.TabIndex = 41;
            cmbBitkiSec.SelectedIndexChanged += cmbBitkiSec_SelectedIndexChanged;
            // 
            // buttonGrafik
            // 
            buttonGrafik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonGrafik.BackColor = Color.Transparent;
            buttonGrafik.FlatStyle = FlatStyle.Flat;
            buttonGrafik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonGrafik.Location = new Point(670, 861);
            buttonGrafik.Name = "buttonGrafik";
            buttonGrafik.Size = new Size(231, 53);
            buttonGrafik.TabIndex = 43;
            buttonGrafik.Text = "Grafik Verilerini Göster";
            buttonGrafik.UseVisualStyleBackColor = false;
            buttonGrafik.Click += buttonGrafik_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(443, 303);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(712, 484);
            chart1.TabIndex = 44;
            chart1.Text = "chart1";
            // 
            // SensorVerileri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 1055);
            Controls.Add(chart1);
            Controls.Add(buttonGrafik);
            Controls.Add(labelBitkiSec);
            Controls.Add(cmbBitkiSec);
            Controls.Add(btnBaglan);
            Controls.Add(labelCom);
            Controls.Add(cmbComSec);
            Controls.Add(buttonpompaAc);
            Controls.Add(buttonpompakapa);
            Controls.Add(labelmanuelpompa);
            Controls.Add(labelnemyuzde);
            Controls.Add(buttonSulama);
            Controls.Add(txtNem);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(datetimePbaslangic);
            Controls.Add(dateTimePbitis);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewsensor);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SensorVerileri";
            Text = "Sensör Verileri";
            WindowState = FormWindowState.Maximized;
            Load += SensorVerileri_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsensor).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewsensor;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePbitis;
        private DateTimePicker datetimePbaslangic;
        private Label label3;
        private Label label4;
        private TextBox txtNem;
        private Button buttonSulama;
        private Label labelnemyuzde;
        private Label labelmanuelpompa;
        private Button buttonpompaAc;
        private Button buttonpompakapa;
        private ComboBox cmbComSec;
        private Label labelCom;
        private Button btnBaglan;
        private Label labelBitkiSec;
        private ComboBox cmbBitkiSec;
        private Button buttonGrafik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;


    }


}