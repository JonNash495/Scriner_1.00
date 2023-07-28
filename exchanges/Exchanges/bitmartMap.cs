using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bitmartMap
    {
        public void Convert(exchangeResult result, string json)
        {
            bitmart dtos = JsonConvert.DeserializeObject<bitmart>(json);
            foreach (var dto in dtos.data.tickers)
            {
                if (!result.currencies.Any(x => x.pairName == dto.symbolName))
                {
                    var currency = new currency
                    {
                        pairName = dto.symbolName,
                        exchanges = new List<exchange>
                        {
                            new exchange
                            {
                                name = "bitmart",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last_price.PowerConverter(),
                                    askPrice = dto.best_ask.PowerConverter(),
                                    bidPrice = dto.best_bid.PowerConverter()
                                }
                            }
                        }
                    };

                    result.currencies.Add(currency);
                }
                else
                {
                    var currency = result.currencies.First(x => x.pairName == dto.symbolName);

                    currency.exchanges.Add(new exchange
                    {
                        name = "bitmart",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last_price.PowerConverter(),
                            askPrice = dto.best_ask.PowerConverter(),
                            bidPrice = dto.best_bid.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}
