import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from './post-model';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PagingParam } from '../core/paging-params';

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

  getFeed(feedParam: FeedParam) {

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

  getMentionsFeed(): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/mentions`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  getWatchlistFeed(): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/watchlist`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
      .pipe(
        catchError(this.handleError)
      );
  }  

  getSubscriptionFeed(): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed/subscription`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
      .pipe(
        catchError(this.handleError)
      );
  }  
}
