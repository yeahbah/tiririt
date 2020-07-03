import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from './post-model';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PagingParam } from '../core/paging-params';
import { ɵangular_packages_platform_browser_platform_browser_j } from '@angular/platform-browser';

export enum FeedType {
  UserFeed,
  TrendingFeed,
  MentionsFeed,
  WatchListFeed,
  SubscriptionFeed
}

export class FeedParam {
  feedType: FeedType;
  paging: PagingParam;
}

@Injectable({
  providedIn: 'root'
})
export class MyFeedService extends BaseService{

  constructor(
    @Inject('API_URL') private apiUrl: string,
    private http: HttpClient
  ) { 
    super();
  }

  getFeed(feedParam: FeedParam): Observable<IPagingResultEnvelope<PostModel>> {
    switch(feedParam.feedType) {
      case FeedType.UserFeed: 
        return this.getMyFeed(feedParam.paging);
      
      case FeedType.MentionsFeed:
        return this.getMentionsFeed(feedParam.paging);

      case FeedType.SubscriptionFeed:
        return this.getSubscriptionFeed(feedParam.paging);

      case FeedType.WatchListFeed:
        return this.getWatchlistFeed(feedParam.paging);

    }
  }

  getMyFeed(paging: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed`;  
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: paging.toHttpParams()})
      .pipe(
        catchError(this.handleError)
      );
  }

  getTrendingFeed(paging: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Public/trending`;    
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: paging.toHttpParams() })
      .pipe(
        catchError(this.handleError)
      );
  }

  getMentionsFeed(paging: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/mentions`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: paging.toHttpParams() })
      .pipe(
        catchError(this.handleError)
      );
  }

  getWatchlistFeed(paging: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/watchlist`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: paging.toHttpParams() })
      .pipe(
        catchError(this.handleError)
      );
  }  

  getSubscriptionFeed(pagingParam: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/subscription`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: pagingParam.toHttpParams() })
      .pipe(
        catchError(this.handleError)
      );
  }  
}
