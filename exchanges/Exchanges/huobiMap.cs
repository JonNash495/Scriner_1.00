using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class huobiMap
    {
        public void Convert(exchangeResult result, string json)
        {
            huobi dtos = JsonConvert.DeserializeObject<huobi>(json);
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
                                name =  "huobi",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close.ToString().PowerConverter(),
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
                        name = "huobi",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close.ToString().PowerConverter(),
                            askPrice = dto.ask.ToString().PowerConverter(),
                            bidPrice = dto.bid.ToString().PowerConverter()
                        }
                    });
                }
            }
        }
    }
}
