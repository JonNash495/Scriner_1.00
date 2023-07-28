using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bingxMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<bingx>(json);
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
                                name = "bingx",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.lastPrice.ToString().PowerConverter(),
                                    askPrice = dto.askPrice.ToString().PowerConverter(),
                                    bidPrice = dto.bidPrice.ToString().PowerConverter()
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
                        name = "bingx",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.lastPrice.ToString().PowerConverter(),
                            askPrice = dto.askPrice.ToString().PowerConverter(),
                            bidPrice = dto.bidPrice.ToString().PowerConverter()
                        }
                    });
                }
            }
        }
    }
}