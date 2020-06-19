import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../../../core/authentication/auth.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {

  name: string;
  isAuthenticated: boolean;
  subscription:Subscription;

  constructor(
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.subscription = this.authService.authNavStatus$.subscribe(status => this.isAuthenticated = status);
    this.name = this.authService.name;
    if (this.isAuthenticated) {
      this.router.navigate(['/user/home']);
    }

  } 

   async signout() {
    await this.authService.signout();     
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }

  register() {
    this.router.navigate(['/register']);
  }

  login() {
    this.authService.login();
  }
}
