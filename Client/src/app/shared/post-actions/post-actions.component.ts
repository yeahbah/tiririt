import { Component, OnInit, Input } from '@angular/core';
import { PostModel } from 'src/app/my-feed/post-model';

@Component({
  selector: 'app-post-actions',
  templateUrl: './post-actions.component.html',
  styleUrls: ['./post-actions.component.css']
})
export class PostActionsComponent implements OnInit {

  @Input() originalPost: PostModel;
  @Input() commentPost: PostModel;
  constructor() { }

  ngOnInit(): void {
  }

}
