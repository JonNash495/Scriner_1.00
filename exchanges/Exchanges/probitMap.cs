using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class probitMap
    {
        public void Convert(exchangeResult result, string json)
        {
            probit dtos = JsonConvert.DeserializeObject<probit>(json);
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
                                name = "probit",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last.PowerConverter(),
                                    askPrice = dto.low.PowerConverter(),
                                    bidPrice = dto.high.PowerConverter()
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
                        name = "probit",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last.PowerConverter(),
                            askPrice = dto.low.PowerConverter(),
                            bidPrice = dto.high.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}