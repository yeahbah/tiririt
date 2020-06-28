import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TiriritPostService } from '../core/tiririt-post.service';
import { PostModel } from '../my-feed/post-model';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { InteractionService } from '../core/InteractionService';
import { PagingParam } from '../core/paging-params';
import { ReplyFormComponent } from '../shared/reply-form/reply-form.component';

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
  
  constructor(
    private postService: TiriritPostService,
    private interactionService: InteractionService) { }

  ngOnInit(): void {            
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

    this.postService.getPostReponses(this.postData.postId, pagingParam)
    .subscribe(result => {
        this.postResponses = result;
    });
  }

  showReplyForm() {
    this.replyFormComponent.formVisible = true;
  }

}
