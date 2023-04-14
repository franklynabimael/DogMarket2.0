import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Fileresponse } from '../interfaces/responses/fileresponse';

@Injectable({
  providedIn: 'root',
})
export class FilesService {
  private urlApi = `${environment.urlApi}/files`;

  constructor(private http: HttpClient) {}

  postfilesAdd(body: Fileresponse) {
    return this.http.post(`${this.urlApi}/image`, body);
  }
}
