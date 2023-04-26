import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';

import { AddProductComponent } from './components/add-product/add-product.component';
import { AppComponent } from './components/appcomponent/app.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { BodySidebarComponent } from './components/body-sidebar/body-sidebar.component';
import { CartComponent } from './components/cart/cart.component';
import { CategoryComponent } from './components/category/category.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { HomeComponent } from './components/home/home.component';
import { ImageManageComponent } from './components/image-manage/image-manage.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { UserService } from './services/user.service';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    AuthenticateComponent,
    HomeComponent,
    SidebarComponent,
    PrivacyComponent,
    ForbiddenComponent,
    CartComponent,
    PurchaseComponent,
    ImageManageComponent,
    ProductsListComponent,
    ProductDetailComponent,
    BodySidebarComponent,
    NavBarComponent,
    CategoryComponent,
    AddProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatInputModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    MatButtonModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatSliderModule,
    MatMenuModule,
    MatIconModule,
    MatExpansionModule,
    ToastrModule.forRoot({
      timeOut: 1500,
      preventDuplicates: true,
      progressAnimation: 'increasing',
      enableHtml: true,
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:7242'],
        disallowedRoutes: [],
      },
    }),
  ],
  providers: [UserService],
  bootstrap: [AppComponent],
})
export class AppModule {}
