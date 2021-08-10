import { Component, OnInit } from '@angular/core';
import {APICallServiceService} from '../Services/apicall-service.service';
import { Observable,Subscribable } from 'rxjs';
import { Coordinates, CreateTriangleByRC,RowColumn,GetRCByCoordinates } from '../Models/FetchCoordinates';

@Component({
  selector: 'app-rowcolumn',
  templateUrl: './rowcolumn.component.html',
  styleUrls: ['./rowcolumn.component.css']
})
export class RowcolumnComponent implements OnInit {

  triangle:CreateTriangleByRC=new CreateTriangleByRC();
  coordinates:GetRCByCoordinates=new GetRCByCoordinates();
  rowColumn:RowColumn;
  cellSize:number;
  row:any;
  column:number;
  list2:Array<Coordinates>;
  RowList:Array<string>;
  dropdown:boolean;
  constructor(private serv:APICallServiceService) { }

  ngOnInit(): void {
     this.coordinates.CellSize=10;
     this.coordinates.TopCoordinates=new Coordinates(0,0);
     this.coordinates.MidCoordinates=new Coordinates(0,0);
     this.coordinates.BottomCoordinates=new Coordinates(0,0);
     this.rowColumn=new RowColumn('A',1);
  }

  FetchRowAndColumn(){
    this.serv.APIFetchRowAndColumn(this.coordinates).subscribe(args=>{
         this.rowColumn=args as RowColumn;
         this.row=this.rowColumn.Row;
         this.column=this.rowColumn.Column;
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
