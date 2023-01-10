# StockDataService
This is based on ASP.NET Worker Service
    
1. Create a Service in Local Machine "Services"  
2. Set the data store path in appsetting.json
3. Start the Service you create, the the service do the following things:   

        i. Scrape data from website: https://www.dse.com.bd/latest_share_price_scroll_l.php
        ii. If status is closed, worker service does not enter data. When status is open then data scraping will be performed.
            This Worker service enter the stock price for each company per minute once.
