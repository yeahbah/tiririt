import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';
import { PostModel } from '../my-feed/post-model';
import { TiriritPostService } from '../core/tiririt-post.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../core/authentication/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  postId: number;
  post: PostModel;
  isAuthenticated: boolean = false;
  subscription: Subscription;
  showMore = false;

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private postService: TiriritPostService,
    private location: Location) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$
    .subscribe(status => { 
      this.isAuthenticated = status
    });            

    this.route.params.subscribe(params => {
      this.postId = params['postId'];
      this.reload();
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }  

  reload() {
    this.postService.getPost(this.postId)
      .subscribe(result => {
        this.post = result;
      });
  }

  isBullish(bullBearLevel: any): boolean {
    return bullBearLevel == 'VeryBullish';
  }

  isBearish(bullBearLevel: any): boolean {
    return bullBearLevel == 'VeryBearish';
  }

  goBack() {
    this.location.back();
  }

}
