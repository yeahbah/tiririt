import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { WatchlistModel } from './watchlist-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WatchlistService {

  constructor(
    private http: HttpClient,
    @Inject('API_URL') private apiUrl: string) { 

  }

  getWatchList(): Observable<WatchlistModel> {
    const url = `${this.apiUrl}/WatchList`; 
    
    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('X-Requested-With', 'XMLHttpRequest');
    
    return this.http.get<WatchlistModel>(url, {headers: headers});
  }
}
