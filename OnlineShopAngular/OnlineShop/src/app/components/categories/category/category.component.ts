import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/models/orders/category';
import { Product } from 'src/app/models/orders/product';
import { CategoryDescription } from 'src/app/models/orders/categoryDescription';
import { CategoriesService } from 'src/app/services/categories/categories.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  @Input()
  category: Category;
  @Input()
  products: Product[];

  private numberOfProductsInRow = 5;

  description: CategoryDescription;

  constructor(private categoriesService: CategoriesService ) { }

  ngOnInit() {
    this.setDescription(this.category.Id);
  }

  setDescription(id: number) {
    this.categoriesService
      .getCategoryDescription(id)
      .subscribe(founded => this.description = founded);
  }
  getProductCardWidth(): number {
    let width = Math.floor( 100 / this.numberOfProductsInRow);
    return width;
  }
}
