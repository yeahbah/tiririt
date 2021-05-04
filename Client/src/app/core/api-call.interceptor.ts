import { HTTP_INTERCEPTORS, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable, Inject } from '@angular/core';


@Injectable({
    providedIn: 'root'
})
export class ApiCallInterceptor implements HttpInterceptor
{
    constructor(@Inject('API_URL') private apiUrl: string) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.match(this.apiUrl)?.length > 0) {                        
            req = req.clone({
                setHeaders: { 
                    'X-Requested-With': 'XMLHttpRequest', // IdentityServer will forward to a login page without this header
                    'Content-Type': 'application/json'
                }
            });
        }

        return next.handle(req);
    }
    
}