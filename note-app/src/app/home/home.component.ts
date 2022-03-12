import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  categoryId: string;
  search: string;

  constructor() { }

  ngOnInit(): void {
  }

  receiveCategory(categId: string) {
    this.categoryId = categId;
    console.log(this.categoryId);
  }

  recieveSearchInput(input: string){
    if(input == "")
      input = undefined;
    this.search = input;
  }
}
