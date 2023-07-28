using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class indoex
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Marketdetail> marketdetails { get; set; }
    }

    public class Marketdetail
    {
        public string pair { get; set; }
        public string symbolName { get { return this.pair.RemoveSpecialCharacters(); } set { } }
        public string last { get; set; }
        public string lowsale { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string highsale { get; set; }

        [JsonProperty("24hrhigh")]
        public string _24hrhigh { get; set; }
        public string t24hrhigh { get; set; }
        public string name { get; set; }
        public string vendor { get; set; }
        public string baseVolume { get; set; }
        public string min_buy { get; set; }
        public string min_sell { get; set; }
        public string sellfee { get; set; }
        public string buyfee { get; set; }
        public string cmcid { get; set; }
    }
}