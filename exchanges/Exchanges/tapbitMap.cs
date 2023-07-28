using exchanges.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    public class tapbitMap
    {
        public void Convert(exchangeResult result, string json)
        {
            tapbit dtos = JsonConvert.DeserializeObject<tapbit>(json);
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
                                name = "tapbit",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last_price.PowerConverter(),
                                    askPrice = dto.lowest_ask.PowerConverter(),
                                    bidPrice = dto.highest_bid.PowerConverter()
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
                        name = "tapbit",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last_price.PowerConverter(),
                            askPrice = dto.lowest_ask.PowerConverter(),
                            bidPrice = dto.highest_bid.PowerConverter()
                        }
                    });
                }
            }
        }
    }
}