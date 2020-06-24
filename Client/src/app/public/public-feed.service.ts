import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PostModel } from '../my-feed/post-model';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { Observable } from 'rxjs';
import { IStockModel } from './models/stock-model';
import { IStockQuoteModel } from './models/stock-quote-model';

@Injectable({
  providedIn: 'root'
})
export class PublicFeedService extends BaseService {

  constructor(
    @Inject('API_URL') private apiUrl: string,
    private http: HttpClient) { 
      super();
    }

  getPostsByTag(tag: string): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Public/tag/${tag}`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  getPostsByStock(symbol: string): Observable<IPagingResultEnvelope<PostModel>> {
    const url = `${this.apiUrl}/Public/stock/${symbol}`;
    return this.http.get<IPagingResultEnvelope<PostModel>>(url)
      .pipe(
        catchError(this.handleError)
      );      
  }

  getStockInfo(symbol: string): Observable<IStockModel> {
    const url = `${this.apiUrl}/Stock/${symbol}`;
    return this.http.get<IStockModel>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  getStockQuote(symbol: string): Observable<IStockQuoteModel[]> {
    const url = `${this.apiUrl}/StockQuote/${symbol}/eod`;
    return this.http.get<IStockQuoteModel[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  getStockEodChart(symbol: string): Observable<any[]> {
    const url = `${this.apiUrl}/StockQuote/${symbol}/eod/chart`;
    return this.http.get<any[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }
}
