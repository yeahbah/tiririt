import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { InteractionService } from 'src/app/core/InteractionService';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubmitPostFormComponent } from 'src/app/submit-post-form/submit-post-form.component';
import { PostModel } from 'src/app/my-feed/post-model';
import { IDefaultPostText } from 'src/app/core/default-submit-post';

@Component({
  selector: 'app-submit-post-dialog',
  templateUrl: './submit-post-dialog.component.html',
  styleUrls: ['./submit-post-dialog.component.css']
})
export class SubmitPostDialogComponent implements OnInit {

  @ViewChild(SubmitPostFormComponent)
  submitForm: SubmitPostFormComponent;

  constructor(@Inject(MAT_DIALOG_DATA) public defaultValue: IDefaultPostText ) { 
  }

  ngOnInit(): void {
    
  }

}
