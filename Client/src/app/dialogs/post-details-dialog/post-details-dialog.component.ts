import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { PostModel } from 'src/app/my-feed/post-model';

@Component({
  selector: 'app-post-details-dialog',
  templateUrl: './post-details-dialog.component.html',
  styleUrls: ['./post-details-dialog.component.css']
})
export class PostDetailsDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public postData: PostModel) { 
  }

  ngOnInit(): void {
  }

}
