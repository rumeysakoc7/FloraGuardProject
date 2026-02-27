using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class Bitki
    {
        public int BitkiID { get; set; }
        public string Tur { get; set; }
        public string Cesit { get; set; }
        public DateTime EkimTarihi { get; set; }
        public string Aciklama { get; set; }
        public int OptimumSicaklik { get; set; }
        public int OptimumNem { get; set; }
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }
    }
}
