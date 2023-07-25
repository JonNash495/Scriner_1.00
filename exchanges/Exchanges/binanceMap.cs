using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class binanceMap
    {
        public void Convert(exchangeResult result, string json)
        {
            List<binance> binances = JsonConvert.DeserializeObject<List<binance>>(json);
            foreach (var binance in binances)
            {                
                if (!result.currencies.Any(x => x.pairName == binance.symbolName))
                {
                    var currency = new currency
                    {
                        pairName = binance.symbolName,
                        exchanges = new List<exchange>
                        {
                            new exchange
                            {
                                name = binance.GetType().Name,
                                exchangeData=new exchangeData
                                {
                                    lastPrice="-",                                    
                                    askPrice = binance.askPrice,
                                    bidPrice = binance.bidPrice
                                }
                            }
                        }
                    };

                    result.currencies.Add(currency);
                }
                else
                {
                    var currency = result.currencies.First(x => x.pairName == binance.symbol);

                    currency.exchanges.Add(new exchange
                    {
                        name = binance.GetType().Name,
                        exchangeData = new exchangeData
                        {
                            lastPrice = "-",
                            askPrice = binance.askPrice,
                            bidPrice = binance.bidPrice
                        }
                    });
                }
            }
        }        
    }
}
