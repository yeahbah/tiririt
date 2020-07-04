import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PostModel } from '../my-feed/post-model';
import { PublicFeedService } from '../public/public-feed.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../core/authentication/auth.service';
import { Subscription } from 'rxjs';
import { SubmitPostDialogComponent } from '../dialogs/submit-post-dialog/submit-post-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { InteractionService } from '../core/InteractionService';
import { PagingParam } from '../core/paging-params';
import { finalize } from 'rxjs/internal/operators/finalize';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})
export class TagComponent implements OnInit {

  tagFeed: IPagingResultEnvelope<PostModel>;
  paging = new PagingParam();
  isAuthenticated: boolean = false;
  subscription: Subscription;
  tag: string;
  spinnerHidden = false;
  
  constructor(
    private interactionService: InteractionService,
    private dialog: MatDialog,
    private authService: AuthService,
    private tagFeedService: PublicFeedService, 
    private route: ActivatedRoute,
    private location: Location) { 
      this.paging.sortColumn = 'postDate';
      this.paging.sortOrder = 'desc';
    }

  ngOnInit(): void {    
    this.route.params.subscribe(params => {
      this.tag = params['tag'];
      this.reload();
      this.interactionService.sendDefaultPostTextMessage({ defaultText: '#' + this.tag });
    });

    this.subscription = this.authService.authNavStatus$
      .subscribe(status => { 
        this.isAuthenticated = status
      });            

    this.interactionService.reloadMessage$.subscribe(message => {
      if (message == 'RELOAD') {
        this.reload();
      }
    });
      
  }

  reload() {
    this.spinnerHidden = false;
    this.tagFeedService.getPostsByTag(this.tag, this.paging)
      .pipe(finalize(() => {
        this.spinnerHidden = true;
      }))
      .subscribe(result => {        
        this.tagFeed = result;
      });

    this.tag = this.route.snapshot.paramMap.get('tag');
  }

  goBack() {
    this.location.back();
  }

  createPost() {
    this.dialog.open(SubmitPostDialogComponent, { data: { defaultText : `#${this.tag}` } });
  }

  onScroll() {
    console.log('hello');
  }

  loadNextPage() {
    if (!this.spinnerHidden) return;
    if (!this.tagFeed) {
      this.reload();
      return;
    }
    this.spinnerHidden = false;
    this.paging.pageIndex++;
    this.tagFeedService.getPostsByTag(this.tag, this.paging)
      .pipe(finalize(() => {
        this.spinnerHidden = true;
      }))
      .subscribe(result => {
        for(let i = 0; i < result.data.length; i++){
          this.tagFeed.data.push(result.data[i]);
        }
      });
  }

}
