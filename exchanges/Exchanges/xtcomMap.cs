using exchanges.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchanges.Exchanges
{
    public class xtcomMap
    {
        public void Convert(exchangeResult result, string json)
        {
            var dtos = JsonConvert.DeserializeObject<xtcom>(json);
            foreach (var dto in dtos.result)
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
                                name = "xtcom",
                                exchangeData=new exchangeData
                                {
                                    lastPrice=dto.l!=null?dto.l.ToString().PowerConverter():string.Empty,
                                    askPrice = dto.ap!=null?dto.ap.ToString().PowerConverter():string.Empty,
                                    bidPrice = dto.bp!=null?dto.bp.ToString().PowerConverter():string.Empty,
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
                        name = "xtcom",
                        exchangeData = new exchangeData
                        {
                            lastPrice = dto.l != null ? dto.l.ToString().PowerConverter() : string.Empty,
                            askPrice = dto.ap != null ? dto.ap.ToString().PowerConverter() : string.Empty,
                            bidPrice = dto.bp != null ? dto.bp.ToString().PowerConverter() : string.Empty,
                        }
                    });
                }
            }
        }
    }
}
