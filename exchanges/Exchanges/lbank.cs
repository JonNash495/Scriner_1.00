using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class lbank
    {
        public string result { get; set; }
        public List<lbankDatum> data { get; set; }
        public int error_code { get; set; }
        public long ts { get; set; }
    }

    public class lbankTicker
    {
        public string high { get; set; }
        public string vol { get; set; }
        public string low { get; set; }
        public string change { get; set; }
        public string turnover { get; set; }
        public string latest { get; set; }
    }

    public class lbankDatum
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public lbankTicker ticker { get; set; }
        public object timestamp { get; set; }
    }
}