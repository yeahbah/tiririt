import { Component, OnInit, Input } from '@angular/core';
import { createChart, IChartApi, isBusinessDay } from 'lightweight-charts';
import { PublicFeedService } from 'src/app/public/public-feed.service';
import { IStockModel } from 'src/app/public/models/stock-model';
import { InteractionService } from 'src/app/core/InteractionService';

@Component({
  selector: 'app-stock-chart',
  templateUrl: './stock-chart.component.html',
  styleUrls: ['./stock-chart.component.css']
})
export class StockChartComponent implements OnInit {

  chart: IChartApi;
  @Input() stockModel: IStockModel;
  areaSeries: any;
  constructor(private publicFeedService: PublicFeedService, private interactionService: InteractionService) { 
    
  }

  ngOnInit(): void {
    this.interactionService.loadedStockMessage$
      .subscribe(result => {
        this.stockModel = result;
        this.loadChart();
      });    
  }

  loadChart() {
    this.publicFeedService.getStockEodChart(this.stockModel.symbol)
    .subscribe(result => {
      if (this.chart) {
        this.chart.remove();
      }
      this.chart = createChart('chart-container', 
        { 
          // width: 700, 
          height: 200,     
          rightPriceScale: {
            scaleMargins: {
              top: 0.2,
              bottom: 0.2,
            },
            borderVisible: false,
          },
          timeScale: {
            borderVisible: false,
          },
          layout: {
            backgroundColor: '#ffffff',
            textColor: '#333',
          },
          grid: {
            horzLines: {
              color: '#eee',
            },
            vertLines: {
              color: '#ffffff',
            },
          },
        });
        
      this.areaSeries = this.chart.addAreaSeries({
        topColor: this.stockModel.pointsChange < 0 ? 'rgba(255, 82, 82, 0.56)' : 'rgba(76, 175, 80, 0.56)',
        bottomColor: this.stockModel.pointsChange < 0 ? 'rgba(255, 82, 82, 0.04)' : 'rgba(76, 175, 80, 0.04)',
        lineColor: this.stockModel.pointsChange < 0 ? 'rgba(255, 82, 82, 1)' : 'rgba(76, 175, 80, 1)',
        lineWidth: 2,        
      });      

      // const lineSeries = this.chart.addLineSeries();
      this.areaSeries.setData(result);
      // this.chart.timeScale().fitContent();
      // this.initializeChart();
    })
  }

  // businessDayToString(businessDay) {
  //   return businessDay.year + '-' + businessDay.month + '-' + businessDay.day;
  // }
  
  // initializeChart() {
  //   const toolTipWidth = 100;
  //   const toolTipHeight = 80;
  //   const toolTipMargin = 15;
    
  //   let toolTip = document.createElement('div');
  //   toolTip.className = 'floating-tooltip-2';
  //   document.getElementById('chart-container').appendChild(toolTip);
  
  //   this.chart.subscribeCrosshairMove(function(param) {
  //     if (!param.time || param.point.x < 0 || param.point.x > 700 || param.point.y < 0 || param.point.y > 300) {
  //       toolTip.style.display = 'none';
  //       return;
  //     }
    
  //     var dateStr = isBusinessDay(param.time)
  //       ? this.businessDayToString(param.time)
  //       : new Date(param.time * 1000).toLocaleDateString();
    
  //     toolTip.style.display = 'block';
  //     var price = param.seriesPrices.get(this.areaSeries);
  //     toolTip.innerHTML = '<div style="color: rgba(255, 70, 70, 1)">Apple Inc.</div>' +
  //       '<div style="font-size: 24px; margin: 4px 0px">' + Math.round(+price * 100) / 100 + '</div>' +
  //       '<div>' + dateStr + '</div>';
    
  //     var y = param.point.y;
    
  //     var left = param.point.x + toolTipMargin;
  //     if (left > 700 - toolTipWidth) {
  //       left = param.point.x - toolTipMargin - toolTipWidth;
  //     }
    
  //     var top = y + toolTipMargin;
  //     if (top > 300 - toolTipHeight) {
  //       top = y - toolTipHeight - toolTipMargin;
  //     }
    
  //     toolTip.style.left = left + 'px';
  //     toolTip.style.top = top + 'px';
  //   });
  // }

  

}
