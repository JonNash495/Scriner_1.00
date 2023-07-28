using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class garantex
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbolName { get { return this.name.RemoveSpecialCharacters(); } set { } }
        public string ask_unit { get; set; }
        public string bid_unit { get; set; }
        public string min_ask { get; set; }
        public string min_bid { get; set; }
        public string maker_fee { get; set; }
        public string taker_fee { get; set; }
    }
}
