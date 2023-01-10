# StockDataService
This is based on ASP.NET Worker Service
    
    
1. Scrape data from website: https://www.dse.com.bd/latest_share_price_scroll_l.php
2. If status is closed, worker service does not enter data. When status is open then data scraping will be performed.
    You have to enter the stock price for each company per minute once.
