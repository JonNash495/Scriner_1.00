using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class binance
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string bidPrice { get; set; }
        public string bidQty { get; set; }
        public decimal askPrice { get; set; }
        public string askQty { get; set; }
        public exchange exchange { get { return this.ConvertToResult(); } }

        private exchange ConvertToResult()
        {
            return new exchange
            {
                name = this.GetType().Name,                
            };
        }
    }
}