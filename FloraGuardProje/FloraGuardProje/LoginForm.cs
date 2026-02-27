using StokTakipSistemi;
using System.Data.SqlClient;
using Serilog;


namespace FloraGuardProje
{
    public partial class LoginForm : Form
    {
        private KullaniciIslemleri kullaniciRepo;

        public LoginForm()
        {
            InitializeComponent();
            kullaniciRepo = new KullaniciIslemleri();

        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtKullaniciSifre.Text;

            try
            {
                KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
                var kullanici = kullaniciIslemleri.GirisYap(kullaniciAdi, sifre);

                if (kullanici != null)
                {
                    KullaniciSession.AktifKullanici = kullanici;
                    Log.Information("Kullanıcı giriş yaptı: {KullaniciAdi}", kullanici.KullaniciAdi);

                    AnaMenuForm anamenu = new AnaMenuForm(kullanici);
                    anamenu.ShowDialog();


                    this.Hide();
                }
                else
                {
                    MessageBox.Show("? Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Başarısız giriş denemesi yapıldı. Kullanıcı adı: {KullaniciAdi}", kullaniciAdi);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Giriş sırasında hata oluştu. Kullanıcı: {KullaniciAdi}", kullaniciAdi);
                MessageBox.Show("Giriş sırasında bir hata oluştu:\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitOlForm kyt = new KayitOlForm(this); 
            kyt.Show();
            this.Hide();
        }

        private void lnkSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SıfreGuncellemeFrm sifreForm = new SıfreGuncellemeFrm(this); 
            sifreForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtKullaniciSifre.PasswordChar = '*';
            Log.Information("LoginForm yüklendi.");
        }

    }
}