using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bybitMap
    {
        public void Convert(exchangeResult result, string json)
        {
            bybit dtos = JsonConvert.DeserializeObject<bybit>(json);
            foreach (var dto in dtos.result)
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
                                    askPrice = dto.ask_price,
                                    bidPrice = dto.bid_price
                                }
                            }
                        }
                    };

                    result.currencies.Add(currency);
                }
                else
                {
                    var currency = result.currencies.First(x => x.pairName == dto.symbol);

                    currency.exchanges.Add(new exchange
                    {
                        name = dtos.GetType().Name,
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last_price,
                            askPrice = dto.ask_price,
                            bidPrice = dto.bid_price
                        }
                    });
                }
            }
        }        
    }
}
