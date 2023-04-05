import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserServiceService {
  private urlApi = `${environment.urlApi}/users`;

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get(this.urlApi);
  }

  Loging() {
    return this.http.post(`${this.urlApi}/loging`, 'tuhna');
  }
}
