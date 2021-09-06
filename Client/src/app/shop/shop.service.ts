import { ShopParams } from './../shared/models/ShopParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http:HttpClient) { }

  getProducts(ShopParams:ShopParams) {

    let params=new HttpParams();

    if(ShopParams.brandId){
      params=params.append('brandId',ShopParams.brandId.toString());
    }
    if(ShopParams.typeId){
      params=params.append('typeId',ShopParams.typeId.toString());
    }

    if( ShopParams.sort){
      params=params.append('sort',ShopParams.sort);
    }


    return this.http.get<IPagination>(this.baseUrl + 'products?pageSize=50', { observe: 'response', params })
       .pipe(
            map(response => {
              return response.body;
            })
       );


  }
  getBrands() {

    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {

    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}
