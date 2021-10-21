import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/models/IPagination';
import { IProduct } from './shared/models/IProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Ticaret-Angular';
  products:IProduct[];
  constructor(private http:HttpClient){}

  ngOnInit():void {
    this.http.get<IPagination>('https://localhost:44369/api/products').subscribe((response:IPagination)=>{
     this.products=response.data;
    },error=>{
      console.log(error);
    });
  }
}
