import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { SideNavCollapsedComponent } from './main-nav/side-nav/side-nav-collapsed/side-nav-collapsed.component';
import { SideNavExpandedComponent } from './main-nav/side-nav/side-nav-expanded/side-nav-expanded.component';
import { OrderComponent } from './components/orders/order/order.component';
import { OrdersComponent } from './components/orders/orders/orders.component';
import { HttpClientModule } from '@angular/common/http';
import { AppMaterialModule } from './material-exports/app-material/app-material.module';
import { CategoriesComponent } from './components/categories/categories/categories.component';
import { CategoryComponent } from './components/categories/category/category.component';
import { ProductComponent } from './components/product/product.component';
import { FormsModule } from '@angular/forms';
import { StagesBarComponent } from './components/stages-bar/stages-bar.component'

@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    SideNavCollapsedComponent,
    SideNavExpandedComponent,
    OrderComponent,
    OrdersComponent,
    CategoriesComponent,
    CategoryComponent,
    ProductComponent,
    StagesBarComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    LayoutModule,
    HttpClientModule,
    AppMaterialModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
