import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {


  baseUrl = environment.apiUrl;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  get404Error() {
    this.http.get(this.baseUrl + 'products/42').subscribe(response => { //we sure product 42 not exsists
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
  get500Error() {
    this.http.get(this.baseUrl + 'Buggy/servererror').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
  get400Error() {
    this.http.get(this.baseUrl + 'Buggy/badrequest').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/fortytwo').subscribe(response => { //instead 42 number we put string
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    })
  }


}
