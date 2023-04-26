import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Cartresponse } from '../../interfaces/responses/cartresponse';
import { Productsresponse } from '../../interfaces/responses/productsresponse';
import { CartService } from '../../services/cart.service';
import { ProductsService } from '../../services/products.service';
import { PurchaseService } from '../../services/purchase.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cart: Cartresponse;

  constructor(
    private productService: ProductsService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router: Router,
    private purchaseService: PurchaseService
  ) {}
  ngOnInit(): void {
    this.onDataTable();
  }
  onDataTable() {
    const cartId = this.route.snapshot.queryParams['cartId'];
    this.cartService.getCart().subscribe((cartresponse: Cartresponse) => {
      this.cart = cartresponse;
      for (let detail of this.cart.cartDetails) {
        this.productService
          .getProductId(detail.productId)
          .subscribe((res: Productsresponse) => {
            detail.product = res;
          });
      }
    });
  }
  
  Purchase(cartId: string) {
    this.purchaseService.postPurchaseAdd(cartId).subscribe(
      (res) => {
        this.sweetAlertSuccess();
      },
      (error) => {
        this.sweetAlertError();
      }
    );
  }

  sweetAlertSuccess() {
    Swal.fire({
      title: 'Producto Agregado',
      text: 'Proceder a pagar!',
      icon: 'success',
      confirmButtonText: 'Aceptar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.onDataTable();
      }
    });
  }
  sweetAlertError() {
    Swal.fire({
      title: 'Error',
      text: 'No se pudo agregar el producto!',
      icon: 'error',
      confirmButtonText: 'Aceptar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.onDataTable();
      }
    });
  }

  sweetAlert(Id: string) {
    Swal.fire({
      title: 'Confirmacion de Compra',
      text: 'Proceder a pagar!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Pagar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.Purchase(Id);
      }
    });
  }

  sweetAlertDelete(Id: string) {
    Swal.fire({
      title: 'Eliminar Producto',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Eliminar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.DeleteItem(Id);
      }
    });
  }
  DeleteItem(Id: string) {
    this.cartService.deleteFromCart(Id).subscribe((res) => {
      this.onDataTable();
    });
  }
  total(): number {
    let total = 0;
    for (let detail of this.cart.cartDetails) {
      total += detail.price * detail.quantity;
    }
    return total;
  }

  public createImgPath = (ServerPath: string | undefined) => {
    if (ServerPath) {
      return `https://localhost:7242/${ServerPath}`;
    } else {
      // Return a placeholder image or alternative text
      return 'https://via.placeholder.com/150x150?text=No+Image';
    }
  };
}
