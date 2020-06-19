using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace BatchSeedData
{
    public class StockQuoteDataSeed : DataSeederBase
    {
        private readonly IStockService stockService;
        private readonly IStockQuoteService stockQuoteService;

        private readonly IStockSectorService stockSectorService;

        public StockQuoteDataSeed(IStockService stockService, 
            IStockSectorService stockSectorService,
            IStockQuoteService stockQuoteService)
        {
            this.stockService = stockService;
            this.stockSectorService = stockSectorService;
            this.stockQuoteService = stockQuoteService;
        }

        public IStockSectorService StockSectorService { get; }

        internal async Task ProcessFile(string file)
        {
            var reader = new StreamReader(file);
            var stocks = new List<StockModel>();
            var stockQuotes = new List<StockQuoteModel>();
            var sectors = new List<StockSectorModel>();
            int? sectorId = null;

            using var dbContext = CreateDbContext();

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var symbol = values[0];
                if (symbol.Contains("^")) 
                {
                    // sector
                    //var sector = await stockSectorService.GetSector(symbol);
                    var sector = await dbContext.StockSectors.SingleOrDefaultAsync(s => s.SECTOR_NAME == symbol);
                    if (sector == null) {
                        sector = new STOCK_SECTOR 
                        {
                            SECTOR_NAME = symbol
                        };
                        //sector = await stockSectorService.AddSector(sector);                        
                        dbContext.StockSectors.Add(sector);
                        await dbContext.SaveChangesAsync();
                    } 
                    
                    sectorId = sector.STOCK_SECTOR_ID;
                }

                // insert to stock
                //var stock = await stockService.GetStock(symbol);
                var stock = await dbContext.Stocks.SingleOrDefaultAsync(s => s.SYMBOL == symbol);
                if (stock == null) {
                    var stockName = "";
                    if (values.Length == 7)
                    {
                        stockName = values[1];
                    }
                    stock = new STOCK
                    {
                        SYMBOL = symbol,
                        SECTOR_ID = sectorId,
                        NAME = stockName
                    };
                    dbContext.Stocks.Add(stock);
                    await dbContext.SaveChangesAsync();
                    //stock = await dbContext.Stocks.SingleOrDefaultAsync(s => s.SYMBOL == symbol);
                }

                if (DateTime.TryParse(values[1], out var tradeDate))
                {
                    decimal? netForeignBuy = null;
                    if (values.Length == 8)
                    {
                        netForeignBuy = decimal.Parse(values[7]);
                    }
                    dbContext.StockQuotes.Add(new STOCK_QUOTE
                    {
                        TRADE_DATE = tradeDate,//DateTime.Parse(values[1]),
                        OPEN = decimal.Parse(values[2]),
                        HIGH = decimal.Parse(values[3]),
                        LOW = decimal.Parse(values[4]),
                        CLOSE = decimal.Parse(values[5]),
                        VOLUMNE = long.Parse(values[6]),
                        NET_FOREIGN_BUY = netForeignBuy,
                        STOCK_ID = stock.STOCK_ID
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}