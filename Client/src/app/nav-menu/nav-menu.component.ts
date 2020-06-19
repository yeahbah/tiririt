import { Component } from '@angular/core';
import { AuthService } from '../core/authentication/auth.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent 
{
    isExpanded = false;
    isAuthenticated = false;
    subscription: Subscription;
    name: string;

    constructor(private authService: AuthService) {

    }

    ngOnInit() {
        this.subscription = this.authService.authNavStatus$
            .subscribe(status => { 
                this.isAuthenticated = status;
                console.log(`isAuthenticated: ${status}`);
                this.name = this.authService.name;        
            });        
    }

    async signOut() {
        await this.authService.signout();
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
