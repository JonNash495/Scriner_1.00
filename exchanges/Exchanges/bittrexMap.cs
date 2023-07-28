using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bittrexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            List<bittrex> dtos = JsonConvert.DeserializeObject<List<bittrex>>(json);
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
                                name = "bittrex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.lastTradeRate.PowerConverter(),
                                    askPrice = dto.askRate.PowerConverter(),
                                    bidPrice = dto.bidRate.PowerConverter()
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
                        name = "bittrex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.lastTradeRate.PowerConverter(),
                            askPrice = dto.askRate.PowerConverter(),
                            bidPrice = dto.bidRate.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}