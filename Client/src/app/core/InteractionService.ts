import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { WatchlistModel } from '../watchlist/watchlist-model';
import { IStockModel } from '../public/models/stock-model';
import { PostModel } from '../my-feed/post-model';
import { IDefaultPostText } from './default-submit-post';

@Injectable({
    providedIn: 'root'
})
export class InteractionService {

    private messageSource = new Subject<string>();
    private watchListMessageSource = new Subject<WatchlistModel>();
    private loadedStockMessageSource = new Subject<IStockModel>();
    private commentPostedMessageSource = new Subject<PostModel>();
    private defaultPostTextMessageSource = new Subject<IDefaultPostText>();

    // reload a page message
    reloadMessage$ = this.messageSource.asObservable();

    // add/remove stock on watchlist has been executed
    reloadWatchListMessage$ = this.watchListMessageSource.asObservable();

    // the stock page has been reloaded with a new IStockModel instance
    loadedStockMessage$ = this.loadedStockMessageSource.asObservable();

    // a new comment has been posted
    commentPostedMessage$ = this.commentPostedMessageSource.asObservable();

    defaultPostTextMessage$ = this.defaultPostTextMessageSource.asObservable();


    constructor() {

    }

    sendMessage(message: string) {
        this.messageSource.next(message);
    }

    reloadWatchList(message: WatchlistModel) {
        this.watchListMessageSource.next(message);
    }

    loadedStock(message: IStockModel) {
        this.loadedStockMessageSource.next(message);
    }

    sendCommentPostedMessage(comment: PostModel) {
        this.commentPostedMessageSource.next(comment);
    }

    sendDefaultPostTextMessage(defaultText: IDefaultPostText) {
        this.defaultPostTextMessageSource.next(defaultText);
    }
}