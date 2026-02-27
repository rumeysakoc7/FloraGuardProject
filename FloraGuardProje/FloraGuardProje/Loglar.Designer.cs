namespace FloraGuardProje
{
    partial class Loglar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loglar));
            pictureBox1 = new PictureBox();
            dataGridViewloglar = new DataGridView();
            dateTimePickerbaslangic = new DateTimePicker();
            dateTimePickerbitis = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewloglar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 14);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 203);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewloglar
            // 
            dataGridViewloglar.BackgroundColor = SystemColors.Control;
            dataGridViewloglar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewloglar.Location = new Point(54, 337);
            dataGridViewloglar.Margin = new Padding(4);
            dataGridViewloglar.Name = "dataGridViewloglar";
            dataGridViewloglar.RowHeadersWidth = 51;
            dataGridViewloglar.Size = new Size(1431, 649);
            dataGridViewloglar.TabIndex = 25;
            // 
            // dateTimePickerbaslangic
            // 
            dateTimePickerbaslangic.Location = new Point(54, 271);
            dateTimePickerbaslangic.Margin = new Padding(4);
            dateTimePickerbaslangic.Name = "dateTimePickerbaslangic";
            dateTimePickerbaslangic.Size = new Size(322, 29);
            dateTimePickerbaslangic.TabIndex = 26;
            dateTimePickerbaslangic.ValueChanged += dateTimePickerbaslangic_ValueChanged;
            // 
            // dateTimePickerbitis
            // 
            dateTimePickerbitis.Location = new Point(414, 271);
            dateTimePickerbitis.Margin = new Padding(4);
            dateTimePickerbitis.Name = "dateTimePickerbitis";
            dateTimePickerbitis.Size = new Size(322, 29);
            dateTimePickerbitis.TabIndex = 27;
            dateTimePickerbitis.ValueChanged += dateTimePickerbitis_ValueChanged;
            // 
            // Loglar
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1924, 1055);
            Controls.Add(dateTimePickerbitis);
            Controls.Add(dateTimePickerbaslangic);
            Controls.Add(dataGridViewloglar);
            Controls.Add(pictureBox1);
            Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Loglar";
            Text = "Loglar";
            WindowState = FormWindowState.Maximized;
            Load += Loglar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewloglar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewloglar;
        private DateTimePicker dateTimePickerbaslangic;
        private DateTimePicker dateTimePickerbitis;
    }
}