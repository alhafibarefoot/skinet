import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/products';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/ShopParams';
import { ShopService } from './shop.service';



@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  brands!: IBrand[];
  types!: IType[];

   sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ];
  ShopParams=new ShopParams();
  totalCount:number;



  constructor(private shopService: ShopService) { }

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getTypes();

  }

  getProducts() {

    this.shopService.getProducts(this.ShopParams).subscribe(response => {
      this.products = response.data ;
      this.ShopParams.pageNumber=response.pageIndex;
      this.ShopParams.pageSize=response.pageSize;
      this.totalCount=response.count;

    }, error => {
      console.log(error);
    })


  }

  getBrands() {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id:0,name:"All"},...response];
    }, error => {
      console.log(error);
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe(response => {
      this.types = [{id:0,name:"All"},...response];
    }, error => {
      console.log(error);
    })
  }

  onBrandSelected(brandId: number) {

    this.ShopParams.brandId = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {

    this.ShopParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {

    this.ShopParams.sort=sort;
    this.getProducts();
  }

  onPageChanged(event: any) {


    this.ShopParams.pageNumber = event.page;
    this.getProducts();


  }

}
