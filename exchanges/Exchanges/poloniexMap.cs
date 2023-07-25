using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class poloniexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            List<poloniex> dtos = JsonConvert.DeserializeObject<List<poloniex>>(json);
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
                                name = "poloniex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close,
                                    askPrice = dto.ask,
                                    bidPrice = dto.bid
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
                        name = "poloniex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close,
                            askPrice = dto.ask,
                            bidPrice = dto.bid
                        }
                    });
                }
            }
        }
    }
}