using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string KullaniciTipi { get; set; }
    }

}
