using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class MudahaleDTO
    {
        public int TespitID { get; set; }
        public int BitkiID { get; set; }
        public string Tur { get; set; }
        public string Cesit { get; set; }
        public string HastalikAdi { get; set; }
        public string IlacTuru { get; set; }
        public string IlacDozaji { get; set; }
        public bool? BildirimGonderildi { get; set; }
        public bool? MudahaleEdildi { get; set; }

        public DateTime? MudahaleZamani { get; set; }

    }

}
