import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgMaterialModule } from './ngmaterial/ngmaterial.module';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { WatchlistService } from './watchlist/watchlist.service';
import { HttpClientModule } from '@angular/common/http';
import { SubmitPostFormComponent } from './submit-post-form/submit-post-form.component';
import { FeedContainerComponent } from './feed-container/feed-container.component';
import { MyFeedComponent } from './my-feed/my-feed.component';
import { MyFeedService } from './my-feed/my-feed.service';
import { NewsFeedComponent } from './news-feed/news-feed.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    WatchlistComponent,
    SubmitPostFormComponent,
    FeedContainerComponent,
    MyFeedComponent,
    NewsFeedComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgMaterialModule
  ],
  providers: [WatchlistService, MyFeedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
