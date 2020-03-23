import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Category } from 'src/app/models/orders/category';
import { Observable } from 'rxjs';
import { CategoryDescription } from 'src/app/models/orders/categoryDescription';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  private categoriesUrl = 'http://localhost:59804/api/categories';

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<Category[]>{
    return  this.http.get<Category[]>(this.categoriesUrl);
  }

  getCategoryDescription(id:number) : Observable<CategoryDescription>{
    return  this.http.get<CategoryDescription>(this.categoriesUrl + `/${id}/description`);
  }

}
