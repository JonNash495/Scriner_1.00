using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class mexcMap
    {
        public void Convert(exchangeResult result, string json)
        {
            List<mexc> dtos = JsonConvert.DeserializeObject<List<mexc>>(json);
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
                                name = "mexc",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.lastPrice.ToString(),
                                    askPrice = dto.askPrice,
                                    bidPrice = dto.bidPrice.ToString()
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
                        name = "mexc",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.lastPrice.ToString(),
                            askPrice = dto.askPrice,
                            bidPrice = dto.bidPrice.ToString()
                        }
                    });
                }
            }
        }
    }
}
