using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bingx
    {
        public int code { get; set; }
        public string msg { get; set; }
        public bingxData data { get; set; }
    }

    public class bingxData
    {
        public List<bingxTicker> tickers { get; set; }
    }

    public class bingxTicker
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string dayVolume { get; set; }
        public string tradePrice { get; set; }
        public string indexPrice { get; set; }
        public string priceChange { get; set; }
        public string priceChangePercent { get; set; }
        public string lastPrice { get; set; }
        public string lastVolume { get; set; }
        public string highPrice { get; set; }
        public string lowPrice { get; set; }
        public string volume { get; set; }
        public string openPrice { get; set; }
        public string bidPrice { get; set; }
        public string askPrice { get; set; }
    }
}
