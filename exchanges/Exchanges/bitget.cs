using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bitget
    {
        public string code { get; set; }
        public List<bitgetData> data { get; set; }
        public string msg { get; set; }
        public string requestTime { get; set; }
    }

    public class bitgetData
    {
        public string askSz { get; set; }
        public string baseVol { get; set; }
        public string bidSz { get; set; }
        public string buyOne { get; set; }
        public string change { get; set; }
        public string changeUtc { get; set; }
        public string close { get; set; }
        public string high24h { get; set; }
        public string low24h { get; set; }
        public string openUtc0 { get; set; }
        public string quoteVol { get; set; }
        public string sellOne { get; set; }
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string ts { get; set; }
        public string usdtVol { get; set; }
    }
}
