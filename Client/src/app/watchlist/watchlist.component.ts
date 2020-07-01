import { Component, OnInit, ViewChild } from '@angular/core';
import { WatchlistService } from './watchlist.service';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { InteractionService } from '../core/InteractionService';
import { Router } from '@angular/router';
import { IStockModel } from '../public/models/stock-model';
import { MatSort } from '@angular/material/sort';
import { PagingParam } from '../core/paging-params';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {

  @ViewChild(MatSort) sort: MatSort;
  watchListModel: IPagingResultEnvelope<IStockModel> | null;
  dataSource = new MatTableDataSource<IStockModel>();
  displayedColumns: string[] = ['symbol', 'lastTradePrice', 'percentChange', 'actions'];
  currentSort: { active, direction };

  constructor(
    private watchListService: WatchlistService,
    private spinner: NgxSpinnerService,
    private interactionService: InteractionService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const defaultSort = { active: 'symbol', direction: 'asc'};
    this.reload(defaultSort);

    this.interactionService.reloadWatchListMessage$
      .pipe(finalize(() => {
        
      }))
      .subscribe(newWatchList => {
        this.reload(defaultSort)
      });
  }

  reload(sort: { active, direction }) {
    this.currentSort = sort;
    
    const paging = new PagingParam();
    if (sort.direction !== '') {
      paging.sortColumn = sort.active;
      paging.sortOrder = sort.direction;  
    }
    paging.pageSize = 500;
    this.watchListService.getWatchList(paging)
      .subscribe(result => {
        this.dataSource = new MatTableDataSource<IStockModel>(result.data);
        this.watchListModel = result;
      }, error => console.error(error));
  }

  addStock(stockSymbol: string) {   
    if (stockSymbol.trim() == '') return; 
    if (this.watchListModel == null) return;    

    this.spinner.show();
    this.watchListService.addStockToWatchList(0, [stockSymbol])
      .pipe(finalize(() => {
        this.interactionService.sendMessage('RELOAD');        
        this.spinner.hide();
      }))
      .subscribe(result => {
        this.reload(this.currentSort);
      });
  }

  deleteStock(stockSymbol: string) {
    this.spinner.show();
    this.watchListService.deleteStock(0, stockSymbol)
      .pipe(finalize(() => {
        this.interactionService.sendMessage('RELOAD');
        this.spinner.hide();
      }))
      .subscribe(result => {
        this.reload(this.currentSort);
      })      
  }

  onEnterKey(event: any) {
    const value = event.target.value;
    if (value == "") return;

    this.addStock(value);
  }  

  sortData(event: any) {
    console.log(event);
    if (event.active == 'symbol') {
      this.reload(event);
      return;
    } 
    
    if (event.active == 'percentChange') {
      this.watchListModel.data.sort((a, b) => {
        if (event.direction == 'asc') {
          return a.percentChange - b.percentChange;
        } else if (event.direction == 'desc') {
          return b.percentChange - a.percentChange;
        }
      });
      this.dataSource = new MatTableDataSource<IStockModel>(this.watchListModel.data);
    }

    if (event.active == 'lastTradePrice') {
      this.watchListModel.data.sort((a, b) => {
        if (event.direction == 'asc') {
          return a.lastTradePrice - b.lastTradePrice;
        } else if (event.direction == 'desc') {
          return b.lastTradePrice - a.lastTradePrice;
        }
      });
      this.dataSource = new MatTableDataSource<IStockModel>(this.watchListModel.data);
    }
  }  

}
