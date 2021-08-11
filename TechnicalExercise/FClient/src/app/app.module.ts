import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TriangleComponent } from './triangle/triangle.component';
import {APICallServiceService} from './Services/apicall-service.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RowcolumnComponent } from './rowcolumn/rowcolumn.component';
import { QuestionComponent } from './question/question.component';


@NgModule({
  declarations: [
    AppComponent,
    TriangleComponent,
    RowcolumnComponent,
    QuestionComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [APICallServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
