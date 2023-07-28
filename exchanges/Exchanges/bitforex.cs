using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bitforexCurrency
    {
        public List<bitforexDatum> data { get; set; }
        public bool success { get; set; }
        public long time { get; set; }
    }

    public class bitforexDatum
    {
        public int amountPrecision { get; set; }
        public double minOrderAmount { get; set; }
        public int pricePrecision { get; set; }
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
    }

    public class bitforex
    {
        public bitforexData data { get; set; }
        public bool success { get; set; }
        public long time { get; set; }
    }

    public class bitforexData
    {
        public double buy { get; set; }
        public long date { get; set; }
        public double high { get; set; }
        public double last { get; set; }
        public double low { get; set; }
        public double sell { get; set; }
        public double vol { get; set; }
    }
}