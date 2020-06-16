import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from './post-model';

@Injectable({
  providedIn: 'root'
})
export class MyFeedService {

  constructor(
    private http: HttpClient
  ) { }

  getMyFeed(): Observable<PostModel[]> {
    const url = './assets/myfeed.json';
    return this.http.get<PostModel[]>(url);
  }
}
