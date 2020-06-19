import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WatchlistModel } from './watchlist-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WatchlistService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { 

  }

  getWatchList(): Observable<WatchlistModel> {
    const url = 'https://localhost/tiririt/api/v1/WatchList';    
    return this.http.get<WatchlistModel>(url);
  }
}
