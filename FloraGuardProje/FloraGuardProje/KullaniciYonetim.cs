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
    public partial class KullaniciYonetim : Form
    {
        public KullaniciYonetim()
        {
            InitializeComponent();
        }

        private void KullanicilariListele()
        {
            try
            {
                KullaniciIslemleri repo = new KullaniciIslemleri();
                dataGridViewKullanici.DataSource = repo.KullanicilariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı listesi yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text) ||
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

                Kullanici yeni = new Kullanici
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Sifre = txtSifre.Text.Trim(),
                    Email = txtMail.Text.Trim(),
                    EklenmeTarihi = DateTime.Now,
                    KullaniciTipi = cmbKullaniciTuru.SelectedItem.ToString(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim()
                };

                bool basarili = new KullaniciIslemleri().KullaniciEkle(yeni);

                if (basarili)
                {
                    Log.Information("Yeni kullanıcı eklendi: {KullaniciAdi}, {Email}, {KullaniciTipi}",
                        yeni.KullaniciAdi, yeni.Email, yeni.KullaniciTipi);
                }
                else
                {
                    Log.Warning("Kullanıcı eklenemedi: {KullaniciAdi}, {Email}", yeni.KullaniciAdi, yeni.Email);
                }

                MessageBox.Show(basarili ? "Kullanıcı eklendi." : "Ekleme başarısız.");
                KullanicilariListele();
                Temizle();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı ekleme sırasında hata oluştu: {Hata}", ex.Message);
                MessageBox.Show("Ekleme işlemi sırasında hata oluştu:\n" + ex.Message);
            }
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKullanici.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.");
                    return;
                }

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

                int seciliID = Convert.ToInt32(dataGridViewKullanici.SelectedRows[0].Cells["KullaniciID"].Value);

                string eskiKullaniciAdi = dataGridViewKullanici.SelectedRows[0].Cells["KullaniciAdi"].Value.ToString();
                string eskiSifre = dataGridViewKullanici.SelectedRows[0].Cells["Sifre"].Value.ToString();
                string eskiEmail = dataGridViewKullanici.SelectedRows[0].Cells["Email"].Value.ToString();
                string eskiTip = dataGridViewKullanici.SelectedRows[0].Cells["KullaniciTipi"].Value.ToString();
                string eskiAd = dataGridViewKullanici.SelectedRows[0].Cells["Ad"].Value.ToString();
                string eskiSoyad = dataGridViewKullanici.SelectedRows[0].Cells["Soyad"].Value.ToString();

                string yeniKullaniciAdi = txtKullaniciAdi.Text.Trim();
                string yeniSifre = txtSifre.Text.Trim();
                string yeniEmail = txtMail.Text.Trim();
                string yeniTip = cmbKullaniciTuru.SelectedItem.ToString();
                string yeniAd = txtAd.Text.Trim();
                string yeniSoyad = txtSoyad.Text.Trim();

                if (eskiKullaniciAdi == yeniKullaniciAdi &&
                    eskiSifre == yeniSifre &&
                    eskiEmail == yeniEmail &&
                    eskiTip == yeniTip &&
                    eskiAd == yeniAd &&
                    eskiSoyad == yeniSoyad)
                {
                    Log.Warning("Kullanıcı güncellemesi yapılmadı çünkü hiçbir veri değişmedi. ID: {KullaniciID}", seciliID);
                    MessageBox.Show("Hiçbir değişiklik yapılmadı.");
                    return;
                }

                Kullanici guncel = new Kullanici
                {
                    KullaniciID = seciliID,
                    KullaniciAdi = yeniKullaniciAdi,
                    Sifre = yeniSifre,
                    Email = yeniEmail,
                    KullaniciTipi = yeniTip,
                    Ad = yeniAd,
                    Soyad = yeniSoyad
                };

                bool basarili = new KullaniciIslemleri().KullaniciGuncelle(guncel);

                if (basarili)
                {
                    Log.Information("Kullanıcı güncellendi. ID: {KullaniciID}, Adı: {KullaniciAdi}, Mail: {Email}",
                        guncel.KullaniciID, guncel.KullaniciAdi, guncel.Email);
                }
                else
                {
                    Log.Warning("Kullanıcı güncellenemedi. ID: {KullaniciID}, Adı: {KullaniciAdi}", guncel.KullaniciID, guncel.KullaniciAdi);
                }

                MessageBox.Show(basarili ? "Güncelleme başarılı." : "Güncelleme başarısız.");
                KullanicilariListele();
                Temizle();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı güncelleme hatası: {Hata}", ex.Message);
                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu:\n" + ex.Message);
            }
        }



        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKullanici.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir kullanıcı seçin.");
                    return;
                }

                int seciliID = Convert.ToInt32(dataGridViewKullanici.SelectedRows[0].Cells["KullaniciID"].Value);
                string seciliAd = dataGridViewKullanici.SelectedRows[0].Cells["Ad"].Value.ToString();
                string seciliSoyad = dataGridViewKullanici.SelectedRows[0].Cells["Soyad"].Value.ToString();

                DialogResult cevap = MessageBox.Show("Bu kullanıcıyı silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    bool basarili = new KullaniciIslemleri().KullaniciSil(seciliID);

                    if (basarili)
                    {
                        Log.Information("Kullanıcı silindi. ID: {KullaniciID}, Ad Soyad: {Ad} {Soyad}", seciliID, seciliAd, seciliSoyad);
                    }
                    else
                    {
                        Log.Warning("Kullanıcı silinemedi. ID: {KullaniciID}, Ad Soyad: {Ad} {Soyad}", seciliID, seciliAd, seciliSoyad);
                    }

                    MessageBox.Show(basarili ? "Kullanıcı silindi." : "Silme başarısız.");
                    KullanicilariListele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı silme işlemi sırasında hata oluştu.");
                MessageBox.Show("Silme işlemi sırasında hata oluştu:\n" + ex.Message);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewKullanici.Rows[e.RowIndex];

                    txtAd.Text = row.Cells["Ad"].Value?.ToString();
                    txtSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                    txtKullaniciAdi.Text= row.Cells["KullaniciAdi"].Value.ToString();
                    txtSifre.Text = row.Cells["Sifre"].Value.ToString();
                    txtMail.Text = row.Cells["Email"].Value.ToString();
                    string kullaniciTipi = row.Cells["KullaniciTipi"].Value.ToString();
                    cmbKullaniciTuru.SelectedItem = kullaniciTipi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satır seçimi sırasında hata oluştu:\n" + ex.Message);
            }
        }

        private void Temizle()
        {
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtMail.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            cmbKullaniciTuru.SelectedIndex = -1;
        }


        private void KullaniciYonetim_Load(object sender, EventArgs e)
        {
            KullanicilariListele();
            dataGridViewKullanici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKullanici.AllowUserToAddRows = false;
        }
    }
}
