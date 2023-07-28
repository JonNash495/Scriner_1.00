using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class azbit
    {
        public int timestamp { get; set; }
        public string currencyPairCode { get; set; }
        public string symbolName { get { return this.currencyPairCode.RemoveSpecialCharacters(); } set { } }
        public string price { get; set; }
        public double? price24hAgo { get; set; }
        public double priceChangePercentage24h { get; set; }
        public double volume24h { get; set; }
        public string bidPrice { get; set; }
        public string askPrice { get; set; }
        public double low24h { get; set; }
        public double high24h { get; set; }
    }
}