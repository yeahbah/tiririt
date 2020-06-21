import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { MatMenuTrigger } from '@angular/material/menu';

@Component({
  selector: 'app-home-header',
  templateUrl: './home-header.component.html',
  styleUrls: ['./home-header.component.css']
})
export class HomeHeaderComponent implements OnInit {

  @ViewChild(MatMenuTrigger) trigger : MatMenuTrigger;

  name: string;
  isAuthenticated: boolean;
  isShown: boolean = false;
  subscription: Subscription;

  constructor(
    private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$
      .subscribe(status => this.isAuthenticated = status);
    this.name = this.authService.name; 
  }

  async signout() {
    await this.authService.signout();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }  

  openMenu() {
    this.trigger.openMenu();
  }

}
