using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class probit
    {
        public List<probitDatum> data { get; set; }
    }

    public class probitDatum
    {
        public string last { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string change { get; set; }
        public string base_volume { get; set; }
        public string quote_volume { get; set; }
        public string market_id { get; set; }
        public string symbolName { get { return this.market_id.RemoveSpecialCharacters(); } set { } }
        public DateTime? time { get; set; }
    }
}