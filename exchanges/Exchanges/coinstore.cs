using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class coinstore
    {
        public List<coinstoreDatum> data { get; set; }
        public int code { get; set; }
    }

    public class coinstoreDatum
    {
        public string channel { get; set; }
        public string bidSize { get; set; }
        public string askSize { get; set; }
        public int count { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
        public string amount { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public int instrumentId { get; set; }
    }
}