using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bkex
    {
        public int code { get; set; }
        public List<bkexDatum> data { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    public class bkexDatum
    {
        public double price { get; set; }
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
    }
}