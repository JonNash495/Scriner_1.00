using exchanges.Extensions;

namespace exchanges.Exchanges
{
    public class bybit
    {
        public int ret_code { get; set; }
        public string ret_msg { get; set; }
        public List<result> result { get; set; }
        public string ext_code { get; set; }
        public string ext_info { get; set; }
        public string time_now { get; set; }
    }

    public class result
    {
        public string symbol { get; set; }
        public string symbolName { get { return this.symbol.RemoveSpecialCharacters(); } set { } }
        public string bid_price { get; set; }
        public decimal ask_price { get; set; }
        public string last_price { get; set; }
        public string last_tick_direction { get; set; }
        public string prev_price_24h { get; set; }
        public string price_24h_pcnt { get; set; }
        public string high_price_24h { get; set; }
        public string low_price_24h { get; set; }
        public string prev_price_1h { get; set; }
        public string mark_price { get; set; }
        public string index_price { get; set; }
        public double open_interest { get; set; }
        public int countdown_hour { get; set; }
        public string turnover_24h { get; set; }
        public double volume_24h { get; set; }
        public string funding_rate { get; set; }
        public string predicted_funding_rate { get; set; }
        public string next_funding_time { get; set; }
        public string predicted_delivery_price { get; set; }
        public string total_turnover { get; set; }
        public int total_volume { get; set; }
        public string delivery_fee_rate { get; set; }
        public string delivery_time { get; set; }
        public string price_1h_pcnt { get; set; }
        public string open_value { get; set; }
    }
}
