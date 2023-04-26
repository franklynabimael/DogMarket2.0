import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

import { Subject } from 'rxjs/internal/Subject';
import { LogingDTO } from '../interfaces/logingdto';
import { Logingresponse } from '../interfaces/responses/logingresponse';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private urlApi = `https://localhost:7242/api/users`;
  private authChangeSub = new Subject<boolean>();
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {}

  getUsers() {
    return this.http.get(this.urlApi);
  }
  postLoging(body: LogingDTO) {
    return this.http.post<Logingresponse>(`${this.urlApi}/loging`, body);
  }

  postRegister() {
    return this.http.post(`${this.urlApi}/register`, '');
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  };

  public logout = () => {
    localStorage.removeItem('token');
    this.sendAuthStateChangeNotification(false);
  };

  public isUserAuthenticated = (token: string): boolean => {
    return Boolean(token && !this.jwtHelper.isTokenExpired(token));
  };

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem('token');
    const decodedToken = this.jwtHelper.decodeToken(token!);
    const role =
      decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    return role === 'Admin';
  };
}
