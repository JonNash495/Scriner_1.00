using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    internal class azbitMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<List<azbit>>(json);
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
                                name = "lbank",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.price!=null?dto.price.ToString().PowerConverter():string.Empty,
                                    askPrice = dto.askPrice!=null?dto.askPrice.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.bidPrice!=null?dto.bidPrice.ToString().PowerConverter():string.Empty,
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
                        name = "lbank",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.price != null ? dto.price.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.askPrice != null ? dto.askPrice.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bidPrice != null ? dto.bidPrice.ToString().PowerConverter() : string.Empty
                        }
                    });
                }
            }
        }
    }
}