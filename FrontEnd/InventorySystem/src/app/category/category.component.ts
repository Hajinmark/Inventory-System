import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryServiceService } from '../service/category-service.service';
import { IAddNewCategory, ICategory, IUpdateCategory } from '../model/category';
import { NgFor } from '@angular/common';
import { Observable, timer } from 'rxjs';
import { response } from 'express';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  isVisible : boolean = false;
  isUpdateVisible : boolean = false;

  objCategory : IAddNewCategory = {
    categoryId : '',
    categoryName: '',
    description: '',
    isActivated: true
  };

  id : string = '';
  objUpdateCategory : IUpdateCategory = {
    categoryId : '',
    categoryName : '',
    description : '',
    isActivated : true
  };
 
  categories : ICategory[] = [];
  pageSize: number = 5; // Number of items per page
  currentPage: number = 1; // Current page number
  selectedCategory : any;
  
  constructor(private httpclient : HttpClient, private categoryService : CategoryServiceService)
  {

  }
  ngOnInit(): void
  {
    this.displayAllCategories();
  }

  updateCategoryData()
  {
    this.categoryService.updateCategory(this.id, this.objUpdateCategory).subscribe({
      next: response => {alert("Successfully Updated")},
      error: error => console.log(JSON.stringify(error)),
      complete: () => console.log('')
    });
  }
  

  displayAllCategories()
  {
    this.categoryService.displayCategory().subscribe({
      next: response => this.categories = response,
      error: error => console.log("Error: "+error),
      complete: () => console.log("")
    });
  }
  
  openAddModal()
  {
    this.isVisible = true;
  }

  closeModal()
  {
    this.isVisible = false;
  }

  openUpdateModal(categories : any)
  {
    this.id = categories.categoryId;
    this.objUpdateCategory = { ...categories};
    this.isUpdateVisible = true;
  }

  closeUpdateModal()
  {
    this.isUpdateVisible = !true;
  }

  addCategory()
  {

    this.categoryService.addCategory(this.objCategory).subscribe({
      next: response => {
        this.objCategory = response,
        //alert(JSON.stringify(this.objCategory)),
        alert('Successfully Added New Category'),
        this.clearInputFields();
      },
      error: error => alert('Error: '+error)
      //complete: () => alert('Completed')
    });
  }

  clearInputFields()
  {
    this.objCategory.categoryName = '';
    this.objCategory.description = '';
    this.objCategory.isActivated = true;
    window.location.reload();
  }

 
}
