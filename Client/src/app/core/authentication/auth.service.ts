import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { BehaviorSubject, Observable } from 'rxjs'; 

import { BaseService } from "../../shared/base.service";
import { ConfigService } from '../../shared/config.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService  {

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private manager = new UserManager(getClientSettings(this.baseUrl));
  private user: User | null;

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient, 
    private configService: ConfigService) { 
    super();     
    
    this.manager.getUser().then(user => { 
      this.user = user;      
      this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  login() { 
    return this.manager.signinRedirect();   
  }

  silentSignin() {
    console.log(this.user.access_token);
    this.manager.signinSilentCallback();
  }

  async completeAuthentication() {
      this.user = await this.manager.signinRedirectCallback();      
      // console.log(`The user: ${this.user}`);
      this._authNavStatusSource.next(this.isAuthenticated());      
  }  

  getAccessToken() {    
    return this.user != null ? this.user.access_token : '';
  }
  
  register(userRegistration: any) {    
    return this.http.post(this.configService.authApiURI + '/Account/Register', userRegistration).pipe(catchError(this.handleError));
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get name(): string {
    return this.user != null ? this.user.profile.preferred_username : '';
  }

  async signout() {
    await this.manager.signoutRedirect();
  }
}

export function getClientSettings(baseUrl: string): UserManagerSettings {
  return {
      authority: `https://localhost/tiririt`,
      client_id: 'tiririt',
      redirect_uri: `${baseUrl}auth-callback`,
      post_logout_redirect_uri: `${baseUrl}index.html`,
      response_type:"code",
      scope:"openid profile IdentityServerApi",
      filterProtocolClaims: true,
      loadUserInfo: true,
      automaticSilentRenew: true,
      client_secret: "secret",
      silent_redirect_uri: `${baseUrl}silent-refresh.html`
  };
}