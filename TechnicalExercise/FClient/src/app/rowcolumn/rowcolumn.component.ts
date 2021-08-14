import { Component, OnInit } from '@angular/core';
import { APICallServiceService } from '../Services/apicall-service.service';
import { Observable, Subscribable } from 'rxjs';
import { Coordinates, CreateTriangleByRC, RowColumn, GetRCByCoordinates } from '../Models/FetchCoordinates';

@Component({
  selector: 'app-rowcolumn',
  templateUrl: './rowcolumn.component.html',
  styleUrls: ['./rowcolumn.component.css']
})
export class RowcolumnComponent implements OnInit {

  triangle: CreateTriangleByRC = new CreateTriangleByRC();
  coordinates: GetRCByCoordinates = new GetRCByCoordinates();
  rowColumn: RowColumn;
  cellSize: number;
  row: any;
  column: number;
  list2: Array<Coordinates>;
  RowList: Array<string>;
  dropdown: boolean;
  Serror: any;
  TextError: string;
  constructor(private serv: APICallServiceService) { }

  ngOnInit(): void {
    this.coordinates.CellSize = 10;
    this.coordinates.TopCoordinates = new Coordinates(0, 0);
    this.coordinates.MidCoordinates = new Coordinates(0, 0);
    this.coordinates.BottomCoordinates = new Coordinates(0, 0);
    this.rowColumn = new RowColumn('A', 1);
    this.TextError = null;
    this.Serror = null;
  }

  FetchRowAndColumn() {
    this.row = null;
    if (this.Validateentry()) {
      this.serv.APIFetchRowAndColumn(this.coordinates).subscribe(args => {
        this.rowColumn = args as RowColumn;
        this.row = this.rowColumn.Row;
        this.column = this.rowColumn.Column;
        this.Serror = null;
        this.TextError = null;
      },
        error => {
          this.Serror = error.error.Message;
        });
    }
  }

  keyPressNumbers(event) {
    this.TextError = null;
    this.Serror = null;
    var charCode = (event.which) ? event.which : event.keyCode;
    if (charCode < 48 || charCode > 57) {
      event.preventDefault();
      return false;
    }
    else {
      return true;
    }
  }

  Validateentry() {
    if (this.coordinates.CellSize.toString() == "") {
      this.TextError = "Cell Size is required";
      return false;
    }
    if (this.coordinates.CellSize == 0 || this.coordinates.CellSize > 10) {
      this.TextError = "Cell Size should be in the range of [1-10]";
      return false;
    }
    if (this.coordinates.TopCoordinates.X.toString() == "" || this.coordinates.TopCoordinates.Y.toString() == "") {
      this.TextError = "Top Coordinates are required";
      return false;
    }
    if (this.coordinates.MidCoordinates.X.toString() == "" || this.coordinates.MidCoordinates.Y.toString() == "") {
      this.TextError = "Angle Coordinates are required";
      return false;
    }
    if (this.coordinates.BottomCoordinates.X.toString() == "" || this.coordinates.BottomCoordinates.Y.toString() == "") {
      this.TextError = "Bottom Coordinates are required";
      return false;
    }
    if (this.coordinates.TopCoordinates.X > (this.coordinates.CellSize * 6) || this.coordinates.TopCoordinates.Y > (this.coordinates.CellSize * 6)) {
      this.TextError = "Top Coordinates are out of range w.r.t given layout";
      return false;
    }
    if (this.coordinates.MidCoordinates.X > (this.coordinates.CellSize * 6) || this.coordinates.MidCoordinates.Y > (this.coordinates.CellSize * 6)) {
      this.TextError = "Angle Coordinates are out of range w.r.t given layout";
      return false;
    }
    if (this.coordinates.BottomCoordinates.X > (this.coordinates.CellSize * 6) || this.coordinates.BottomCoordinates.Y > (this.coordinates.CellSize * 6)) {
      this.TextError = "Bottom Coordinates are out of range w.r.t given layout";
      return false;
    }
    return true;
  }
}
