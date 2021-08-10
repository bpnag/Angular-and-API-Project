import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import{FetchCoordinates,Coordinates, CreateTriangleByRC,GetRCByCoordinates} from '../Models/FetchCoordinates';
import{HttpClient,HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class APICallServiceService {

  constructor(private http:HttpClient) { 

  }

  APIFetchCoordinates(createTriangleByRC:CreateTriangleByRC){
     return this.http.post('api/FetchCoordinates',createTriangleByRC,{
       headers:new HttpHeaders({
         'Content-Type':'application/json'
       })
     });
  }

  APIFetchRowAndColumn(getRCByCoordinates:GetRCByCoordinates){
    return this.http.post('api/FetchRowAndColumn',getRCByCoordinates,{
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
 }
}
