using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class lbankMap
    {
        public void Convert(exchangeResult result, string json)
        {
            lbank dtos = JsonConvert.DeserializeObject<lbank>(json);
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
                                name = dtos.GetType().Name,
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.ticker.latest??string.Empty,
                                    askPrice = dto.ticker.low.HasValue?dto.ticker.low.Value:0,
                                    bidPrice = dto.ticker.high??string.Empty
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
                        name = dtos.GetType().Name,
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.ticker.latest ?? string.Empty,
                            askPrice = dto.ticker.low.HasValue ? dto.ticker.low.Value : 0,
                            bidPrice = dto.ticker.high ?? string.Empty
                        }
                    });
                }
            }
        }
    }
}