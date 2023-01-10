using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

namespace StockData.Worker.htmlagilitypack
{
    public static class HtmlExtractor
    {
        public static bool IsOpen()
        {
            bool ans = false;
            var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode(".//span[@class='green']//b");

            if(node.InnerHtml == "Open") 
                ans = true;
            
            return ans;
        }

        public static List<List<string>> CompanyDetails()
        {
            var value = new List<List<string>>();

            var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            //var htmlNodes = htmlDoc.DocumentNode.SelectNodes(".//tbody/tr/td");
            var tempList = new List<string>();
            var CompanyDetails = htmlDoc.DocumentNode.SelectNodes(".//div[@class='table-responsive inner-scroll']/table/tbody/tr/td");
            var TradeCode1 = htmlDoc.DocumentNode.SelectSingleNode(".//div[@class='table-responsive inner-scroll']/table/tbody/tr/td/a");

            for (int i = 0; i < CompanyDetails.Count; i++)
            {
                if (i == 1)
                {
                    tempList.Add(TradeCode1.InnerText.ToString().Trim());
                }
                else
                {
                    tempList.Add(CompanyDetails[i].InnerText.ToString().Trim());
                }
            }

            value.Add(tempList);
            tempList = new List<string>();
            CompanyDetails.Clear();
            CompanyDetails = htmlDoc.DocumentNode.SelectNodes(".//div[@class='table-responsive inner-scroll']/table/tr/td");
            var TradeCode = htmlDoc.DocumentNode.SelectNodes(".//div[@class='table-responsive inner-scroll']/table/tr/td/a");
            int cnt = 0;
            int j = 0;
            foreach (var c in CompanyDetails)
            {
                cnt++;

                if (cnt % 11 == 2)
                {

                    tempList.Add(TradeCode[j++].InnerHtml.Trim());
                }
                else
                {

                    tempList.Add(c.InnerHtml);
                }
                if (cnt % 11 == 0)
                {

                    value.Add(tempList);
                    tempList = new List<string>();
                }

            }
            return value;
        }
    }
}
