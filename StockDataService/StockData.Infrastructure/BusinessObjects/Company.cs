using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.BusinessObjects
{
    public class Company
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }
        public StockPrice StockPrice { get; set; }
    }
}
