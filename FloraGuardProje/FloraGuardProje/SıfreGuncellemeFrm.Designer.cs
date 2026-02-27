namespace FloraGuardProje
{
    partial class SıfreGuncellemeFrm
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
            BtnSifreGuncelle = new Button();
            txtSifre = new TextBox();
            txtMail = new TextBox();
            label6 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // BtnSifreGuncelle
            // 
            BtnSifreGuncelle.BackColor = Color.Transparent;
            BtnSifreGuncelle.FlatStyle = FlatStyle.Flat;
            BtnSifreGuncelle.Font = new Font("Segoe UI Semibold", 9F);
            BtnSifreGuncelle.Location = new Point(224, 254);
            BtnSifreGuncelle.Name = "BtnSifreGuncelle";
            BtnSifreGuncelle.Size = new Size(168, 47);
            BtnSifreGuncelle.TabIndex = 28;
            BtnSifreGuncelle.Text = "ŞİFREMİ GÜNCELLE";
            BtnSifreGuncelle.UseVisualStyleBackColor = false;
            BtnSifreGuncelle.Click += BtnSifreGuncelle_Click;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSifre.Location = new Point(224, 177);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(241, 30);
            txtSifre.TabIndex = 27;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtMail.Location = new Point(224, 115);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(241, 30);
            txtMail.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(70, 114);
            label6.Name = "label6";
            label6.Size = new Size(139, 28);
            label6.TabIndex = 25;
            label6.Text = "Mail              :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(64, 173);
            label3.Name = "label3";
            label3.Size = new Size(145, 28);
            label3.TabIndex = 24;
            label3.Text = "Kullanıcı Şifre :";
            // 
            // SıfreGuncellemeFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fLORAGUARD__1_;
            ClientSize = new Size(585, 379);
            Controls.Add(BtnSifreGuncelle);
            Controls.Add(txtSifre);
            Controls.Add(txtMail);
            Controls.Add(label6);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "SıfreGuncellemeFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şifre Güncelleme";
            FormClosing += SıfreGuncellemeFrm_FormClosing;
            Load += SıfreGuncellemeFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSifreGuncelle;
        private TextBox txtSifre;
        private TextBox txtMail;
        private Label label6;
        private Label label3;
    }
}