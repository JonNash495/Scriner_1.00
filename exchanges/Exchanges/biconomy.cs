using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class biconomy
    {
        public List<biconomyTicker> ticker { get; set; }
        public string timestamp { get; set; }
    }

    public class biconomyTicker
    {
        public string buy { get; set; }
        public string change { get; set; }
        public string high { get; set; }
        public string last { get; set; }
        public string low { get; set; }
        public string sell { get; set; }
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string vol { get; set; }
    }
}
