import { BaseService } from '../shared/base.service';
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from '../my-feed/post-model';
import { retry, catchError } from 'rxjs/operators';
import { BullBearLevel } from '../models/bull-bear-level';
import { IPagingResultEnvelope } from './PagingResultEnvelope';
import { PagingParam } from './paging-params';

@Injectable({
    providedIn: 'root'
})
export class TiriritPostService extends BaseService {

    constructor(
        @Inject('API_URL') private apiUrl: string,
        private http: HttpClient) {        
            super();
    }

    submitPost(postModel: NewOrUpdatePostModel): Observable<PostModel> {
        const url = `${this.apiUrl}/Post`;
        return this.http.post<PostModel>(url, JSON.stringify(postModel))
            .pipe(
                //retry(3),
                catchError(this.handleError)
            );
    }

    getPostReponses(postId: number, pagingParam: PagingParam): Observable<IPagingResultEnvelope<PostModel>> {
        const url = `${this.apiUrl}/Post/${postId}/responses`;
        const params = new HttpParams()
            .set('pageIndex', pagingParam.pageIndex.toString())
            .set('pageSize', pagingParam.pageSize.toString())
            .set('sortColumn', pagingParam.sortColumn)
            .set('sortOrder', pagingParam.sortOrder);
        return this.http.get<IPagingResultEnvelope<PostModel>>(url, { params: params })
            .pipe(
                catchError(this.handleError)
            );
    }

    getPost(postId: number): Observable<PostModel> {
        const url = `${this.apiUrl}/Post/${postId}`;
        return this.http.get<PostModel>(url)
            .pipe(
                catchError(this.handleError)
            );
    }

    postComment(postId: number, postText: string): Observable<PostModel> {
        const url = `${this.apiUrl}/Post/${postId}/comment`;
        return this.http.post<PostModel>(url, JSON.stringify(postText))
            .pipe(
                catchError(this.handleError)
            );
    }
}

export interface NewOrUpdatePostModel {
    postText: string;
    bullBearLevel: BullBearLevel;
}