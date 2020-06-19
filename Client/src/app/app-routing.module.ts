import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { TagComponent } from './tag/tag.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthGuard } from './core/authentication/auth.guard';
import { LoginComponent } from './account/login/login.component';
import { HomeShell } from './home/home-shell/home-shell.service';
import { Shell } from './account/shell/shell.service';
import { RegisterComponent } from './account/register/register.component';


const routes: Routes = [
Shell.childRoutes([
    { path: '', component: LoginComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }    
  ]),

HomeShell.childRoutes([
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] }
  ]),

  { path: 'user', component: HomeComponent },  
  { path: 'post/:postId', component: PostDetailsComponent },
  { path: 'stock/:symbol', component: StockComponent },
  { path: 'tag/:tag', component: TagComponent },
  { path: 'auth-callback', component: AuthCallbackComponent },
  // { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
