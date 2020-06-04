import { Component, OnInit, Input } from '@angular/core';
import { MatButtonToggle } from '@angular/material/button-toggle';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'app-submit-post-form',
  templateUrl: './submit-post-form.component.html',
  styleUrls: ['./submit-post-form.component.css']
})
export class SubmitPostFormComponent implements OnInit {

  // bullBearIndicator: number;
  isBearish: boolean = false;
  isBullish: boolean;

  constructor() { }

  ngOnInit(): void {
  }

  submit() {
    // console.log(this.bullBearIndicator);
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
}
