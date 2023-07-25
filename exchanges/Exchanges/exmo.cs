using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    public class exmo
    {
        public string buy_price { get; set; }
        public string sell_price { get; set; }
        public string last_trade { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string avg { get; set; }
        public string vol { get; set; }
        public string vol_curr { get; set; }
        public int updated { get; set; }
    }
}