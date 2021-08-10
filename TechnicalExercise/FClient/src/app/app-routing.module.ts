import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TriangleComponent } from './triangle/triangle.component';
import { RowcolumnComponent } from './rowcolumn/rowcolumn.component';

const routes: Routes = [
  {path:'triangle',component:TriangleComponent,pathMatch:'full'},
  {path:'rowColumn',component:RowcolumnComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
