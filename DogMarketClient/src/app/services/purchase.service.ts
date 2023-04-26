import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Purchaseresponse } from '../interfaces/responses/purchaseresponse';

@Injectable({
  providedIn: 'root',
})
export class PurchaseService {
  private urlApi = `https://localhost:7242/api/purchase/carts`;
  constructor(private http: HttpClient) {}

  getPurchase() {
    return this.http.get(this.urlApi);
  }

  postPurchaseAdd(cartId: string) {
    return this.http.get(`${this.urlApi}/${cartId}/purchase`);
  }
}
