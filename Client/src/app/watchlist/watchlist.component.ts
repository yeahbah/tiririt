import { Component, OnInit } from '@angular/core';
import { WatchlistService } from './watchlist.service';
import { MatTableDataSource } from '@angular/material/table';
import { WatchlistModel } from './watchlist-model';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { InteractionService } from '../core/InteractionService';
import { Router } from '@angular/router';
import { IStockModel } from '../public/models/stock-model';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {

  watchListModel: WatchlistModel | null;
  dataSource = new MatTableDataSource<IStockModel>();
  displayedColumns: string[] = ['symbol', 'price', 'actions'];

  constructor(
    private watchListService: WatchlistService,
    private spinner: NgxSpinnerService,
    private interactionService: InteractionService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.watchListService.getWatchList()
      .subscribe(result => {
        this.refreshList(result);
      }, error => console.error(error));

    this.interactionService.reloadWatchListMessage$
      .subscribe(newWatchList => {
        console.log('hello');
        this.refreshList(newWatchList);
      });
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
    this.dataSource = new MatTableDataSource<IStockModel>(watchList?.stocks) 
    this.watchListModel = watchList;
  }

  onEnterKey(event: any) {
    const value = event.target.value;
    if (value == "") return;

    this.addStock(value);
  }  

}
