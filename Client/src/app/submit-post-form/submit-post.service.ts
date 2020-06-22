import { BaseService } from '../shared/base.service';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostModel } from '../my-feed/post-model';
import { retry, catchError } from 'rxjs/operators';
import { BullBearLevel } from '../models/bull-bear-level';

@Injectable({
    providedIn: 'root'
})
export class SubmitPostService extends BaseService {

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

}

export interface NewOrUpdatePostModel {
    postText: string;
    bullBearLevel: BullBearLevel;
}