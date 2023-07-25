using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bitgetMap
    {
        public void Convert(exchangeResult result, string json)
        {
            bitget dtos = JsonConvert.DeserializeObject<bitget>(json);
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
                                    lastPrice=dto.close,
                                    askPrice = dto.sellOne,
                                    bidPrice = dto.buyOne
                                }
                            }
                        }
                    };

                    result.currencies.Add(currency);
                }
                else
                {
                    var currency = result.currencies.First(x => x.pairName == dto.symbol);

                    currency.exchanges.Add(new exchange
                    {
                        name = dtos.GetType().Name,
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close,
                            askPrice = dto.sellOne,
                            bidPrice = dto.buyOne
                        }
                    });
                }
            }
        }
    }
}