using exchanges.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace exchanges.Exchanges
{
    public class bitfinexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var obj = JsonConvert.DeserializeObject(json); ;
            JArray jsonArray = JArray.Parse(json);


            foreach (var dto in jsonArray)
            {
                string symbolName = dto[0].ToString().RemoveSpecialCharacters().Substring(1); // валюты приходят вида i.e. tBTCUSD, tETHUSD https://docs.bitfinex.com/reference/rest-public-tickers
                var d = dto[3].ToObject<double>();                                                                                             
                if (!result.currencies.Any(x => x.pairName == symbolName))
                {
                    var currency = new currency
                    {
                        pairName = symbolName,
                        exchanges = new List<exchange>
                        {
                            new exchange
                            {
                                name = "bitfinex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto[7].ToString().PowerConverter(),
                                 //   askPrice = dto[3].ToString().PowerConverter(),
                                    askPrice = (decimal)dto[3],
                                    bidPrice = dto[1].ToString().PowerConverter()
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
                        name = "bitfinex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto[7].ToString().Contains("E") ? decimal.Parse(dto[7].ToString(), NumberStyles.Float).ToString() : dto[7].ToString(),
                           // askPrice = dto[3].ToString().Contains("E") ? decimal.Parse(dto[3].ToString(), NumberStyles.Float).ToString() : dto[3].ToString(),
                            askPrice = (decimal)dto[3],
                            bidPrice = dto[1].ToString().Contains("E") ? decimal.Parse(dto[1].ToString(), NumberStyles.Float).ToString() : dto[1].ToString()
                        }
                    });
                }
            }
        }
    }
}