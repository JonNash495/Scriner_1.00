using exchanges.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    public class latokenMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<List<latoken>>(json);
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
                                name = "latoken",
                                exchangeData=new exchangeData
                                {
                                    lastPrice = dto.lastPrice != null ? dto.lastPrice.ToString().PowerConverter() : string.Empty,
                                    askPrice = dto.bestAsk != null ? dto.bestAsk.ToString().PowerConverter() : string.Empty,
                                    bidPrice = dto.bestBid != null ? dto.bestBid.ToString().PowerConverter() : string.Empty
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
                        name = "latoken",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.lastPrice != null ? dto.lastPrice.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.bestAsk != null ? dto.bestAsk.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bestBid != null ? dto.bestBid.ToString().PowerConverter() : string.Empty
                        }
                    });
                }
            }
        }
    }
}
