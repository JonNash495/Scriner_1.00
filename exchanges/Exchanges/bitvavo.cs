using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bitvavo
    {
        public string market { get; set; }
        public string symbolName { get { return this.market.RemoveSpecialCharacters(); } set { } }
        public object timestamp { get; set; }
        public string bid { get; set; }
        public string bidSize { get; set; }
        public string ask { get; set; }
        public string askSize { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string last { get; set; }
        public string volume { get; set; }
        public string volumeQuote { get; set; }
    }
}