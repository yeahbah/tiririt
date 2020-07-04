import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { TiriritPostService, NewOrUpdatePostModel } from '../core/tiririt-post.service';
import { BullBearLevel } from '../models/bull-bear-level';
import { finalize } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { InteractionService } from '../core/InteractionService';
import { PostModel } from '../my-feed/post-model';
import { IDefaultPostText } from '../core/default-submit-post';

@Component({
  selector: 'app-submit-post-form',
  templateUrl: './submit-post-form.component.html',
  styleUrls: ['./submit-post-form.component.css']
})
export class SubmitPostFormComponent implements OnInit {

  isBearish: boolean = false;
  isBullish: boolean = false;
  charCount: number;
  maxPostLength = 1000;
  newPostForm: FormGroup;

  @Input() dialogMode = false;
  @Input() defaultValue: IDefaultPostText = { defaultText: '' };

  // quotePost: PostModel;
  
  constructor(
    private formBuilder: FormBuilder, 
    private postService: TiriritPostService,
    private spinner: NgxSpinnerService,
    private snackBar: MatSnackBar,
    private interactionService: InteractionService) {       
  }

  initializeForm() {
    const postTextControl = new FormControl(this.defaultValue.defaultText, Validators.required);
    this.charCount = this.maxPostLength - this.defaultValue.defaultText.length;
    this.newPostForm = this.formBuilder.group({
      postText: postTextControl,    
    });
  }

  ngOnInit(): void {    
    this.initializeForm();    
  }

  submit() {
    this.spinner.show();
    const value = this.newPostForm.get("postText").value;

    let bullBearLevel = BullBearLevel.neutral;
    if (this.isBearish) {
      bullBearLevel = BullBearLevel.veryBearish;
    }

    if (this.isBullish) {
      bullBearLevel = BullBearLevel.veryBullish;
    }

    const newPost = {
      postText: value,
      bullBearLevel: bullBearLevel
    };

    if (this.defaultValue.quotePost) {
      const postDate = this.defaultValue.quotePost.postDate;
      
      // maybe this could be wrapped with a custom tag, e.g. <RESPOST></RESPOST>
      // for rendering flexibility
      newPost.postText += `<blockquote>@${this.defaultValue.quotePost.userName} said: <br>${this.defaultValue.quotePost.postText}</blockquote>`;
    }

    this.postService.submitPost(newPost)
      .pipe(finalize(() => {
        this.reset();  
        this.interactionService.sendMessage('RELOAD');
        this.spinner.hide();       
        this.openSnackBar() ;
      }))
      .subscribe();
  }

  reset() {    
    this.newPostForm.reset();            
    this.isBullish = false;
    this.isBearish = false;
    this.charCount = this.maxPostLength;    
  }

  bearishClick() {
    this.isBearish = !this.isBearish;
    this.isBullish = false;
    console.log(this.isBearish);
  }

  bullishClick() {
    this.isBullish = !this.isBullish;
    this.isBearish = false;    
  }

  onKeyUp(event: any) {
    this.charCount = this.maxPostLength - event.target.value.length;
  }

  openSnackBar() {
    //TODO random message
    this.snackBar.open('Your message was posted!', '', {
      duration: 2000,
      horizontalPosition: 'center',
      verticalPosition: 'top'
    });
  }
}
