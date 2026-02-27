using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class HastalikTespitics
    {
        public int BitkiID { get; set; }
        public int HastalikTipID { get; set; }
        public DateTime TespitZamani { get; set; }
        public float GuvenOrani { get; set; }
        public bool? BildirimGonderildi { get; set; } = false;
        public bool? MudahaleEdildi { get; set; } = false;

    }

}
