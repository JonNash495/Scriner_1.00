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
                                name = dtos.GetType().Name,
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last_price,
                                    askPrice = dto.best_ask,
                                    bidPrice = dto.best_bid
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
                        name = dtos.GetType().Name,
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last_price,
                            askPrice = dto.best_ask,
                            bidPrice = dto.best_bid
                        }
                    });
                }
            }
        }
    }
}
