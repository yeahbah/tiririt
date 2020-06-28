import { Component, OnInit, Input } from '@angular/core';
import { PostModel } from 'src/app/my-feed/post-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TiriritPostService } from 'src/app/core/tiririt-post.service';
import { InteractionService } from 'src/app/core/InteractionService';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-reply-form',
  templateUrl: './reply-form.component.html',
  styleUrls: ['./reply-form.component.css']
})
export class ReplyFormComponent implements OnInit {

  @Input() post: PostModel;
  @Input() cancelButtonVisible = false;
  @Input() formVisible = true;

  maxReplyLength = 1000;
  replyForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private postService: TiriritPostService,
    private interactionService: InteractionService) { 
      this.replyForm = this.formBuilder.group({
        postText: ['', Validators.required]
      });
  }

  ngOnInit(): void {
    this.resetForm();
  }

  submit() {
    const value = this.replyForm.get('postText').value;
    this.postService.postComment(this.post.postId, value)
      .pipe(
        finalize(() => {
          this.openSnackBar()      
        })
      )
      .subscribe(result => {
        this.resetForm();
        this.interactionService.sendCommentPostedMessage(result);
      });
  }

  resetForm() {
    this.replyForm.get('postText').setValue(`@${this.post.userName} `);
  }

  onKeyUp(event: any) {

  }

  openSnackBar() {
    //TODO random message
    this.snackBar.open('Your message was posted!', '', {
      duration: 2000,
      horizontalPosition: 'center',
      verticalPosition: 'top'
    });
  }

  hideForm() {
    this.formVisible = false;
  }

}
