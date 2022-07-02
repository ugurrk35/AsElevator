import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';
import { ListResponseModel } from '../responses/list-response-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl = environment.aselevatorUrl;
   constructor(private httpClient: HttpClient) {
   }

   getAllCategory():Observable<ListResponseModel<Category>>{
     return this.httpClient.get<ListResponseModel<Category>>(this.apiUrl + 'Categories/GetAll');

 }
 deleteCategory(Id:number):Observable<Category>{

  return this.httpClient.delete<Category> (this.apiUrl+'api/Categories/' + Id); //buna dikkat
  //buralara dto yazabiliriz
}
 }
