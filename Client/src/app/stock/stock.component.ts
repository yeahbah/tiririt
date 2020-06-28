import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PostModel } from '../my-feed/post-model';
import { AuthService } from '../core/authentication/auth.service';
import { PublicFeedService } from '../public/public-feed.service';
import { ActivatedRoute } from '@angular/router';
import { IStockModel } from '../public/models/stock-model';
import { IStockQuoteModel } from '../public/models/stock-quote-model';
import { WatchlistService } from '../watchlist/watchlist.service';
import { InteractionService } from '../core/InteractionService';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  stockFeed: IPagingResultEnvelope<PostModel>;
  isAuthenticated: boolean = false;
  subscription: Subscription;
  stockSymbol: string;
  stock: IStockModel;
  lastTrade: IStockQuoteModel;
  isWatched = false;

  constructor(
    private publicFeedService: PublicFeedService,
    private watchListService: WatchlistService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private location: Location,
    private interactionService: InteractionService) { 
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.stockSymbol = params['symbol'];
      this.reload();
    });
  }

  reload() {
    this.subscription = this.authService.authNavStatus$
    .subscribe(status => { 
      this.isAuthenticated = status
    });            

  this.stockSymbol = this.route.snapshot.paramMap.get('symbol');
  this.publicFeedService.getStockInfo(this.stockSymbol)
    .subscribe(result => {
      console.log(result);
      this.stock = result;      
      this.interactionService.loadedStock(result);
    });

  this.publicFeedService.getPostsByStock(this.stockSymbol)
    .subscribe(result => {
      this.stockFeed = result;
    });

  }
 
  watchStock(symbol: string) {  
    if (!this.isAuthenticated) {
      this.authService.login();
    }
    else {
      this.watchListService.addStockToWatchList(0, [ symbol ])
        .subscribe(result => {
          this.reload();
          this.interactionService.reloadWatchList(result);
        });      
    }
  }

  unwatch(symbol: string) {
    if (!this.isAuthenticated) {
      this.authService.login();
    }
    else {
      this.watchListService.deleteStock(0, symbol)
        .subscribe(result => {
          this.reload();
          this.interactionService.reloadWatchList(result);
        });      
    }
  }

  goBack() {
    this.location.back();
  }

}
