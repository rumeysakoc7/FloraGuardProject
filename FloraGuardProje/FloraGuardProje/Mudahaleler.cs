using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Windows.Forms;
using Serilog;

namespace FloraGuardProje
{
    public partial class Mudahaleler : Form
    {
        public Mudahaleler()
        {
            InitializeComponent();
        }

        private void Mudahaleler_Load(object sender, EventArgs e)
        {
            try
            {
                string[] portlar = SerialPort.GetPortNames();
                cmbComSec.Items.Clear();
                cmbComSec.Items.AddRange(portlar);
                if (portlar.Length > 0)
                    cmbComSec.SelectedIndex = 0;

                dgvMudahale.AllowUserToAddRows = false;
                dgvMudahale.ReadOnly = true;
                dgvMudahale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMudahale.AutoGenerateColumns = true;

                MudahaleRepository repo = new MudahaleRepository();
                dgvMudahale.DataSource = repo.GetirTumMudahaleDetaylari();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Müdahaleler formu yüklenirken hata oluştu.");
                MessageBox.Show("Form yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComSec.SelectedItem == null)
                {
                    MessageBox.Show("🔌 Lütfen bağlantı noktasını (COM port) seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (SerialBaglanti.Port == null || !SerialBaglanti.Port.IsOpen)
                {
                    SerialBaglanti.Port = new SerialPort
                    {
                        PortName = cmbComSec.SelectedItem.ToString(),
                        BaudRate = 9600
                    };
                    SerialBaglanti.Port.Open();
                    MessageBox.Show("✅ Arduino bağlantısı kuruldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Bağlantı kurulurken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonmudahaleEt_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialBaglanti.Port != null && SerialBaglanti.Port.IsOpen)
                {
                    if (dgvMudahale.CurrentRow != null)
                    {
                        MudahaleDTO secilen = dgvMudahale.CurrentRow.DataBoundItem as MudahaleDTO;

                        if (secilen.MudahaleEdildi == true)
                        {
                            MessageBox.Show("⚠️ Bu tespit için zaten müdahale yapılmış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (secilen.HastalikAdi != null && secilen.HastalikAdi.Contains("Sağlıklı"))
                        {
                            MessageBox.Show("✅ Bu bitki sağlıklı, müdahale yapılmaz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        SerialBaglanti.Port.Write("3");
                        MessageBox.Show("🧪 Müdahale başlatıldı: İlaç + su karışımı gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MudahaleRepository repo = new MudahaleRepository();
                        repo.MudahaleEkle(secilen.BitkiID, secilen.TespitID, DateTime.Now);
                        repo.GuncelleMudahaleDurumu(secilen.TespitID);

                        dgvMudahale.DataSource = repo.GetirTumMudahaleDetaylari();
                    }
                }
                else
                {
                    MessageBox.Show("❌ Arduino bağlantısı yapılmamış. Lütfen önce bağlantıyı kurun.", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Müdahale komutu gönderilirken hata oluştu.");
                MessageBox.Show("⚠️ Komut gönderilirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMudahale_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMudahale.CurrentRow != null)
                {
                    var secilen = dgvMudahale.CurrentRow.DataBoundItem as MudahaleDTO;

                    if (secilen != null && secilen.MudahaleEdildi != true)
                    {
                        buttonmudahaleEt.Enabled = true;
                        return;
                    }
                }

                buttonmudahaleEt.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Satır seçimi sırasında hata oluştu.");
                MessageBox.Show("Satır seçimi sırasında bir hata oluştu:\n" + ex.Message);
                buttonmudahaleEt.Enabled = false;
            }
        }

    }
}
