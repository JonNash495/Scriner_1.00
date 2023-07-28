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
                                name = "kucoin",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last.PowerConverter(),
                                    askPrice = dto.buy.PowerConverter(), 
                                    bidPrice = dto.sell.PowerConverter()
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
                        name = "kucoin",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last.PowerConverter(),
                            askPrice = dto.buy.PowerConverter(),
                            bidPrice = dto.sell.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}