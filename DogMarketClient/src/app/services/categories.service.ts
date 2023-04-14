import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { addcategoryDTO } from '../interfaces/addcategorydto';
import { AddCategoryResponse } from '../interfaces/responses/addcategoryresponse';
import { Categoriesresponse } from '../interfaces/responses/categoriesresponse';
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

  getcategoriesId(body: Categoriesresponse) {
    return this.http.get(`${this.urlApi}/{categoryid}`);
  }
}
