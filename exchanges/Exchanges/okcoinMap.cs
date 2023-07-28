using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class okcoinMap
    {
        public void Convert(exchangeResult result, string json)
        {
            okcoin dtos = JsonConvert.DeserializeObject<okcoin>(json);
            foreach (var dto in dtos.data)
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
                                name = "okcoin",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last.PowerConverter(),
                                    askPrice = dto.askPx.PowerConverter(),
                                    bidPrice = dto.bidPx.PowerConverter()
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
                        name = "okcoin",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last.PowerConverter(),
                            askPrice = dto.askPx.PowerConverter(),
                            bidPrice = dto.bidPx.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}