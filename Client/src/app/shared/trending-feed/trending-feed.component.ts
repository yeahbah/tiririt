import { Component, OnInit } from '@angular/core';
import { IPagingResultEnvelope } from 'src/app/core/PagingResultEnvelope';
import { PostModel } from 'src/app/my-feed/post-model';
import { MyFeedService } from 'src/app/my-feed/my-feed.service';
import { PagingParam } from 'src/app/core/paging-params';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-trending-feed',
  templateUrl: './trending-feed.component.html',
  styleUrls: ['./trending-feed.component.css']
})
export class TrendingFeedComponent implements OnInit {

  trendingFeed: IPagingResultEnvelope<PostModel>;
  paging: PagingParam = new PagingParam();
  spinnerHidden = true;

  constructor(private feedService: MyFeedService) { }

  ngOnInit(): void {    
    this.paging.pageIndex = 0;    
    this.reload();
  }

  reload() {        
    this.spinnerHidden = false;
    this.feedService.getTrendingFeed(this.paging)
      .pipe(finalize(() => {
        this.spinnerHidden = true;
      }))
      .subscribe(result => {
        this.trendingFeed = result;
      })
  }

  loadNextPage() {
    if (!this.spinnerHidden) return;
    if (!this.trendingFeed) {
      this.reload();
      return;
    };

    this.spinnerHidden = false;
    this.paging.pageIndex++;    
    this.feedService.getTrendingFeed(this.paging)
      .pipe(finalize(() => {
        this.spinnerHidden = true;
      }))
      .subscribe(result => { 
        for (let i = 0; i<result.data.length; i++) {       
          this.trendingFeed.data.push(result.data[i])
        }
      });
  }

}
