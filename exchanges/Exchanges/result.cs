namespace exchanges.Exchanges
{
    public class exchangeResult
    {
        public List<currency> currencies = new List<currency>();
    }

    public class currency
    {
        /// <summary>
        /// валюта
        /// </summary>
        public string pairName { get; set; }
        public List<exchange> exchanges { get; set; }
    }

    public class exchange
    {
        /// <summary>
        /// название биржи
        /// </summary>
        public string name { get; set;}        
        public exchangeData exchangeData { get; set; }       
    }

    public class exchangeData
    {        
        /// <summary>
        /// последняя цена
        /// </summary>
        public string lastPrice { get; set; }
        /// <summary>
        /// цена покупки
        /// </summary>
        public string askPrice { get; set; }
        /// <summary>
        /// цена продажи
        /// </summary>
        public string bidPrice { get; set; }        
        /// <summary>
        /// комиссия покупки
        /// </summary>
        //public string commissionPurchase { get; set;}
        /// <summary>
        /// комиссия за перевод
        /// </summary>
        //public string commissionTransfer { get; set;}
    }
}
