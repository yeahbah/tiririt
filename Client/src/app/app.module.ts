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
import { MyFeedComponent } from './my-feed/my-feed.component';
import { MyFeedService } from './my-feed/my-feed.service';
import { NewsFeedComponent } from './news-feed/news-feed.component';
import { LinkifyPipe } from './pipes/linkify-pipe';
import { PostDetailsComponent } from './post-details/post-details.component';
import { StockComponent } from './stock/stock.component';
import { TagComponent } from './tag/tag.component';
import { StripHtmlPipe } from './pipes/stirp-html-pipe';
import { AccountModule } from './account/account.module';
import { SharedModule } from './shared/shared.module';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthService } from './core/authentication/auth.service';
import { AuthGuard } from './core/authentication/auth.guard';
import { HomeShellModule } from './home/home-shell/home-shell.module';

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
    TagComponent    
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,    
    NgMaterialModule,
    FormsModule,    
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AccountModule,
    SharedModule,
    HomeShellModule
  ],
  providers: [    
    AuthGuard,
    AuthService,
    WatchlistService, 
    MyFeedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
