using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bitsoMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<bitso>(json);
            foreach (var dto in dtos.payload)
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
                                name = "bitso",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last.ToString().PowerConverter(),
                                    askPrice = dto.ask.ToString().PowerConverter(),
                                    bidPrice = dto.bid.ToString().PowerConverter()
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
                        name = "bitso",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last.ToString().PowerConverter(),
                            askPrice = dto.ask.ToString().PowerConverter(),
                            bidPrice = dto.bid.ToString().PowerConverter()
                        }
                    });
                }
            }
        }
    }
}
