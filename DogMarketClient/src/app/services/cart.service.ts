import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Cartresponse } from '../interfaces/responses/cartresponse';
import { Detailsresponse } from '../interfaces/responses/detailsresponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private urlApi = `https://localhost:7242/api/Carts`;
  constructor(private http: HttpClient) {}
 
  getCart(): Observable<Cartresponse> {
    return this.http.get<Cartresponse>(`${this.urlApi}/myCart`);
  }

  addToCart(productId: string, quantity: number) {
    return this.http.get(`${this.urlApi}/${productId}/${quantity}`);
  }

  deleteFromCart(detailId: string) {
    return this.http.delete(`${this.urlApi}/${detailId}`);
  }
}
