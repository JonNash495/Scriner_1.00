using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bittrex
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string lastTradeRate { get; set; }
        public string bidRate { get; set; }
        public decimal askRate { get; set; }
        public DateTime updatedAt { get; set; }
    }
}