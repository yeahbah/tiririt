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
    }
}