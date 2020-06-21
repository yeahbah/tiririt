import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
    
    constructor(private authService: AuthService) {

    }
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const accessToken = this.authService.getAccessToken();
        return this.processRequestWithToken(accessToken, req, next);
    }

    private processRequestWithToken(token, request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
        if (!!token && this.isSameOriginUrl(request)) {
            // console.log(token);
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }

        return next.handle(request);
    }

    private isSameOriginUrl(req: any): boolean {
        return true;
        if (req.url.startsWith(`${window.location.origin}/`)) {
            return true;
        }

        if (req.url.startsWith(`//${window.location.host}/`)) {
            return true;
        }

        if (/^\/[^\/].*/.test(req.url)) {
            return true;
        }

        return false;
    }

}