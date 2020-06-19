import { Routes, Route } from '@angular/router';
import { HomeShellComponent } from './home-shell.component';
import { Injectable } from '@angular/core';
import { AuthGuard } from 'src/app/core/authentication/auth.guard';

@Injectable({
    providedIn: 'root'
})
export class HomeShell {
    static childRoutes(routes: Routes): Route {
        return {
            path: 'user',
            component: HomeShellComponent,
            children: routes,
            // canActivate: [AuthGuard],
            data: { reuse: true }
        };
    }    
}