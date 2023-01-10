namespace StockData.Infrastructure.Entities
{
    public class StockPrice : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public double LastTradingPrice { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double ClosePrice { get; set; }
        public double YesterdayClosePrice { get; set; }
        public double? Change { get; set; }
        public double Trade { get; set; }
        public double Value { get; set; }
        public double Volume { get; set; }
        public DateTime DateTime { get; set; }
        public Company Company { get; set; }
    }
}
