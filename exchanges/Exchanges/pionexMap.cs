using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class pionexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<pionex>(json);
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
                                name = "pionex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close!=null?dto.close.ToString().PowerConverter():string.Empty,
                                    askPrice = dto.low!=null?dto.low.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.high!=null?dto.high.ToString().PowerConverter():string.Empty,
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
                        name = "pionex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close != null ? dto.close.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.low != null ? dto.low.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.high != null ? dto.high.ToString().PowerConverter() : string.Empty
                        }
                    });
                }
            }
        }
    }
}