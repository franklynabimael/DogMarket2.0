import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from 'src/app/services/categories.service';
import { Categoryresponse } from '../../interfaces/responses/categoryresponse';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
})
export class ProductsListComponent implements OnInit {
  categoryFound: any = [];

  constructor(
    private categoryService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable() {
    const categoryId = this.route.snapshot.queryParams['categoryId'];
    console.log(categoryId);
    this.categoryService
      .getcategoryId(categoryId)
      .subscribe((category: Categoryresponse) => {
        this.categoryFound = category;
        console.log(category);
      });
  }

  viewDetail(productId: string) {
    this.router.navigate(['/productdetail'], { queryParams: { productId } });
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
