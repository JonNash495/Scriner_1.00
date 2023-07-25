using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    [JsonArray]
    public class bitfinex
    {
        //https://docs.bitfinex.com/reference/rest-public-tickers
        public List<List<object>> MyArray { get; set; }
    }
}