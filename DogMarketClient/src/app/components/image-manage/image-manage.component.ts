import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-image-manage',
  templateUrl: './image-manage.component.html',
  styleUrls: ['./image-manage.component.css'],
})
export class ImageManageComponent {
  @Output() public onImageUploadFinished = new EventEmitter();
  name = 'Tuhna';
  errorMessage: any;
  showError = false;
  progress!: number;
  message!: string;
  private urlApi = `https://localhost:7242/api/files`;

  constructor(
    private http: HttpClient,
    private productService: ProductsService
  ) {
    this.productService.fullname.subscribe((name) => (this.name = name));
  }

  onUploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http
      .post(`${this.urlApi}/image`, formData, {
        reportProgress: true,
        observe: 'events',
      })
      .subscribe({
        next: (event) => {
          this.showError = false;
          if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round((100 * event.loaded) / event.total!);
          else if (event.type === HttpEventType.Response) {
            this.message = 'Picture Success.';
            this.onImageUploadFinished.emit(event.body);
          }
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.error.File;
          this.showError = true;
          console.log(this.errorMessage);
          console.log(err.error.message);
          
          console.log(err);
        },
      });
  };
}
