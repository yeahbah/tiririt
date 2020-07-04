import { Component, OnInit, Input, ViewChild, ViewChildren } from '@angular/core';
import { PostModel } from 'src/app/my-feed/post-model';
import { TiriritPostService } from 'src/app/core/tiririt-post.service';
import { PagingParam } from 'src/app/core/paging-params';
import { finalize } from 'rxjs/operators';
import { IPagingResultEnvelope } from 'src/app/core/PagingResultEnvelope';
import { ReplyFormComponent } from '../reply-form/reply-form.component';
import { InteractionService } from 'src/app/core/InteractionService';

@Component({
  selector: 'app-response-comments',
  templateUrl: './response-comments.component.html',
  styleUrls: ['./response-comments.component.css']
})
export class ResponseCommentsComponent implements OnInit {

  panelOpenState = false;
  spinnerHidden = false;
  headerHeight = '25px';
  @Input() post: PostModel;
  replies: IPagingResultEnvelope<PostModel>;

  @ViewChildren(ReplyFormComponent)
  replyFormComponent: ReplyFormComponent[];

  @Input() postData: PostModel;
  replyFormVisible = false;

  constructor(
    private interactionService: InteractionService,
    private postService: TiriritPostService) { }

  ngOnInit(): void {
    this.interactionService.commentPostedMessage$
      .subscribe(comment => {
        if (!this.replies) return;
        this.replies.data.push(comment);
      });
  }

  afterExpand() {
    if (this.replies) return;
    this.spinnerHidden = false;
    const paging = new PagingParam()
    paging.sortColumn = 'postDate';
    paging.sortOrder = 'asc';
    this.postService.getPostReponses(this.post.postId, paging)
      .pipe(
        finalize(() => {
          this.spinnerHidden = true;
        })        
      )
      .subscribe(result => {
        this.replies = result;
      });
  }

  showReplyForm(commentId: number) {
    //this.replyFormComponent.formVisible = true;    
    const replyForm = this.replyFormComponent.find(x => {
      return x.comment.postId == commentId
    });
    replyForm.formVisible = true;
    console.log(replyForm);
  }

  like(comment: PostModel) {
    comment.likeCount++;
  }

}
