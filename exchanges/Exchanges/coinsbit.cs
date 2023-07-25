using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class coinsbit
    {
        public string name { get; set; }
        public string symbolName { get { return this.name.RemoveSpecialCharacters(); } set { } }
        public string bid { get; set; }
        public decimal ask { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string last { get; set; }
        public string vol { get; set; }
        public string deal { get; set; }
        public string change { get; set; }
    }
}