import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Productresponse } from '../../interfaces/responses/productresponse';
import { ProductsService } from '../../services/products.service';
import { CartService } from '../../services/cart.service';
import { Cartresponse } from '../../interfaces/responses/cartresponse';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  productDetail: Productresponse;

  constructor(
    private productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.onDataTable();
  }
  
  onDataTable() {
    const productId = this.route.snapshot.queryParams['productId'];
    this.productsService
      .getProductId(productId)
      .subscribe((productresponse: Productresponse) => {
        this.productDetail = productresponse;
      });
  }

  cartProduct(productId: string) {
    this.cartService.addToCart(productId, 1).subscribe(() => {
      this.router.navigate(['/cart']);
    });
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
