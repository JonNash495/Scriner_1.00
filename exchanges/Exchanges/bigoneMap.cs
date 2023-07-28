using exchanges.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    public class bigoneMap
    {
        public void Convert(exchangeResult result, string json)
        {
            bigone dtos = JsonConvert.DeserializeObject<bigone>(json);
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
                                name = "bigone",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.close,
                                    askPrice = dto.ask!=null? dto.ask.price.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.bid!=null?dto.bid.price:null
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
                        name = "bigone",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.close,
                            askPrice = dto.ask != null ? dto.ask.price.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bid != null ? dto.bid.price.ToString().PowerConverter() : null
                        }
                    });
                }
            }
        }
    }
}
