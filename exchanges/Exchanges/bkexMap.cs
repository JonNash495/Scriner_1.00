using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bkexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            bkex dtos = JsonConvert.DeserializeObject<bkex>(json);
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
                                name = "bkex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.price.ToString("0." + new string('#', 339)),
                                    askPrice = string.Empty,
                                    bidPrice = string.Empty
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
                        name = "bkex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.price.ToString("0." + new string('#', 339)),
                            askPrice = string.Empty,
                            bidPrice = string.Empty
                        }
                    });
                }
            }
        }
    }
}