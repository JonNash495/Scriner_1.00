using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class cointr
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<cointrDatum> data { get; set; }
    }

    public class cointrDatum
    {
        public string instId { get; set; }
        public string symbolName { get { return this.instId.RemoveSpecialCharacters(); } set { } }
        public string lastPx { get; set; }
        public string lastSz { get; set; }
        public string askPx { get; set; }
        public string askSz { get; set; }
        public string bidPx { get; set; }
        public string bidSz { get; set; }
        public string open24h { get; set; }
        public string high24h { get; set; }
        public string low24h { get; set; }
        public string vol24h { get; set; }
        public string volCcy24h { get; set; }
        public object uTime { get; set; }
    }
}