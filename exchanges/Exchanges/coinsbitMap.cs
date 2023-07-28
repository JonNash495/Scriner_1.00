using exchanges.Extensions;
using Newtonsoft.Json.Linq;

namespace exchanges.Exchanges
{
    public class coinsbitMap
    {
        public void Convert(exchangeResult result, string json)
        {
            JObject jsonObject = JObject.Parse(json);
            IEnumerable<JToken> jsTokens = jsonObject.SelectTokens("$...ticker");

            var dtos = jsTokens.Select(x => x.ToObject<coinsbit>());

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
                                name = "coinsbit",
                                exchangeData=new exchangeData
                                {
                                    lastPrice = dto.last.ToString().PowerConverter(),
                                    askPrice = dto.ask.PowerConverter(),
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
                        name = "coinsbit",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last.ToString().PowerConverter(),
                            askPrice = dto.ask.PowerConverter(),
                            bidPrice = dto.bid.ToString().PowerConverter()
                        }
                    });
                }
            }
        }
    }
}