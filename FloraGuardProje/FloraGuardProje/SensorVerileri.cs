using StokTakipSistemi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Serilog;

namespace FloraGuardProje
{
    public partial class SensorVerileri : Form
    {
        private bool bitkiSecildi = false;
        private DateTime sonKayitZamani = DateTime.MinValue;
        private readonly TimeSpan kayitAraligi = TimeSpan.FromSeconds(30);

        SerialPort serialPort1;

        public SensorVerileri()
        {
            InitializeComponent();
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string veri = SerialBaglanti.Port.ReadLine();

                this.Invoke(new MethodInvoker(delegate
                {
                    if (veri.StartsWith("NEM:"))
                    {
                        string deger = veri.Replace("NEM:", "").Trim();
                        txtNem.Text = deger;

                        if (int.TryParse(deger, out int nemSayisal))
                        {
                            double oran = (1024 - nemSayisal) * 100.0 / 1024.0;
                            labelnemyuzde.Text = "%" + oran.ToString("0.0");

                            SensorVerisiKaydetFromSerial(deger);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Veri okuma hatası: {Message}", ex.Message);
            }
        }

        private void SensorVerisiKaydetFromSerial(string gelenVeri)
        {
            if (!bitkiSecildi)
                return;

            if ((DateTime.Now - sonKayitZamani) < kayitAraligi)
                return;

            try
            {
                if (!int.TryParse(gelenVeri.Trim(), out int toprakNemi))
                    return;

                int seciliBitkiID = Convert.ToInt32(cmbBitkiSec.SelectedValue);

                SensorVeri veri = new SensorVeri
                {
                    BitkiID = seciliBitkiID,
                    ToprakNemi = toprakNemi,
                    OlcumZamani = DateTime.Now
                };

                new SensorIslemleri().Ekle(veri);
                sonKayitZamani = DateTime.Now;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Veri kaydederken hata oluştu: {Message}", ex.Message);
            }
        }

        private void SensorVerileri_Load(object sender, EventArgs e)
        {
            try
            {
                string[] portlar = SerialPort.GetPortNames();
                cmbComSec.Items.Clear();
                cmbComSec.Items.AddRange(portlar);

                if (portlar.Length > 0)
                    cmbComSec.SelectedIndex = 0;
                ComboBoxBitkileriYukle();
                dataGridViewsensor.AllowUserToAddRows = false;
                dataGridViewsensor.DataSource = null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Form yüklenirken hata: {Message}", ex.Message);
            }
        }

        private void ComboBoxBitkileriYukle()
        {
            try
            {
                BitkiRepository repo = new BitkiRepository();
                var bitkiler = repo.GetirBitkiSecenekleri();

                cmbBitkiSec.DisplayMember = "Cesit";
                cmbBitkiSec.ValueMember = "BitkiID";
                cmbBitkiSec.DataSource = bitkiler;
                cmbBitkiSec.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki listesi yüklenirken hata: {Message}", ex.Message);
            }
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComSec.SelectedItem == null)
                {
                    MessageBox.Show("🔌 Lütfen bir COM port seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (SerialBaglanti.Port == null || !SerialBaglanti.Port.IsOpen)
                {
                    SerialBaglanti.Port = new SerialPort();
                    SerialBaglanti.Port.PortName = cmbComSec.SelectedItem.ToString(); 
                    SerialBaglanti.Port.BaudRate = 9600;
                    SerialBaglanti.Port.DataReceived += SerialPort1_DataReceived;
                    SerialBaglanti.Port.Open();

                    MessageBox.Show("✅ Arduino'ya bağlanıldı.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Arduino bağlantısı kurulurken hata: {Message}", ex.Message);
                MessageBox.Show("❌ Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSulama_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialBaglanti.Port != null && SerialBaglanti.Port.IsOpen)
                {
                    SerialBaglanti.Port.Write("2");
                    MessageBox.Show("💧 Otomatik sulama başlatıldı.");
                }
                else
                {
                    MessageBox.Show("❌ Arduino bağlı değil.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sulama başlatılırken hata: {Message}", ex.Message);
            }
        }

        private void buttonpompaAc_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialBaglanti.Port != null && SerialBaglanti.Port.IsOpen)
                {
                    SerialBaglanti.Port.Write("1");
                    MessageBox.Show("🟢 Pompa manuel olarak açıldı.");
                }
                else
                {
                    MessageBox.Show("❌ Arduino bağlantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Pompa açılırken hata: {Message}", ex.Message);
            }
        }

        private void buttonpompakapa_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialBaglanti.Port != null && SerialBaglanti.Port.IsOpen)
                {
                    SerialBaglanti.Port.Write("0");
                    MessageBox.Show("🔴 Pompa kapatıldı. Otomatik sulama da durduruldu.");
                }
                else
                {
                    MessageBox.Show("❌ Arduino bağlantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Pompa kapatılırken hata: {Message}", ex.Message);
            }
        }

        private void SensorVerileriniDataGridaGetir(int bitkiID)
        {
            try
            {
                List<SensorVeri> veriler = new SensorIslemleri().GetirSensorVerileriByBitkiID(bitkiID);

                DataTable dt = new DataTable();
                dt.Columns.Add("SensorVeriID");
                dt.Columns.Add("BitkiID");
                dt.Columns.Add("ToprakNemi");
                dt.Columns.Add("OlcumZamani");

                foreach (var veri in veriler)
                {
                    dt.Rows.Add(veri.SensorVeriID, veri.BitkiID, veri.ToprakNemi, veri.OlcumZamani.ToString("dd.MM.yyyy HH:mm:ss"));
                }

                dataGridViewsensor.DataSource = dt;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Veriler DataGrid'e yüklenirken hata: {Message}", ex.Message);
            }
        }

        private void cmbBitkiSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bitkiSecildi = cmbBitkiSec.SelectedIndex != -1;
                if (bitkiSecildi)
                {
                    int seciliBitkiID = Convert.ToInt32(cmbBitkiSec.SelectedValue);
                    SensorVerileriniDataGridaGetir(seciliBitkiID);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitki seçimi sırasında hata: {Message}", ex.Message);
            }
        }

        private void VerileriGrafigeYukle()
        {
            try
            {
                if (cmbBitkiSec.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir bitki seçin.");
                    return;
                }

                int seciliBitkiID = Convert.ToInt32(cmbBitkiSec.SelectedValue);
                List<SensorVeri> veriler = new SensorIslemleri().GetirSensorVerileri(seciliBitkiID);

                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Zaman";
                chart1.ChartAreas[0].AxisY.Title = "Toprak Nemi";
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";

                var seri = chart1.Series.Add("Toprak Nemi");
                seri.ChartType = SeriesChartType.Line;
                seri.XValueType = ChartValueType.DateTime;

                foreach (var veri in veriler)
                {
                    seri.Points.AddXY(veri.OlcumZamani, veri.ToprakNemi);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Grafik verileri yüklenirken hata: {Message}", ex.Message);
            }
        }

        private void buttonGrafik_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBitkiSec.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir bitki seçin.");
                    return;
                }

                int seciliBitkiID = Convert.ToInt32(cmbBitkiSec.SelectedValue);
                DateTime baslangic = datetimePbaslangic.Value.Date;
                DateTime bitis = dateTimePbitis.Value.Date.AddDays(1).AddSeconds(-1);

                List<SensorVeri> veriler = new SensorIslemleri().GetirSensorVerileriTarihle(seciliBitkiID, baslangic, bitis);

                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Zaman";
                chart1.ChartAreas[0].AxisY.Title = "Toprak Nemi";
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM HH:mm";

                var seri = chart1.Series.Add("Toprak Nemi");
                seri.ChartType = SeriesChartType.Line;
                seri.XValueType = ChartValueType.DateTime;
                seri.BorderWidth = 4;

                foreach (var veri in veriler)
                {
                    seri.Points.AddXY(veri.OlcumZamani, veri.ToprakNemi);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Grafik filtreli veriler yüklenirken hata: {Message}", ex.Message);
            }
        }
    }
}

