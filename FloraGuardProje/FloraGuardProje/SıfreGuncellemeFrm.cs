using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace FloraGuardProje
{
    public partial class SıfreGuncellemeFrm : Form
    {
        private LoginForm _loginForm;
        public SıfreGuncellemeFrm(LoginForm loginForm)
        {
            InitializeComponent();
            this.FormClosing += SıfreGuncellemeFrm_FormClosing;
            _loginForm = loginForm;
        }

        private void BtnSifreGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                string mail = txtMail.Text;
                string yeniSifre = txtSifre.Text;

                if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(yeniSifre))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!");
                    return;
                }

                KullaniciIslemleri servis = new KullaniciIslemleri();
                if (servis.KullaniciVarMi(mail))
                {
                    servis.SifreGuncelle(mail, yeniSifre);
                    Log.Information("Kullanıcının şifresi güncellendi. Mail: {Email}", mail);
                    MessageBox.Show("Şifre güncellendi.");
                    this.Close();
                    LoginForm giris = new LoginForm();
                    giris.Show();
                }
                else
                {
                    Log.Warning("Şifre güncelleme başarısız. E-posta bulunamadı: {Email}", mail);
                    MessageBox.Show("Bu e-posta sistemde bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Şifre güncellenirken hata oluştu. E-posta: {Email}", txtMail.Text);
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void SıfreGuncellemeFrm_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void SıfreGuncellemeFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Show();
        }
    }
}
