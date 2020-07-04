import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { PostModel } from 'src/app/my-feed/post-model';
import { MatDialog } from '@angular/material/dialog';
import { PostDetailsDialogComponent } from 'src/app/dialogs/post-details-dialog/post-details-dialog.component';
import { Router } from '@angular/router';
import { ReplyFormComponent } from '../reply-form/reply-form.component';
import { IPagingResultEnvelope } from 'src/app/core/PagingResultEnvelope';
import { InteractionService } from 'src/app/core/InteractionService';
import { SubmitPostDialogComponent } from 'src/app/dialogs/submit-post-dialog/submit-post-dialog.component';
// import { MatLinkPreviewService } from '@angular-material-extensions/link-preview';

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.css']
})
export class PostItemComponent implements OnInit {

  @Input() post: PostModel;
  replies: IPagingResultEnvelope<PostModel>;

  @ViewChild(ReplyFormComponent)
  replyFormComponent: ReplyFormComponent;

  constructor(
    private interactionService: InteractionService,
    private dialog: MatDialog, 
    private router: Router) { }

  ngOnInit(): void {
    this.interactionService.commentPostedMessage$
      .subscribe(comment => {
        this.post.commentCount++;
      })
  }

  isBullish(bullBearLevel: any): boolean {
    return bullBearLevel == 'VeryBullish';
  }

  isBearish(bullBearLevel: any): boolean {
    return bullBearLevel == 'VeryBearish';
  }

  showReplyDialog(post: PostModel) {
    this.dialog.open(PostDetailsDialogComponent, {
      data: post
    });
  }

  goToPostDetails(postId: number) {
    this.router.navigate(['/post/', postId]);
  }

  showReplyForm() {
    this.replyFormComponent.formVisible = true;
  }

  like() {
    this.post.likeCount++;
  }

  repost() {
    this.dialog.open(SubmitPostDialogComponent, { data: { defaultText: '', quotePost: this.post } });
  }
}

