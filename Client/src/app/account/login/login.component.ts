import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from '../../core/authentication/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TrendingFeedComponent } from 'src/app/shared/trending-feed/trending-feed.component';
import { FeedContainerComponent } from 'src/app/feed-container/feed-container.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit { 

  @ViewChild(FeedContainerComponent)
  feedContainer: FeedContainerComponent;
  
  constructor(
    private router: Router,
    private authService: AuthService) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/home'])
    }
  }

  onScroll() {
    if (this.feedContainer.mainTabGroup.selectedIndex == 0) {              
        this.feedContainer.trendingFeedComponent.loadNextPage();      
    }
  }
}