using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using exchanges.Extensions;
using System.Globalization;

namespace exchanges.Exchanges
{
    public class exmoMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var obj = JsonConvert.DeserializeObject(json);            
            var objects = JObject.Parse(json);
           
            foreach (var dto in objects)
            {
                string symbolName = dto.Key.ToString().RemoveSpecialCharacters().Substring(1); // валюты приходят вида i.e. tBTCUSD, tETHUSD https://docs.bitfinex.com/reference/rest-public-tickers
                
                if (!result.currencies.Any(x => x.pairName == symbolName))
                {
                    var currency = new currency
                    {
                        pairName = symbolName,
                        exchanges = new List<exchange>
                        {
                            new exchange
                            {
                                name = "exmo",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.Value["last_trade"].ToString().PowerConverter(),                                 
                                    askPrice = dto.Value["buy_price"].ToString().PowerConverter(),
                                    bidPrice = dto.Value["sell_price"].ToString().PowerConverter()
                                }
                            }
                        }
                    };

                    result.currencies.Add(currency);
                }
                else
                {
                    var currency = result.currencies.First(x => x.pairName == symbolName);

                    currency.exchanges.Add(new exchange
                    {
                        name = "exmo",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.Value["last_trade"].ToString().PowerConverter(),
                            askPrice = dto.Value["buy_price"].ToString().PowerConverter(),
                            bidPrice = dto.Value["sell_price"].ToString().PowerConverter()
                        }
                    });
                }
            }
        }
    }
}