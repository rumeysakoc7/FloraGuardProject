using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class SensorVeri
    {

        public int SensorVeriID { get; set; }
        public int BitkiID { get; set; }
        public int ToprakNemi { get; set; }
        public DateTime OlcumZamani { get; set; } = DateTime.Now;
    }

}
