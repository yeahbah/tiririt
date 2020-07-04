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
import { MatDialog } from '@angular/material/dialog';
import { SubmitPostDialogComponent } from '../dialogs/submit-post-dialog/submit-post-dialog.component';

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
    private dialog: MatDialog,
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
      this.interactionService.sendDefaultPostTextMessage({ defaultText: '$' + this.stockSymbol });
    });

    this.interactionService.reloadMessage$.subscribe(message => {
      if (message == 'RELOAD') {
        this.reloadPosts();
      }
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
        this.stock = result;      
        this.interactionService.loadedStock(result);
      });

    this.reloadPosts();
  }
 
  reloadPosts() {
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

  showNewPostDialog() {
    this.dialog.open(SubmitPostDialogComponent, { data: { defaultText: `$${this.stockSymbol}` } });
  }

}
