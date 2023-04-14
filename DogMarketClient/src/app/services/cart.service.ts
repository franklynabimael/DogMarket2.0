import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Cartresponse } from '../interfaces/responses/cartresponse';
import { Detailsresponse } from '../interfaces/responses/detailsresponse';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private urlApi = `${environment.urlApi}/CartsControllers`;
  constructor(private http: HttpClient) {}

  getCart() {
    return this.http.post(`${this.urlApi}/myCart`, '');
  }

  addToCart(body: Cartresponse) {
    return this.http.post(`${this.urlApi}/{productId}`, body);
  }

  deleteFromCart(body: Detailsresponse) {
    return this.http.post(`${this.urlApi}/{detailId}`, body);
  }
}
