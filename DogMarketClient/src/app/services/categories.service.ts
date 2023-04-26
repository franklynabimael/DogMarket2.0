import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { addcategoryDTO } from '../interfaces/addcategorydto';
import { AddCategoryResponse } from '../interfaces/responses/addcategoryresponse';
import { Categoryresponse } from '../interfaces/responses/categoryresponse';
@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  private urlApi = `https://localhost:7242/api/Categories`;
  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get(this.urlApi);
  }

  postcategoriesAdd(body: addcategoryDTO) {
    return this.http.post<AddCategoryResponse>(this.urlApi, body);
  }

  getcategoryId(categoryId: number): Observable<Categoryresponse> {
    return this.http.get<Categoryresponse>(`${this.urlApi}/${categoryId}`);
  }
}
