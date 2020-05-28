using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Domain.Models;

namespace Tiririt.Web.Controllers
{
    // [Route("api/[controller]")]
    public class StockController : TiriritControllerBase
    {
        private readonly IStockService stockService;
        private readonly IStockSectorService stockSectorService;
        private readonly IStockQuoteService stockQuoteService;
        private readonly IWebHostEnvironment environment;

        public StockController(
            IStockService stockService, 
            IStockSectorService stockSectorService,
            IStockQuoteService stockQuoteService,
            IWebHostEnvironment environment)
        {
            this.stockService = stockService;
            this.stockSectorService = stockSectorService;
            this.stockQuoteService = stockQuoteService;
            this.environment = environment;
        }

        [HttpGet("{symbol}")]    
        [ProducesResponseType(200)]
        public IActionResult GetStock(string symbol)
        {
            var result = stockService.GetStock(symbol);
            if (result == null)            
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("seed")]
        public IActionResult SeedData()
        {
            var exist = stockService.GetStock("TEL");
            if (exist != null) return Ok();

            var csvFile = Path.Combine(environment.ContentRootPath, "Tiririt.Web/wwwroot/stockQuotes_05212020.csv");
            using var reader = new StreamReader(csvFile);
            
            var stocks = new List<StockModel>();
            var stockQuotes = new List<StockQuoteModel>();
            var sectors = new List<StockSectorModel>();
            int? sectorId = null;            
            while (!reader.EndOfStream) 
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var symbol = values[0];
                if (symbol.Contains("^")) 
                {
                    // sector
                    var sector = new StockSectorModel 
                    {
                        SectorName = symbol
                    };                    
                    sector = stockSectorService.AddSector(sector);
                    sectorId = sector.SectorId;
                }

                // insert to stock
                var stock = stockService.AddStock(new StockModel { Symbol = symbol, SectorId = sectorId, Name = values[1] });
                decimal? netForeignBuy = null;
                if (values.Length == 8) 
                {
                    netForeignBuy = decimal.Parse(values[7]);
                }
                stockQuoteService.AddStockQuote(new StockQuoteModel 
                {
                    TradeDate = DateTime.Parse(values[2]),
                    Open = decimal.Parse(values[3]),
                    High = decimal.Parse(values[4]),
                    Low = decimal.Parse(values[5]),
                    Close = decimal.Parse(values[6]),
                    Volume = long.Parse(values[7]),
                    NetForeignBuy = netForeignBuy,
                    StockId = stock.StockId
                });
                
            }

            return Ok();
        }

    }
}