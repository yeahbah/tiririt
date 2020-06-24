import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { WatchlistModel } from '../watchlist/watchlist-model';

@Injectable({
    providedIn: 'root'
})
export class InteractionService {

    private messageSource = new Subject<string>();
    private watchListMessageSource = new Subject<WatchlistModel>();

    reloadMessage$ = this.messageSource.asObservable();
    reloadWatchListMessage$ = this.watchListMessageSource.asObservable();

    constructor() {

    }

    sendMessage(message: string) {
        this.messageSource.next(message);
    }

    reloadWatchList(message: WatchlistModel) {
        this.watchListMessageSource.next(message);
    }
}