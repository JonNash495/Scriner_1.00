using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class poloniexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            List<poloniex> dtos = JsonConvert.DeserializeObject<List<poloniex>>(json);
            foreach (var dto in dtos)
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
                                name = "poloniex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close.PowerConverter(),
                                    askPrice = dto.ask.PowerConverter(),
                                    bidPrice = dto.bid.PowerConverter()
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
                        name = "poloniex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close.PowerConverter(),
                            askPrice = dto.ask.PowerConverter(),
                            bidPrice = dto.bid.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}