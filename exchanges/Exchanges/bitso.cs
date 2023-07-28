using exchanges.Extensions;
using Newtonsoft.Json;

namespace exchanges.Exchanges
{
    public class bitso
    {
        public bool success { get; set; }
        public List<Payload> payload { get; set; }
    }

    public class Payload
    {
        public string high { get; set; }
        public string last { get; set; }
        public DateTime created_at { get; set; }
        public string book { get; set; }
        public string symbolName { get { return this.book.RemoveSpecialCharacters(); } set { } }
        public string volume { get; set; }
        public string vwap { get; set; }
        public string low { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string change_24 { get; set; }
        public RollingAverageChange rolling_average_change { get; set; }
    }

    public class RollingAverageChange
    {
        [JsonProperty("6")]
        public string _6 { get; set; }
    }
}
