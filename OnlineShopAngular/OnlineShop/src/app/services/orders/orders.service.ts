import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from 'src/app/models/orders/order';
import { Stage } from 'src/app/models/orders/stage';
import { Product } from 'src/app/models/orders/product';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private ordersUrl = "http://localhost:59804/api/orders";
  private productsUrl = "http://localhost:59804/api/products";

  constructor(private http: HttpClient) {
  }

  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.ordersUrl);
  }

  getAllStages(): Observable<Stage[]> {
    return this.http.get<Stage[]>(this.ordersUrl + "/stages");
  }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl);
  }
}
