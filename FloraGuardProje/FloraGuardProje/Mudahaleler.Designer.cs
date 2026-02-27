namespace FloraGuardProje
{
    partial class Mudahaleler
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
            groupBox2 = new GroupBox();
            dgvMudahale = new DataGridView();
            buttonmudahaleEt = new Button();
            btnBaglan = new Button();
            labelCom = new Label();
            cmbComSec = new ComboBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMudahale).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(dgvMudahale);
            groupBox2.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox2.Location = new Point(53, 74);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1318, 587);
            groupBox2.TabIndex = 29;
            groupBox2.TabStop = false;
            groupBox2.Text = "Müdahaleleri Görüntüle";
            // 
            // dgvMudahale
            // 
            dgvMudahale.BackgroundColor = SystemColors.Control;
            dgvMudahale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMudahale.Location = new Point(36, 45);
            dgvMudahale.Name = "dgvMudahale";
            dgvMudahale.RowHeadersWidth = 51;
            dgvMudahale.Size = new Size(1239, 495);
            dgvMudahale.TabIndex = 25;
            // 
            // buttonmudahaleEt
            // 
            buttonmudahaleEt.BackColor = Color.Transparent;
            buttonmudahaleEt.FlatStyle = FlatStyle.Popup;
            buttonmudahaleEt.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonmudahaleEt.Location = new Point(653, 26);
            buttonmudahaleEt.Name = "buttonmudahaleEt";
            buttonmudahaleEt.Size = new Size(198, 46);
            buttonmudahaleEt.TabIndex = 27;
            buttonmudahaleEt.Text = "MÜDAHALE ET";
            buttonmudahaleEt.UseVisualStyleBackColor = false;
            buttonmudahaleEt.Click += buttonmudahaleEt_Click;
            // 
            // btnBaglan
            // 
            btnBaglan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBaglan.BackColor = Color.Transparent;
            btnBaglan.FlatStyle = FlatStyle.Flat;
            btnBaglan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBaglan.Location = new Point(332, 32);
            btnBaglan.Name = "btnBaglan";
            btnBaglan.Size = new Size(267, 36);
            btnBaglan.TabIndex = 43;
            btnBaglan.Text = "Bağlan";
            btnBaglan.UseVisualStyleBackColor = false;
            btnBaglan.Click += btnBaglan_Click;
            // 
            // labelCom
            // 
            labelCom.AutoSize = true;
            labelCom.BackColor = Color.Transparent;
            labelCom.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelCom.Location = new Point(56, 32);
            labelCom.Name = "labelCom";
            labelCom.Size = new Size(102, 28);
            labelCom.TabIndex = 42;
            labelCom.Text = "Com Seç :";
            // 
            // cmbComSec
            // 
            cmbComSec.FormattingEnabled = true;
            cmbComSec.Location = new Point(175, 36);
            cmbComSec.Name = "cmbComSec";
            cmbComSec.Size = new Size(151, 28);
            cmbComSec.TabIndex = 41;
            // 
            // Mudahaleler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(1402, 725);
            Controls.Add(btnBaglan);
            Controls.Add(labelCom);
            Controls.Add(cmbComSec);
            Controls.Add(buttonmudahaleEt);
            Controls.Add(groupBox2);
            Name = "Mudahaleler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mudahaleler";
            Load += Mudahaleler_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMudahale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Button buttonmudahaleEt;
        private Button btnBaglan;
        private Label labelCom;
        private ComboBox cmbComSec;
        private DataGridView dgvMudahale;
    }
}