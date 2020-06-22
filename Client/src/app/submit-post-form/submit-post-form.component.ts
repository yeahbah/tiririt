import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { SubmitPostService, NewOrUpdatePostModel } from './submit-post.service';
import { BullBearLevel } from '../models/bull-bear-level';
import { finalize } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

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
  newPostForm = this.formBuilder.group({
    postText: ['', Validators.required],    
  });
  

  constructor(
    private formBuilder: FormBuilder, 
    private postService: SubmitPostService,
    private spinner: NgxSpinnerService,
    private snackBar: MatSnackBar) { 

  }

  ngOnInit(): void {
    this.reset();
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
    console.log(newPost);
    this.postService.submitPost(newPost)
      .pipe(finalize(() => {
        this.reset();
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
