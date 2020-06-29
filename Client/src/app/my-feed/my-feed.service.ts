import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from './post-model';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PagingParam } from '../core/paging-params';

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

  getMyFeed(paging: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Feed`;
    const params = new HttpParams()
            .set('pageIndex', paging.pageIndex.toString())
            .set('pageSize', paging.pageSize.toString())
            .set('sortColumn', paging.sortColumn)
            .set('sortOrder', paging.sortOrder);
    return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: params})
      .pipe(
        catchError(this.handleError)
      );
  }

  getTrendingFeed(): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Public/trending`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
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
