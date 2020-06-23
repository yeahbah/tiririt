import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagingResultEnvelope } from '../core/PagingResultEnvelope';
import { PostModel } from '../my-feed/post-model';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TagFeedService extends BaseService {

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
}
