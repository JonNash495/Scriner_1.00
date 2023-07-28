using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bigone
    {
        public int code { get; set; }
        public List<bigoneDatum> data { get; set; }
    }

    public class bigoneAsk
    {
        public decimal price { get; set; }
        public int order_count { get; set; }
        public string quantity { get; set; }
    }

    public class bigoneBid
    {
        public string price { get; set; }
        public int order_count { get; set; }
        public string quantity { get; set; }
    }

    public class bigoneDatum
    {
        public string asset_pair_name { get; set; }
        public string symbolName { get { return this.asset_pair_name.RemoveSpecialCharacters(); } set { } }
        public bigoneBid bid { get; set; }
        public bigoneAsk ask { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
        public string daily_change { get; set; }
    }
}