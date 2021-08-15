import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TriangleComponent } from './triangle/triangle.component';
import { RowcolumnComponent } from './rowcolumn/rowcolumn.component';
import { QuestionComponent } from './question/question.component';

const routes: Routes = [
  { path: '/', component: QuestionComponent },
  { path: 'triangle', component: TriangleComponent, pathMatch: 'full' },
  { path: 'rowColumn', component: RowcolumnComponent },
  { path: 'question', component: QuestionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
