import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { MatMenuTrigger } from '@angular/material/menu';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { SubmitPostFormComponent } from 'src/app/submit-post-form/submit-post-form.component';
import { SubmitPostDialogComponent } from 'src/app/dialogs/submit-post-dialog/submit-post-dialog.component';

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
    private router: Router,
    private authService: AuthService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$
      .subscribe(status => { 
        this.isAuthenticated = status,
        this.name = this.authService.name; 
      });            
  }

  async signout() {
    await this.authService.signout();
  }

  register() {
    this.router.navigate(['/register']);
  }

  login() {
    this.authService.login();
  }  

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }  

  openMenu() {
    this.trigger.openMenu();
  }

  search(searchText: string) {
    this.router.navigate(['/search', searchText])
  }

  newPost() {
    this.dialog.open(SubmitPostDialogComponent, { data: '' });
  }
}
