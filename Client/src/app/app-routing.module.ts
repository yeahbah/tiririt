import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { TagComponent } from './tag/tag.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthGuard } from './core/authentication/auth.guard';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { SearchComponent } from './search/search.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'post/:postId', component: PostDetailsComponent },
  { path: 'stock/:symbol', component: StockComponent },
  { path: 'tag/:tag', component: TagComponent },
  { path: 'auth-callback', component: AuthCallbackComponent },
  { path: 'search/:searchText', component: SearchComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent }                 
  // { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
