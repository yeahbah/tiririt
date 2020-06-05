import { Component, OnInit } from '@angular/core';
import { MyFeedService } from './my-feed.service';
import { PostModel } from './post-model';

@Component({
  selector: 'app-my-feed',
  templateUrl: './my-feed.component.html',
  styleUrls: ['./my-feed.component.css']
})
export class MyFeedComponent implements OnInit {

  myFeed: PostModel[];

  constructor(private myFeedService: MyFeedService) { }

  ngOnInit(): void {
    this.myFeedService.getMyFeed()
      .subscribe(result => {
        this.myFeed = result;
        console.log(this.myFeed);
      }, error => console.error(error));
  }

  goToPost() {
    console.log('hello');
  }

}
