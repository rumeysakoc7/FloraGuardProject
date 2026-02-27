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
    public partial class KayitOlForm : Form
    {
        private Form _loginForm;
        public KayitOlForm(Form loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            this.FormClosing += KayitOlForm_FormClosing;
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(txtAd.Text) ||
                    string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                    cmbKullaniciTuru.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }


                if (!txtMail.Text.Contains("@"))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi giriniz. '@' karakteri eksik.");
                    return;
                }

                var kullanici = new Kullanici
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Sifre = txtSifre.Text.Trim(),
                    Email = txtMail.Text.Trim(),
                    KullaniciTipi = cmbKullaniciTuru.SelectedItem.ToString(),
                    EklenmeTarihi = DateTime.Now,
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim()
                };


                KullaniciIslemleri islem = new KullaniciIslemleri();
                bool kayitBasarili = islem.KayitOl(kullanici);
                if (kayitBasarili)
                {
                    Log.Information("Yeni kullanıcı kaydı oluşturuldu: {KullaniciAdi} ({Email})", kullanici.KullaniciAdi, kullanici.Email);

                    MessageBox.Show("✅ Kayıt başarılı!");
                    _loginForm.Show(); 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("❌ Kayıt başarısız!");
                    Log.Warning("Kullanıcı kaydı başarısız: {KullaniciAdi}", kullanici.KullaniciAdi);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kayıt işlemi sırasında hata oluştu.");
                MessageBox.Show("Kayıt sırasında bir hata oluştu:\n" + ex.Message);
            }

        }

        private void KayitOlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_loginForm != null && !_loginForm.Visible)
                _loginForm.Show();
        }
    }
}
