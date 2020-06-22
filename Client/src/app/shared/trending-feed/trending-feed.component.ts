import { Component, OnInit } from '@angular/core';
import { IPagingResultEnvelope } from 'src/app/core/PagingResultEnvelope';
import { PostModel } from 'src/app/my-feed/post-model';
import { MyFeedService } from 'src/app/my-feed/my-feed.service';

@Component({
  selector: 'app-trending-feed',
  templateUrl: './trending-feed.component.html',
  styleUrls: ['./trending-feed.component.css']
})
export class TrendingFeedComponent implements OnInit {

  trendingFeed: IPagingResultEnvelope<PostModel>;

  constructor(private feedService: MyFeedService) { }

  ngOnInit(): void {
    this.feedService.getTrendingFeed()
      .subscribe(result => {
        this.trendingFeed = result;
        console.log(this.trendingFeed);
      })
  }

}
