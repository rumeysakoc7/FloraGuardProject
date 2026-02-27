namespace FloraGuardProje
{
    partial class Raporlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raporlar));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dataGridViewrapor = new DataGridView();
            dateTimePickerbitis = new DateTimePicker();
            dateTimePickerbaslangic = new DateTimePicker();
            btnolustur = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrapor).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 2);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 203);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewrapor
            // 
            dataGridViewrapor.BackgroundColor = SystemColors.Control;
            dataGridViewrapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewrapor.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewrapor.Location = new Point(345, 284);
            dataGridViewrapor.Margin = new Padding(4);
            dataGridViewrapor.Name = "dataGridViewrapor";
            dataGridViewrapor.RowHeadersWidth = 51;
            dataGridViewrapor.Size = new Size(1041, 652);
            dataGridViewrapor.TabIndex = 25;
            dataGridViewrapor.CellClick += dataGridViewrapor_CellClick;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.Location = new Point(840, 224);
            dateTimePickerbitis.Margin = new Padding(6, 5, 6, 5);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(441, 29);
            dateTimePickerbitis.TabIndex = 29;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.Location = new Point(345, 224);
            dateTimePickerbaslangic.Margin = new Padding(6, 5, 6, 5);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(441, 29);
            dateTimePickerbaslangic.TabIndex = 28;
            // 
            // btnolustur
            // 
            btnolustur.BackColor = Color.Transparent;
            btnolustur.FlatStyle = FlatStyle.Popup;
            btnolustur.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnolustur.Location = new Point(1314, 220);
            btnolustur.Name = "btnolustur";
            btnolustur.Size = new Size(212, 39);
            btnolustur.TabIndex = 30;
            btnolustur.Text = "RAPOR OLUŞTUR";
            btnolustur.UseVisualStyleBackColor = false;
            btnolustur.Click += btnolustur_Click;
            // 
            // Raporlar
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 1055);
            Controls.Add(btnolustur);
            Controls.Add(dateTimePickerbitis);
            Controls.Add(dateTimePickerbaslangic);
            Controls.Add(dataGridViewrapor);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Raporlar";
            Text = "Raporlar";
            WindowState = FormWindowState.Maximized;
            Load += Raporlar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrapor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewrapor;
        private DateTimePicker dateTimePickerbitis;
        private DateTimePicker dateTimePickerbaslangic;
        private Button btnolustur;
    }
}