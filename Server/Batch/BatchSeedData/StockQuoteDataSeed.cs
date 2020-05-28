using System;
using System.Collections.Generic;
using System.IO;
using Tiririt.App.Service;
using Tiririt.Data.Internal;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace BatchSeedData
{
    public class StockQuoteDataSeed
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

        internal void ProcessFile(string file)
        {
            var reader = new StreamReader(file);
            var stocks = new List<StockModel>();
            var stockQuotes = new List<StockQuoteModel>();
            var sectors = new List<StockSectorModel>();
            int? sectorId = null;           
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var symbol = values[0];
                if (symbol.Contains("^")) 
                {
                    // sector
                    var sector = stockSectorService.GetSector(symbol);
                    if (sector == null) {
                        sector = new StockSectorModel 
                        {
                            SectorName = symbol
                        };                   
                        sector = stockSectorService.AddSector(sector);                        
                    } 
                    
                    sectorId = sector.SectorId;
                }

                // insert to stock
                var stock = stockService.GetStock(symbol);
                if (stock == null) {
                    stock = stockService.AddStock(new StockModel { Symbol = symbol, SectorId = sectorId, Name = values[1] });
                }
                decimal? netForeignBuy = null;
                if (values.Length == 8) 
                {
                    netForeignBuy = decimal.Parse(values[7]);
                }
                stockQuoteService.AddStockQuote(new StockQuoteModel 
                {
                    TradeDate = DateTime.Parse(values[1]),
                    Open = decimal.Parse(values[2]),
                    High = decimal.Parse(values[3]),
                    Low = decimal.Parse(values[4]),
                    Close = decimal.Parse(values[5]),
                    Volume = long.Parse(values[6]),
                    NetForeignBuy = netForeignBuy,
                    StockId = stock.StockId
                });
            }
        }
    }
}