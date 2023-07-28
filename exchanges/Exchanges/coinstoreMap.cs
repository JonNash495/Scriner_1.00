using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class coinstoreMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<coinstore>(json);
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
                                name = "coinstore",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close!=null?dto.close.ToString().PowerConverter():string.Empty,
                                    askPrice = dto.ask!=null?dto.ask.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.bid!=null?dto.bid.ToString().PowerConverter():string.Empty,
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
                        name = "coinstore",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close != null ? dto.close.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.ask != null ? dto.ask.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bid != null ? dto.bid.ToString().PowerConverter() : string.Empty,
                        }
                    });
                }
            }
        }
    }
}