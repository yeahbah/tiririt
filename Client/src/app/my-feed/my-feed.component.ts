import { Component, OnInit, Input } from '@angular/core';
import { MyFeedService } from './my-feed.service';
import { PostModel } from './post-model';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { InteractionService } from '../core/InteractionService';

@Component({
  selector: 'app-my-feed',
  templateUrl: './my-feed.component.html',
  styleUrls: ['./my-feed.component.css']
})
export class MyFeedComponent implements OnInit {

  myFeed: IPagingResultEnvelope<PostModel>;

  @Input() feedFilterVisible = true;
  activeFilter = 0;

  constructor(private myFeedService: MyFeedService, private interactionService: InteractionService) { }

  ngOnInit(): void {
    this.myFeedService.getMyFeed()
      .subscribe(result => {
        this.myFeed = result;
      }, error => console.error(error));
    
    this.interactionService.reloadMessage$.subscribe(message => {
      if (message == 'RELOAD') {
        this.filterFeed(this.activeFilter);        
      }
    });
    
  }

  goToPost() {
    console.log('hello');
  }

  filterFeed(filter: number) {
    this.activeFilter = filter;    
    switch(filter) {      
      case 1:
        this.myFeedService.getMentionsFeed()
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));                
        break;
      
      case 2: 
        this.myFeedService.getWatchlistFeed()
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));              
        break;
      
      case 3:
        this.myFeedService.getSubscriptionFeed()
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));                
        break;
      
      default:
        this.myFeedService.getMyFeed()
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));        

        break;
    }
  }

}
