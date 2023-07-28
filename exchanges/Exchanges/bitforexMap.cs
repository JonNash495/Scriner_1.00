using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bitforexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            string dataUrl = "https://api.bitforex.com/api/v1/market/ticker?symbol=";
            var dtos = JsonConvert.DeserializeObject<bitforexCurrency>(json);
            foreach (var currencyRes in dtos.data)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync($"{dataUrl}{currencyRes.symbol}").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var dto = JsonConvert.DeserializeObject<bitforex>(responseBody);

                if (dto.data != null)
                {
                    if (!result.currencies.Any(x => x.pairName == currencyRes.symbolName))
                    {
                        var currency = new currency
                        {
                            pairName = currencyRes.symbolName,
                            exchanges = new List<exchange>
                        {
                            new exchange
                            {
                                name = "bitforex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.data.last.ToString().PowerConverter(),
                                    askPrice = dto.data.buy.ToString().PowerConverter(),
                                    bidPrice = dto.data.sell.ToString().PowerConverter()
                                }
                            }
                        }
                        };

                        result.currencies.Add(currency);
                    }
                    else
                    {
                        var currency = result.currencies.First(x => x.pairName == currencyRes.symbolName);

                        currency.exchanges.Add(new exchange
                        {
                            name = "bitforex",
                            exchangeData = new exchangeData
                            {
                                lastPrice = dto.data.last.ToString().PowerConverter(),
                                askPrice = dto.data.buy.ToString().PowerConverter(),
                                bidPrice = dto.data.sell.ToString().PowerConverter()
                            }
                        });
                    }
                }
            }
        }
    }
}
