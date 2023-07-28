using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class latoken
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string baseCurrency { get; set; }
        public string quoteCurrency { get; set; }
        public string volume24h { get; set; }
        public string volume7d { get; set; }
        public string change24h { get; set; }
        public string change7d { get; set; }
        public string amount24h { get; set; }
        public string amount7d { get; set; }
        public string lastPrice { get; set; }
        public string lastQuantity { get; set; }
        public string bestBid { get; set; }
        public string bestBidQuantity { get; set; }
        public string bestAsk { get; set; }
        public string bestAskQuantity { get; set; }
        public object updateTimestamp { get; set; }
    }
}