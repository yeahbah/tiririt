import { Component, OnInit } from '@angular/core';
import { WatchlistService } from './watchlist.service';
import { MatTableDataSource } from '@angular/material/table';
import { StockViewModel } from '../models/stock-view-model';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {

  dataSource = new MatTableDataSource<StockViewModel>();
  displayedColumns: string[] = ['symbol', 'price'];

  constructor(
    private watchListService: WatchlistService
  ) { }

  ngOnInit(): void {
    this.watchListService.getWatchList()
      .subscribe(result => {
        this.dataSource = new MatTableDataSource<StockViewModel>(result?.stocks);
      }, error => console.error(error));
  }

}
