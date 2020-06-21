import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WatchlistModel } from './watchlist-model';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/base.service';
import { catchError, retry } from 'rxjs/operators';

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

  getWatchList(): Observable<WatchlistModel> {
    const url = `${this.apiUrl}/${this.controllerName}`;     
    return this.http.get<WatchlistModel>(url);
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
