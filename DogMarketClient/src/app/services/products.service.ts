import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private urlApi = `${environment.urlApi}/products`;
  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(this.urlApi);
  }

  getProductId() {
    return this.http.get(`${this.urlApi}/{productid}`);
  }

  postProductsAdd() {
    return this.http.post(`${this.urlApi}/add`, '');
  }
}
