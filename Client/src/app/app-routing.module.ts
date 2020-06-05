import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { UserComponent } from './user/user.component';
import { TagComponent } from './tag/tag.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'post/:postId', component: PostDetailsComponent },
  { path: 'stock/:symbol', component: StockComponent },
  { path: 'user/:username', component: UserComponent },
  { path: 'tag/:tag', component: TagComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
