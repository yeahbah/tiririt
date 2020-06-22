import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class InteractionService {

    private messageSource = new Subject<string>();

    reloadMessage$ = this.messageSource.asObservable();

    constructor() {

    }

    sendMessage(message: string) {
        this.messageSource.next(message);
    }
}