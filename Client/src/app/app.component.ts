import { Component } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';

  constructor(private iconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer) {
      this.iconRegistry.addSvgIcon('bearish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bear.svg'));
      this.iconRegistry.addSvgIcon('bullish', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/bull-face.svg'));
      this.iconRegistry.addSvgIcon('like', this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/like.svg'));
  }
}


