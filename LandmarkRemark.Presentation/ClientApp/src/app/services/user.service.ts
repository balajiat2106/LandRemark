import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../SharedModels/user';

@Injectable()
export class UserService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll() {
    return this.http.get<User[]>(`/users`);
  }

  getByUserName(userName: string) {
    return this.http.get(this.baseUrl + "api/user/" + userName);
  }

  register(user: User) {
    return this.http.post(this.baseUrl + "api/user/", user);
  }
  
  delete(UserName: string) {
    return this.http.delete(`/users/` + UserName);
  }
}
