import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  getByUserName(userName: string) {
    return this.http.get(this.baseUrl + "api/user/"+ userName);
  }

  public login(loginData, callback: () => void) {
    let data = "grant_type=password&username=" + loginData.Email + "&password=" + loginData.Password;

    let options = new RequestOptions();
    options.headers = new Headers();
    options.headers.append('Content-Type', 'application/x-www-form-urlencoded');

    //The apiend point is the token end point
    this.chttp.postObservable(`${this.config.apiEndpoint}/token`, data, options).subscribe((response) => {
      //once the token obtained set the local variables
      this.authentication.isAuth = true;
      this.authentication.userName = response.userName;
      this.authentication.token = response.access_token;
      this.authentication.token_type = response.token_type;

      //if the login form has remember me enabled we need to store the token in cookie with expiry data as current date + expiry of the token in seconds
      if (loginData.RememberMe) {
        var date = new Date();
        date.setSeconds(date.getSeconds + response.expires_in);
        this._cookieService.putObject('authorizationData', this.authentication, { expires: date })
      }
      callback();
    });
  }
}
