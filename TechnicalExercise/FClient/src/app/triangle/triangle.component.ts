import { Component, OnInit } from '@angular/core';
import {APICallServiceService} from '../Services/apicall-service.service';
import { Observable,Subscribable } from 'rxjs';
import { Coordinates, CreateTriangleByRC,RowColumn,GetRCByCoordinates } from '../Models/FetchCoordinates';

@Component({
  selector: 'app-triangle',
  templateUrl: './triangle.component.html',
  styleUrls: ['./triangle.component.css']
})
export class TriangleComponent implements OnInit {

  triangle:CreateTriangleByRC=new CreateTriangleByRC();
  coordinates:GetRCByCoordinates=new GetRCByCoordinates();
  rowColumn:RowColumn;
  cellSize:number;
  row:any;
  column:number;
  list2:Array<Coordinates>;
  RowList:Array<string>;
  dropdown: boolean;
  Serror: any;
  constructor(private serv:APICallServiceService) { }

  ngOnInit(): void {
     this.triangle.CellSize=10;
     this.triangle.Rowcolumn=new RowColumn('A',1);
     this.RowList=["A","B","C","D","E","F","G"];
  }

  FetchCoordinates(){
      this.serv.APIFetchCoordinates(this.triangle).subscribe(args=>{
           this.list2=args as Array<Coordinates>;
      },
        error => {
          this.Serror = error.error.Message;
          this.RowList = ["A", "B", "C", "D", "E", "F", "G"];
        })
  }

  keyPressNumbers(event){
    var charCode=(event.which)?event.which:event.keyCode;
    if(charCode<48 ||charCode>57)
    {
      event.preventDefault();
      return false;
    }
    else{
      return true;
    }
  }

}
