import { Component, OnInit } from '@angular/core';
import { CategoryServiceService } from '../service/category-service.service';
import { json } from 'stream/consumers';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{

  countCategory! : number;
  constructor(private service : CategoryServiceService)
  {

  }

  ngOnInit(): void
  {
    this.displayNumberOfCategory();
  }

  displayNumberOfCategory()
  {
    this.service.countCategory().subscribe({
      next: (count: number) =>{
        this.countCategory = count,
        console.log(JSON.stringify(this.countCategory));
      },
      error: error => console.error('Error : '+error),
      complete: () => console.log('Completed')
    });
  }
}
