import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  getByUserName(userName: string) {
    return this.http.get(this.baseUrl + "api/user/"+ userName);
  }

  
}
