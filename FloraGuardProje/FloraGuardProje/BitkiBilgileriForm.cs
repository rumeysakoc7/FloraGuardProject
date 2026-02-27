using Serilog; 
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FloraGuardProje
{
    public partial class BitkiBilgileriForm : Form
    {
        public BitkiBilgileriForm()
        {
            InitializeComponent();
        }

        private void BitkiBilgileriForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvBitkiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BitkileriYenile();
                dgvBitkiler.ClearSelection();
                dgvBitkiler.AllowUserToAddRows = false;
                Log.Information("BitkiBilgileriForm yüklendi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BitkiBilgileriForm yüklenirken hata oluştu.");
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBitkiTuru.Text) ||
                string.IsNullOrWhiteSpace(txtBitkiAdi.Text) ||
                nUmNem.Value <= 0 || nUmSicaklik.Value <= 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve değerleri sıfırdan büyük girin.");
                return;
            }

            try
            {
                Bitki bitki = new Bitki
                {
                    Tur = cmbBitkiTuru.Text,
                    Cesit = txtBitkiAdi.Text,
                    EkimTarihi = dtpEkimTarihi.Value,
                    Aciklama = "",
                    OptimumNem = (int)nUmNem.Value,
                    OptimumSicaklik = (int)nUmSicaklik.Value
                };

                new BitkiRepository().Ekle(bitki);
                Log.Information("Yeni bitki eklendi: {@Bitki}", bitki);

                MessageBox.Show("✅ Bitki başarıyla eklendi.");
                BitkileriYenile();
                Temizle();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki eklenirken hata oluştu.");
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvBitkiler.CurrentRow == null || dgvBitkiler.CurrentRow.Index < 0)
            {
                MessageBox.Show("Lütfen silinecek bitkiyi seçin.");
                return;
            }

            try
            {
                int bitkiID = Convert.ToInt32(dgvBitkiler.CurrentRow.Cells["BitkiID"].Value);
                new BitkiRepository().Sil(bitkiID);
                Log.Information("Bitki silindi. BitkiID: {BitkiID}", bitkiID);

                MessageBox.Show("✅ Bitki başarıyla silindi.");
                BitkileriYenile();
                Temizle();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki silme sırasında hata oluştu.");
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvBitkiler.CurrentRow == null || dgvBitkiler.CurrentRow.Index < 0)
            {
                MessageBox.Show("Lütfen güncellenecek bitkiyi seçin.");
                return;
            }

            try
            {
                int bitkiID = Convert.ToInt32(dgvBitkiler.CurrentRow.Cells["BitkiID"].Value);

                Bitki bitki = new Bitki
                {
                    BitkiID = bitkiID,
                    Tur = cmbBitkiTuru.Text,
                    Cesit = txtBitkiAdi.Text,
                    EkimTarihi = dtpEkimTarihi.Value,
                    Aciklama = "",
                    OptimumNem = (int)nUmNem.Value,
                    OptimumSicaklik = (int)nUmSicaklik.Value
                };

                BitkiRepository repo = new BitkiRepository();
                bool guncellendi = repo.Guncelle(bitki);

                if (guncellendi)
                {
                    Log.Information("Bitki güncellendi: {@Bitki}", bitki);
                    MessageBox.Show("✅ Bitki başarıyla güncellendi.");
                    BitkileriYenile();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki güncellenirken hata oluştu.");
                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu: " + ex.Message);
            }
        }

        private void dgvBitkiler_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBitkiler.SelectedRows.Count == 0) return;
                if (dgvBitkiler.CurrentRow != null && dgvBitkiler.CurrentRow.Index >= 0)
                {
                    cmbBitkiTuru.Text = dgvBitkiler.CurrentRow.Cells["Tur"].Value.ToString();
                    txtBitkiAdi.Text = dgvBitkiler.CurrentRow.Cells["Cesit"].Value.ToString();
                    dtpEkimTarihi.Value = Convert.ToDateTime(dgvBitkiler.CurrentRow.Cells["EkimTarihi"].Value);
                    nUmNem.Value = Convert.ToInt32(dgvBitkiler.CurrentRow.Cells["OptimumNem"].Value);
                    nUmSicaklik.Value = Convert.ToInt32(dgvBitkiler.CurrentRow.Cells["OptimumSicaklik"].Value);
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Satır seçimi sırasında hata oluştu.");
            }
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            try
            {
                BitkileriYenile();
                Temizle();
                Log.Information("Bitki listesi güncellendi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitkileri yenilerken hata oluştu.");
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void BitkiBilgileriForm_Shown(object sender, EventArgs e)
        {
            try
            {
                dgvBitkiler.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Form gösteriminde seçim temizlenirken hata oluştu.");
            }
        }

        private void BitkileriYenile()
        {
            try
            {
                BitkiRepository repo = new BitkiRepository();
                dgvBitkiler.DataSource = repo.GetirTumBitkiler(); 
                if (dgvBitkiler.Columns.Contains("Aciklama"))
                {
                    dgvBitkiler.Columns["Aciklama"].Visible = false;
                }

                dgvBitkiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBitkiler.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki listeleme sırasında hata oluştu.");
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }


        private void Temizle()
        {
            cmbBitkiTuru.SelectedIndex = -1;
            txtBitkiAdi.Clear();
            dtpEkimTarihi.Value = DateTime.Today;
            nUmNem.Value = 0;
            nUmSicaklik.Value = 0;
        }
    }
}