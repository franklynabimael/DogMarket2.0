import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Purchaseresponse } from '../interfaces/responses/purchaseresponse';

@Injectable({
  providedIn: 'root',
})
export class PurchaseService {
  private urlApi = `${environment.urlApi}/purchases/carts/{cartId}`;
  constructor(private http: HttpClient) {}

  getPurchase() {
    return this.http.get(this.urlApi);
  }

  postPurchaseAdd(body: Purchaseresponse) {
    return this.http.post(`${this.urlApi}/purchase`, body); //ojo
  }
}
