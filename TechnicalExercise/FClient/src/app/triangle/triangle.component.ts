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
  TextError: string;
  constructor(private serv:APICallServiceService) { }

  ngOnInit(): void {
     this.triangle.CellSize=10;
     this.triangle.Rowcolumn=new RowColumn('A',1);
    this.RowList = ["A", "B", "C", "D", "E", "F"];
    this.TextError = null;
    this.Serror = null;
  }

  FetchCoordinates() {
    if (this.Validateentry()) {
      this.serv.APIFetchCoordinates(this.triangle).subscribe(args => {
        this.list2 = args as Array<Coordinates>;
        this.TextError = null;
        this.Serror = null;
      },
        error => {
          this.Serror = error.error.Message;
        })
    }
  }

  keyPressNumbers(event) {
    this.TextError = null;
    this.Serror = null;
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

  Validateentry() {
    if (this.triangle.CellSize.toString() == "") {
      this.TextError = "Cell Size is required";
      return false;
    }
    if (this.triangle.Rowcolumn.Column.toString() == "") {
      this.TextError = "Column is required";
      return false;
    }
    if (this.triangle.Rowcolumn.Column > 12 && this.triangle.Rowcolumn.Column!=0) {
      this.TextError = "Column should be in the range of [1-12]";
      return false;
    }
    if (this.triangle.CellSize != 0 && this.triangle.CellSize > 10) {
      this.TextError = "Cell Size should be in the range of [1-10]";
      return false;
    }
    return true;
  }

}
