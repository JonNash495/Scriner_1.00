using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class huobi
    {
        public List<Datum> data { get; set; }
        public string status { get; set; }
        public long ts { get; set; }
    }

    public class Datum
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double amount { get; set; }
        public double vol { get; set; }
        public int count { get; set; }
        public double bid { get; set; }
        public double bidSize { get; set; }
        public decimal ask { get; set; }
        public double askSize { get; set; }
    }

}
