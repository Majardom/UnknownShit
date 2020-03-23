import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/orders/category';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { Product } from 'src/app/models/orders/product';
import { OrdersService } from 'src/app/services/orders/orders.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories: Category[];
  products: Product[];

  constructor(private categoryServiece: CategoriesService,
    private orderService: OrdersService,
  ) { }

  ngOnInit() {
    this.setCategories();
    this.setPrdoucts();
  }

  setCategories() {
    this.categoryServiece
      .getAllCategories()
      .subscribe(founded => this.categories = founded);
  }

  setPrdoucts() {
    this.orderService
      .getAllProducts()
      .subscribe(founded => this.products = founded);
  }

  getProductsById(Id: number): Product[] {
    return this.products.filter(prod => prod.CategoryId == Id);
  }

}
