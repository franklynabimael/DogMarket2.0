import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddProductComponent } from './components/add-product/add-product.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { CartComponent } from './components/cart/cart.component';
import { CategoryComponent } from './components/category/category.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { HomeComponent } from './components/home/home.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { AdminGuard } from './shared/guards/admin.guard';
import { UserService } from './services/user.service';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'products', component: ProductsListComponent },
      { path: 'category', component: CategoryComponent },
      {
        path: 'add-products',
        component: AddProductComponent,
        canActivate: [AdminGuard],
      },
      {
        path: 'productdetail',
        component: ProductDetailComponent,
        canActivate: [AuthGuard],
      },
      { path: 'cart', component: CartComponent, canActivate: [AuthGuard] },
    ],
  },

  { path: 'login', component: AuthenticateComponent },
  { path: 'forbidden', component: ForbiddenComponent },

  // {
  //   path: 'company',
  //   loadChildren: () =>
  //     import('./company/company.module').then((m) => m.CompanyModule),
  //   canActivate: [AuthGuard],
  // { path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuard, AdminGuard] },
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
