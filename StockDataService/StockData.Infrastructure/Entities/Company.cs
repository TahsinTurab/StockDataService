using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Entities
{
    public class Company : IEntity<int>
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }
        public List<StockPrice> StockPrices { get; set; }
    }
}
