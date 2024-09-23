import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { IAddNewCategory, ICategory, IUpdateCategory } from '../model/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CategoryServiceService implements OnInit{

  constructor(private httpClient : HttpClient) { }

  ngOnInit(): void{

  }

  displayCategory() : Observable<ICategory[]>
  {
    var url = 'https://localhost:7262/api/Category/DisplayCategories';
    var listCategory = this.httpClient.get<ICategory[]>(url);
    return listCategory
  }

  addCategory(data : IAddNewCategory) : Observable<IAddNewCategory>
  {
    var url = 'https://localhost:7262/api/Category/AddNewCategory';
    var newCategory = this.httpClient.post<IAddNewCategory>(url,data);
    return newCategory;
  }

  countCategory() : Observable<number>
  {
    var url = 'https://localhost:7262/api/Category/CountCategory';
    var countCategory = this.httpClient.get<number>(url);
    return countCategory;
  }

  updateCategory(id : string, data : IUpdateCategory) : Observable<IUpdateCategory>
  {
    var url = 'https://localhost:7262/api/Category/UpdateCategory';
   
    var updateCategory = this.httpClient.put<IUpdateCategory>(`${url}?categoryId=${id}`,data);
    return updateCategory;
  }
}
