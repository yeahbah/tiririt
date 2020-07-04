import { Component, OnInit, Input } from '@angular/core';
import { MyFeedService, FeedParam, FeedType } from './my-feed.service';
import { PostModel } from './post-model';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { InteractionService } from '../core/InteractionService';
import { PagingParam } from '../core/paging-params';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-my-feed',
  templateUrl: './my-feed.component.html',
  styleUrls: ['./my-feed.component.css']
})
export class MyFeedComponent implements OnInit {

  @Input() feedFilterVisible = true;
  myFeed: IPagingResultEnvelope<PostModel>;
  spinnerHidden = true;

  feedFilter: FeedParam[] = [];
  activeFilter: FeedParam;


  constructor(private myFeedService: MyFeedService, private interactionService: InteractionService) { 
    this.feedFilter = [
      { feedType: FeedType.UserFeed, paging: new PagingParam() },
      { feedType: FeedType.MentionsFeed, paging: new PagingParam() },
      { feedType: FeedType.WatchListFeed, paging: new PagingParam() },
      { feedType: FeedType.SubscriptionFeed, paging: new PagingParam() }
    ];

    for(let i = 0; i < this.feedFilter.length; i++) {
      this.feedFilter[i].paging.sortColumn = 'postDate';
      this.feedFilter[i].paging.sortOrder = 'desc';
    }
    this.activeFilter = this.feedFilter[0];
  }

  ngOnInit(): void {
    this.filterFeed(this.activeFilter);
    
    this.interactionService.reloadMessage$.subscribe(message => {
      if (message == 'RELOAD') {
        if (this.myFeed) {          
          this.filterFeed(this.activeFilter, true);
        }
      }
    });
    
  }

  reload() {
    this.myFeedService.getFeed(this.activeFilter)
      .subscribe(result => {
        this.myFeed = result;
      }, error => console.error(error));
  }

  filterFeed(feedParam: FeedParam, appendMode: boolean = false) {
    this.activeFilter = feedParam;  
    this.spinnerHidden = false;    
    this.myFeedService.getFeed(feedParam)
      .pipe(finalize(() => {
        this.spinnerHidden = true;
      }))
      .subscribe(result => {
        if (appendMode && this.myFeed) {
          if (result.data.length == 0) {
            this.activeFilter.paging.pageIndex--; // next page was empty. make sure the pageIndex stay with the current page.
          }
          for(let i=0; i < result.data.length; i++) {
            this.myFeed.data.push(result.data[i]);
          }
        } else {
          this.myFeed = result;
        }
      });
  }

  loadNextPage() {
    if (!this.spinnerHidden) return;
    if (!this.myFeed) {
      this.reload();
      return;
    }
    this.activeFilter.paging.pageIndex++;
    this.filterFeed(this.activeFilter, true);
  }

  loadAll() {
    this.feedFilter[0].paging.pageIndex = 0;
    this.filterFeed(this.feedFilter[0]);
  }

  loadMentions() {
    this.feedFilter[0].paging.pageIndex = 0;
    this.filterFeed(this.feedFilter[1]);
  }

  loadWatchList() {
    this.feedFilter[0].paging.pageIndex = 0;
    this.filterFeed(this.feedFilter[2]);
  }

  loadSubscription() {
    this.feedFilter[0].paging.pageIndex = 0;
    this.filterFeed(this.feedFilter[3]);
  }

}
