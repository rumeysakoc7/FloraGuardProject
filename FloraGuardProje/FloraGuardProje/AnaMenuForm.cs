using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloraGuardProje
{
    public partial class AnaMenuForm : Form
    {
        private Kullanici aktifKullanici;

        public AnaMenuForm(Kullanici kullanici)
        {
            InitializeComponent();
            aktifKullanici = kullanici;
        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {

            if (KullaniciSession.AktifKullanici != null)
            {
                string yetki = KullaniciSession.AktifKullanici.KullaniciTipi;

                if (yetki == "Personel")
                {
                    btnKullaniciYonetim.Enabled = false;
                    btnLoglar.Enabled = false;
                }

            }
        }

        private void btnBitkiBilgi_Click(object sender, EventArgs e)
        {
            BitkiBilgileriForm BitkiBilgi = new BitkiBilgileriForm();
            BitkiBilgi.Show();

        }

        private void btnSensorVeri_Click(object sender, EventArgs e)
        {
            SensorVerileri SensorIslem = new SensorVerileri();
            SensorIslem.Show();

        }

        private void btnHastalikTespit_Click(object sender, EventArgs e)
        {
            HastalikTespitleri HastalikTsp = new HastalikTespitleri();
            HastalikTsp.Show();

        }

        private void btnKullaniciYonetim_Click(object sender, EventArgs e)
        {
            KullaniciYonetim KullaniciY = new KullaniciYonetim();
            KullaniciY.Show();

        }

        private void btnLoglar_Click(object sender, EventArgs e)
        {
            Loglar Log = new Loglar();
            Log.Show();
        }

        private void buttonRaporlar_Click(object sender, EventArgs e)
        {
            Raporlar Rapor = new Raporlar();
            Rapor.Show();
        }

        private void AnaMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}