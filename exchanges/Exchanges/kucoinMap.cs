using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class kucoinMap
    {
        public void Convert(exchangeResult result, string json)
        {
            kucoin dtos = JsonConvert.DeserializeObject<kucoin>(json);
            foreach (var dto in dtos.data.ticker)
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
                                    lastPrice=dto.last,
                                    askPrice = dto.buy, 
                                    bidPrice = dto.sell
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
                            lastPrice = dto.last,
                            askPrice = dto.buy,
                            bidPrice = dto.sell
                        }
                    });
                }
            }
        }
    }
}