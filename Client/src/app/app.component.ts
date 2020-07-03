import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Client';

  constructor(
    private router: Router,
    private iconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer) {
      // this.iconRegistry.addSvgIcon('bearish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bear.svg'));
      // this.iconRegistry.addSvgIcon('bullish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bull-face.svg'));
      // this.iconRegistry.addSvgIcon('like', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/like.svg'));
  }
  ngOnInit(): void {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
          return;
      }
      window.scrollTo(0, 0)
    });
  }


}


