import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { TiriritPostService, NewOrUpdatePostModel } from '../core/tiririt-post.service';
import { BullBearLevel } from '../models/bull-bear-level';
import { finalize } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { InteractionService } from '../core/InteractionService';

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
  @Input() defaultValue: string = '';
  
  constructor(
    private formBuilder: FormBuilder, 
    private postService: TiriritPostService,
    private spinner: NgxSpinnerService,
    private snackBar: MatSnackBar,
    private interactionService: InteractionService) { 
  }

  initializeForm() {
    const postTextControl = new FormControl(this.defaultValue, Validators.required);
    this.charCount = this.maxPostLength - this.defaultValue.length;
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
