using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class cointrMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<cointr>(json);
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
                                name = "cointr",
                                exchangeData=new exchangeData
                                {
                                    lastPrice = dto.lastPx != null ? dto.lastPx.ToString().PowerConverter() : string.Empty,
                                    askPrice = dto.askPx != null ? dto.askPx.ToString().PowerConverter() : string.Empty,
                                    bidPrice = dto.bidPx != null ? dto.bidPx.ToString().PowerConverter() : string.Empty
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
                        name = "cointr",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.lastPx != null ? dto.lastPx.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.askPx != null ? dto.askPx.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bidPx != null ? dto.bidPx.ToString().PowerConverter() : string.Empty
                        }
                    });
                }
            }
        }
    }
}
