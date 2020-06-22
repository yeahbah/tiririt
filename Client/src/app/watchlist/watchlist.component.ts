import { Component, OnInit } from '@angular/core';
import { WatchlistService } from './watchlist.service';
import { MatTableDataSource } from '@angular/material/table';
import { StockViewModel } from '../models/stock-view-model';
import { WatchlistModel } from './watchlist-model';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { InteractionService } from '../core/InteractionService';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {

  watchListModel: WatchlistModel | null;
  dataSource = new MatTableDataSource<StockViewModel>();
  displayedColumns: string[] = ['symbol', 'price', 'actions'];

  constructor(
    private watchListService: WatchlistService,
    private spinner: NgxSpinnerService,
    private interactionService: InteractionService
  ) { }

  ngOnInit(): void {
    this.watchListService.getWatchList()
      .subscribe(result => {
        this.refreshList(result);
      }, error => console.error(error));
  }

  addStock(stockSymbol: string) {    
    if (this.watchListModel == null) return;    

    this.spinner.show();
    this.watchListService.addStockToWatchList(this.watchListModel.watchListId, [stockSymbol])
      .pipe(finalize(() => {
        this.interactionService.sendMessage('RELOAD');
        this.spinner.hide();
      }))
      .subscribe(result => {
        this.refreshList(result)
      });
  }

  deleteStock(stockSymbol: string) {
    this.spinner.show();
    this.watchListService.deleteStock(this.watchListModel.watchListId, stockSymbol)
      .pipe(finalize(() => {
        this.interactionService.sendMessage('RELOAD');
        this.spinner.hide();
      }))
      .subscribe(result => {
        this.refreshList(result);
      })      
  }

  refreshList(watchList: WatchlistModel) {
    this.dataSource = new MatTableDataSource<StockViewModel>(watchList?.stocks) 
    this.watchListModel = watchList;
  }

  onEnterKey(event: any) {
    const value = event.target.value;
    if (value == "") return;

    this.addStock(value);
  }

}
