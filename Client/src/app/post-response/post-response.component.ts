import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TiriritPostService } from '../core/tiririt-post.service';
import { PostModel } from '../my-feed/post-model';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { InteractionService } from '../core/InteractionService';
import { PagingParam } from '../core/paging-params';
import { ReplyFormComponent } from '../shared/reply-form/reply-form.component';
import { Subscription } from 'rxjs';
import { AuthService } from '../core/authentication/auth.service';

@Component({
  selector: 'app-post-response',
  templateUrl: './post-response.component.html',
  styleUrls: ['./post-response.component.css']
})
export class PostResponseComponent implements OnInit {

  @ViewChild(ReplyFormComponent)
  replyFormComponent: ReplyFormComponent;

  @Input() postData: PostModel;
  replyFormVisible = false;

  postResponses: IPagingResultEnvelope<PostModel>;
  isAuthenticated = false;
  subscription: Subscription;
  showMore = false;
  
  constructor(
    private authService: AuthService,
    private postService: TiriritPostService,
    private interactionService: InteractionService) { }

  ngOnInit(): void {      
    this.subscription = this.authService.authNavStatus$
    .subscribe(status => { 
      this.isAuthenticated = status
    });                  
    this.loadResponses();
    this.interactionService.commentPostedMessage$
      .subscribe(result => {
        this.loadResponses();
      });
  }  

  loadResponses() {
    const pagingParam = new PagingParam()
    pagingParam.sortColumn = 'postDate';
    pagingParam.sortOrder = 'desc';    

    this.postService.getPostComments(this.postData.postId, pagingParam)
    .subscribe(result => {
        this.postResponses = result;
    });
  }

  showReplyForm() {
    console.log(this.replyFormComponent);
    this.replyFormComponent.formVisible = true;
  }

  like() {
    this.postData.likeCount++;
  }
}
