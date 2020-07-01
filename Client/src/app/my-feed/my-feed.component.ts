import { Component, OnInit, Input } from '@angular/core';
import { MyFeedService } from './my-feed.service';
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
  activeFilter = 0;
  myFeed: IPagingResultEnvelope<PostModel>;
  spinnerHidden = true;
  paging = new PagingParam();

  constructor(private myFeedService: MyFeedService, private interactionService: InteractionService) { }

  ngOnInit(): void {
    this.filterFeed(0);
    
    this.interactionService.reloadMessage$.subscribe(message => {
      if (message == 'RELOAD') {
        this.filterFeed(this.activeFilter);        
      }
    });
    
  }

  reload() {
    this.paging.sortColumn = 'postDate';
    this.paging.sortOrder = 'desc';
    this.myFeedService.getMyFeed(this.paging)
      .subscribe(result => {
        this.myFeed = result;
      }, error => console.error(error));
  }

  goToPost() {
    console.log('hello');
  }

  filterFeed(filter: number) {
    this.activeFilter = filter;  
    this.spinnerHidden = false;      
    switch(filter) {      
      case 1:
        this.myFeedService.getMentionsFeed()
        .pipe(finalize(() => {
          this.spinnerHidden = true;
        }))
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));                
        break;
      
      case 2: 
        this.myFeedService.getWatchlistFeed()
        .pipe(finalize(() => {
          this.spinnerHidden = true;
        }))
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));              
        break;
      
      case 3:
        this.myFeedService.getSubscriptionFeed()
        .pipe(finalize(() => {
          this.spinnerHidden = true;
        }))
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));                
        break;
      
      default:                  
        this.myFeedService.getMyFeed(this.paging)
          .pipe(finalize(() => {
            this.spinnerHidden = true;
          }))
          .subscribe(result => {
            this.myFeed = result;
          }, error => console.error(error));        

        break;
    }
  }

}
