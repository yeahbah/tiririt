import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }

  get authApiURI() {
      return 'https://localhost/tiririt/api';
  }    
 
  get resourceApiURI() {
      return 'https://localhost/tiririt/api';
  }  

}
