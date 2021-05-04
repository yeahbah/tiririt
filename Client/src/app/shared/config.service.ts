import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }

  get authApiURI() {
      //return 'https://localhost/tiririt/api';
      return 'https://localhost:5001/api';
  }    
 
  get resourceApiURI() {
      //return 'https://localhost/tiririt/api';
      return 'https://localhost:5001/api';
  }  

}
