using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class biconomyMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<biconomy>(json);
            foreach (var dto in dtos.ticker)
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
                                name = "biconomy",
                                exchangeData=new exchangeData
                                {
                                    lastPrice = dto.last != null ? dto.last.ToString().PowerConverter() : string.Empty,
                                    askPrice = dto.buy != null ? dto.buy.ToString().PowerConverter() : string.Empty,
                                    bidPrice = dto.sell != null ? dto.sell.ToString().PowerConverter() : string.Empty
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
                        name = "biconomy",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last != null ? dto.last.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.buy != null ? dto.buy.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.sell != null ? dto.sell.ToString().PowerConverter() : string.Empty
                        }
                    });
                }
            }
        }
    }
}