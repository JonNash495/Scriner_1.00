using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class xtcom
    {
        public int rc { get; set; }
        public string mc { get; set; }
        public List<object> ma { get; set; }
        public List<xtcomResult> result { get; set; }
    }

    public class xtcomResult
    {
        public string s { get; set; }
        public string symbolName { get { return s.RemoveSpecialCharacters(); } set { } }
        public object t { get; set; }
        public string cv { get; set; }
        public string cr { get; set; }
        public string o { get; set; }
        public string l { get; set; }
        public string h { get; set; }
        public string c { get; set; }
        public string q { get; set; }
        public string v { get; set; }
        public string ap { get; set; }
        public string aq { get; set; }
        public string bp { get; set; }
        public string bq { get; set; }
    }
}