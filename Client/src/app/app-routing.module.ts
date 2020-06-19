import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { UserComponent } from './user/user.component';
import { TagComponent } from './tag/tag.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthGuard } from './core/authentication/auth.guard';
import { LoginComponent } from './account/login/login.component';


const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'post/:postId', component: PostDetailsComponent },
  { path: 'stock/:symbol', component: StockComponent },
  { path: 'user/:username', component: UserComponent },
  { path: 'tag/:tag', component: TagComponent },
  { path: 'auth-callback', component: AuthCallbackComponent },
  // { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
