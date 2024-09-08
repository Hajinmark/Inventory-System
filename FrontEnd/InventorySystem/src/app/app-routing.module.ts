import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { ProductComponent } from './product/product.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path: '', redirectTo:'/sidebar', pathMatch:'full'},
  {path:'category', component:CategoryComponent},
  {path:'product', component:ProductComponent},
  {path:'dashboard', component:DashboardComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
