using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class pionex
    {
        public bool result { get; set; }
        public pionexData data { get; set; }
        public long timestamp { get; set; }
    }

    public class pionexData
    {
        public List<pionexTicker> tickers { get; set; }
    }

    public class pionexTicker
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public object time { get; set; }
        public string open { get; set; }
        public string close { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string volume { get; set; }
        public string amount { get; set; }
        public int count { get; set; }
    }
}