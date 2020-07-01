import { Component, OnInit, ViewChildren, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../core/authentication/auth.service';
import { TrendingFeedComponent } from '../shared/trending-feed/trending-feed.component';
import { MatTab, MatTabGroup } from '@angular/material/tabs';

@Component({
  selector: 'app-feed-container',
  templateUrl: './feed-container.component.html',
  styleUrls: ['./feed-container.component.css']
})
export class FeedContainerComponent implements OnInit {

  @ViewChild(MatTabGroup)
  mainTabGroup: MatTabGroup;

  @ViewChild(TrendingFeedComponent)
  trendingFeedComponent: TrendingFeedComponent;

  activeChildComponent: Component;

  // @ViewChild()
  
  isAuthenticated = false;
  subscription: Subscription;


  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$
            .subscribe(status => { 
                this.isAuthenticated = status;
                console.log(`isAuthenticated: ${status}`);
            });        
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
 
}

}
