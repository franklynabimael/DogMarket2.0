import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AddproductDTO } from '../interfaces/addproductdto';
import { Observable } from 'rxjs';
import { Productresponse } from '../interfaces/responses/productresponse';
import { Productsresponse } from '../interfaces/responses/productsresponse';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  fullname = new EventEmitter<string>();
  private urlApi = `https://localhost:7242/api/products`;
  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(this.urlApi);
  }

  getProductId(productId: string) {
    return this.http.get(`${this.urlApi}/${productId}`);
  }

  getProduct(productId: string): Observable<Productsresponse> {
    return this.http.get<Productsresponse>(`${this.urlApi}/${productId}`);
  }

  postProductsAdd(product: AddproductDTO) {
    return this.http.post(`${this.urlApi}/add`, product);
  }
}
