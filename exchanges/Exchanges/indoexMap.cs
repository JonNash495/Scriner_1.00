using exchanges.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    internal class indoexMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<indoex>(json);
            foreach (var dto in dtos.marketdetails)
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
                                name = "indoex",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.last!=null?dto.last.ToString().PowerConverter():string.Empty,
                                    askPrice = dto.ask!=null?dto.ask.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.bid!=null?dto.bid.ToString().PowerConverter():string.Empty,
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
                        name = "indoex",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.last != null ? dto.last.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.ask != null ? dto.ask.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bid != null ? dto.bid.ToString().PowerConverter() : string.Empty,
                        }
                    });
                }
            }
        }
    }
}
