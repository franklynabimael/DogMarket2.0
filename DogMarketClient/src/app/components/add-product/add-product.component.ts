import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddproductDTO } from '../../interfaces/addproductdto';
import { Categoriesresponse } from '../../interfaces/responses/categoriesresponse';
import { Productresponse } from '../../interfaces/responses/productresponse';
import { CategoriesService } from '../../services/categories.service';
import { ProductsService } from '../../services/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  errorMessage: any = null;
  productForm: FormGroup;
  private returnUrl!: string;
  responseImg!: { dbPath: '' };
  datatable: any = [];
  categoryTable: any = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductsService,
    private categoryService: CategoriesService,
    private toastr: ToastrService,
    private http: HttpClient
  ) {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [, Validators.required],
      code: ['', Validators.required],
      stock: [, Validators.required],
      categoryId: [, Validators.required],
      ImgPath: ['', Validators.required],
    });
  }

  uploadImageFinished = (event: any) => {
    this.responseImg = event;
  };

  sweetAlert() {
    Swal.fire({
      title: 'Producto agregado!',
      icon: 'success',
    }).then((result) => {
      if (result.isConfirmed) {
        this.onSubmit();
      }
    });
  }

  onCategory() {
    this.categoryService
      .getCategories()
      .subscribe((res: Categoriesresponse) => {
        this.categoryTable = res;
      });
  }

  private assertInputsProvided(): void {
    if (!this.productForm) {
      throw new Error('The required input [userId] was not provided');
    }
  }

  validateControl = (controlName: string) => {
    return (
      this.productForm.get(controlName).invalid &&
      this.productForm.get(controlName).touched
    );
  };

  hasError = (controlName: string, errorName: string) => {
    return this.productForm.get(controlName).hasError(errorName);
  };

  onSubmit() {
    const formData: AddproductDTO = this.productForm.value;
    formData.ImgPath = this.responseImg.dbPath;

    this.productService.postProductsAdd(formData).subscribe({
      next: (res: Productresponse) => {
        this.toastr.success(
          `Producto ${res.name} agregado correctamente`,
          'Success!',
          {
            timeOut: 3000,
            enableHtml: true,
            progressBar: true,
            progressAnimation: 'decreasing',
            tapToDismiss: true,
            toastClass: 'ngx-toastr',
          }
        );
        this.router.navigate(['']);
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.error.error;
        this.errorMessage = err.error.File;
        console.log(this.errorMessage);
        console.log(err);
        this.toastr.error(`${this.errorMessage.message}`, 'Error', {
          timeOut: 3000,
          enableHtml: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          tapToDismiss: true,
          toastClass: 'ngx-toastr',
        });
      },
    });
  }

  ngOnInit(): void {
    this.assertInputsProvided();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.onCategory();
  }
}
