import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/orders/order';
import { OrdersService } from 'src/app/services/orders/orders.service';
import { Stage } from 'src/app/models/orders/stage';
import { Product } from 'src/app/models/orders/product';
import { Category } from 'src/app/models/orders/category';
import { CategoriesService } from 'src/app/services/categories/categories.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Order[];
  stages: Stage[];
  products: Product[];
  categories: Category[];

  constructor(private orderService: OrdersService,
    private categoriesService: CategoriesService,
  ) { }

  ngOnInit() {
    this.setOrders();
    this.setProducts();
    this.setStages();
    this.setCategories();
  }

  log(o){
    console.log(o);
  }

  setOrders() {
   this.orderService.getAllOrders().subscribe(founded => this.orders = founded);
  }

  setStages() {
    this.orderService.getAllStages().subscribe(founded => this.stages = founded);
  }

  setProducts() {
    this.orderService.getAllProducts().subscribe(founded => this.products = founded);
  }

  setCategories() {
    this.categoriesService.getAllCategories().subscribe(founded => this.categories = founded);
  }

  getStage(id: number) {
    if (this.stages != null)
      return this.stages.filter(stage => stage.Id == id)[0];
  }
  getProduct(id: number) {
    if (this.products != null) {
      var filteredArray = this.products.filter(product => product.Id == id)
      return filteredArray[0];
    }
  }

  getCategory(id: number) {
    if (this.categories != null) {
      var filteredArray = this.categories.filter(category => category.Id == id);
      return filteredArray[0];
    }
  }
}
