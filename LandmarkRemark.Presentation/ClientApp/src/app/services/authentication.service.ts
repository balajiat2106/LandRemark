import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLogin } from '../SharedModels/UserLogin';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  Login(userLogin: UserLogin) {
    return this.http.post(this.baseUrl + "api/auth/", userLogin);
  }
}
