export class FetchCoordinates{
    CellSize:number;
    Row:any;
    Column:number;

    constructor(x:number,y:any,z:number){
        this.CellSize=x;
        this.Row=y;
        this.Column=z;
    }
}

export class Coordinates{
    X:number;
    Y:number;

    constructor(x:number,y:number){
        this.X=x;
        this.Y=y;
    }
}

export class CreateTriangleByRC{
    CellSize:number;
    Rowcolumn:RowColumn;
}

export class RowColumn{
    Row:any;
    Column:number;

    constructor(x:any,y:number){
        this.Row=x;
        this.Column=y;
    }
}

export class GetRCByCoordinates{
    CellSize:number;
    TopCoordinates:Coordinates;
    MidCoordinates:Coordinates;
    BottomCoordinates:Coordinates;
}