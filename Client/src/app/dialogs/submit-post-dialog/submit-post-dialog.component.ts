import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { InteractionService } from 'src/app/core/InteractionService';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubmitPostFormComponent } from 'src/app/submit-post-form/submit-post-form.component';

@Component({
  selector: 'app-submit-post-dialog',
  templateUrl: './submit-post-dialog.component.html',
  styleUrls: ['./submit-post-dialog.component.css']
})
export class SubmitPostDialogComponent implements OnInit {

  @ViewChild(SubmitPostFormComponent)
  submitForm: SubmitPostFormComponent;

  constructor(@Inject(MAT_DIALOG_DATA) public defaultText: string) { 
    
  }

  ngOnInit(): void {
    
  }

}
