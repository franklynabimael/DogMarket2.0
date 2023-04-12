import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Subject } from 'rxjs/internal/Subject';
import { environment } from '../../environments/environment';
import { LogingDTO } from '../interfaces/logingdto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private urlApi = `https://localhost:7242/api/users`;
  private authChangeSub = new Subject<boolean>();

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get(this.urlApi);
  }

  postLoging(body: LogingDTO) {
    return this.http.post(`${this.urlApi}/loging`, body);
  }

  postRegister() {
    return this.http.post(`${this.urlApi}/register`, '');
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  };
}
