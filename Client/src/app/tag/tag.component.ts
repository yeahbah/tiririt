import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PostModel } from '../my-feed/post-model';
import { TagFeedService } from './tag-feed.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../core/authentication/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})
export class TagComponent implements OnInit {

  tagFeed: IPagingResultEnvelope<PostModel>;
  isAuthenticated: boolean = false;
  subscription: Subscription;
  tag: string;
  
  constructor(
    private authService: AuthService,
    private tagFeedService: TagFeedService, 
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$
      .subscribe(status => { 
        this.isAuthenticated = status
      });            

    this.tag = this.route.snapshot.paramMap.get('tag');
    this.tagFeedService.getPostsByTag(this.tag)
      .subscribe(result => {
        this.tagFeed = result;
      });
  }

  goBack() {
    this.location.back();
  }

}
