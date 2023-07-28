using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class poloniex
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string open { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string close { get; set; }
        public string quantity { get; set; }
        public string amount { get; set; }
        public int tradeCount { get; set; }
        public object startTime { get; set; }
        public object closeTime { get; set; }
        public string displayName { get; set; }
        public string dailyChange { get; set; }
        public string bid { get; set; }
        public string bidQuantity { get; set; }
        public string ask { get; set; }
        public string askQuantity { get; set; }
        public object ts { get; set; }
        public string markPrice { get; set; }
    }
}