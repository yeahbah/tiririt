import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { WatchlistModel } from './watchlist-model';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/base.service';
import { catchError, retry } from 'rxjs/operators';
import { PagingParam } from '../core/paging-params';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { StockViewModel } from '../models/stock-view-model';
import { IStockModel } from '../public/models/stock-model';

@Injectable({
  providedIn: 'root'
})
export class WatchlistService extends BaseService {

  constructor(
    private http: HttpClient,
    @Inject('API_URL') private apiUrl: string) { 
      super();
  }

  controllerName = 'WatchList';

  getWatchList(pagingParam: PagingParam): Observable<IPagingResultEnvelope<IStockModel>> {
    const url = `${this.apiUrl}/${this.controllerName}`;     
    const params = new HttpParams()
      .set('pageIndex', pagingParam.pageIndex.toString())
      .set('pageSize', pagingParam.pageSize.toString())
      .set('sortColumn', pagingParam.sortColumn != null ? pagingParam.sortColumn : '')
      .set('sortOrder', pagingParam.sortOrder != null ? pagingParam.sortOrder : '');

    return this.http.get<IPagingResultEnvelope<IStockModel>>(url, { params: params });
  }

  addStockToWatchList(watchListId: number, stockSymbols: string[]): Observable<WatchlistModel> {
    const url = `${this.apiUrl}/${this.controllerName}/${watchListId}/stocks`;
    return this.http.put<WatchlistModel>(url, stockSymbols)
      .pipe(
        retry(3),
        catchError(this.handleError));
  }

  deleteStock(watchListId: number, stockSymbol: string): Observable<WatchlistModel> | any {
    const url = `${this.apiUrl}/${this.controllerName}/${watchListId}/stocks/${stockSymbol}`;
    return this.http.delete<WatchlistModel>(url)
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }
}
