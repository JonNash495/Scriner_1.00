using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class tapbit
    {
        public int code { get; set; }
        public object message { get; set; }
        public List<tapbitDatum> data { get; set; }
    }

    public class tapbitDatum
    {
        public string trade_pair_name { get; set; }
        public string symbolName { get { return this.trade_pair_name.RemoveSpecialCharacters(); } set { } }
        public string last_price { get; set; }
        public string highest_bid { get; set; }
        public string lowest_ask { get; set; }
        public string highest_price_24h { get; set; }
        public string lowest_price_24h { get; set; }
        public string volume24h { get; set; }
        public string chg24h { get; set; }
        public string chg0h { get; set; }
        public string amount24h { get; set; }
    }
}