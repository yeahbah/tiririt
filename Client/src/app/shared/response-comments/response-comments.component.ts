import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { PostModel } from 'src/app/my-feed/post-model';
import { TiriritPostService } from 'src/app/core/tiririt-post.service';
import { PagingParam } from 'src/app/core/paging-params';
import { finalize } from 'rxjs/operators';
import { IPagingResultEnvelope } from 'src/app/core/PagingResultEnvelope';
import { ReplyFormComponent } from '../reply-form/reply-form.component';

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

  @ViewChild(ReplyFormComponent)
  replyFormComponent: ReplyFormComponent;

  @Input() postData: PostModel;
  replyFormVisible = false;

  constructor(private postService: TiriritPostService) { }

  ngOnInit(): void {
    
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

  showReplyForm() {
    this.replyFormComponent.formVisible = true;
  }

}
