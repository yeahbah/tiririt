import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgMaterialModule } from './ngmaterial/ngmaterial.module';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { WatchlistService } from './watchlist/watchlist.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SubmitPostFormComponent } from './submit-post-form/submit-post-form.component';
import { FeedContainerComponent } from './feed-container/feed-container.component';
import { MyFeedService } from './my-feed/my-feed.service';
import { NewsFeedComponent } from './news-feed/news-feed.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { TagComponent } from './tag/tag.component';
import { StripHtmlPipe } from './pipes/stirp-html-pipe';
import { SharedModule } from './shared/shared.module';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthService } from './core/authentication/auth.service';
import { AuthGuard } from './core/authentication/auth.guard';
import { AuthorizeInterceptor } from './core/authentication/authorize.interceptor';
import { ApiCallInterceptor } from './core/api-call.interceptor';
import { TiriritPostService } from './core/tiririt-post.service';
import { SearchComponent } from './search/search.component';
import { HomeHeaderComponent } from './page-headers/home-header/home-header.component';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { PublicFeedService } from './public/public-feed.service';
import { SubmitPostDialogComponent } from './dialogs/submit-post-dialog/submit-post-dialog.component';
import { PostDetailsDialogComponent } from './dialogs/post-details-dialog/post-details-dialog.component';
import { PostResponseComponent } from './post-response/post-response.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { SideNavMenuComponent } from './side-nav-menu/side-nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthCallbackComponent,
    NavMenuComponent,
    HomeComponent,
    WatchlistComponent,
    SubmitPostFormComponent,
    FeedContainerComponent,
    NewsFeedComponent,
    StripHtmlPipe,
    PostDetailsComponent,
    StockComponent,
    TagComponent,
    SearchComponent,
    HomeHeaderComponent,
    RegisterComponent,
    LoginComponent,
    SubmitPostDialogComponent,
    PostDetailsDialogComponent,
    PostResponseComponent,
    SideNavMenuComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,    
    NgMaterialModule,
    InfiniteScrollModule,
    FormsModule,    
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [    
    AuthGuard,
    AuthService,
    WatchlistService, 
    MyFeedService,
    TiriritPostService,
    PublicFeedService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: ApiCallInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
