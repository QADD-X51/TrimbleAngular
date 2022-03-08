import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'notes-app';
  myValue : number = 23;
  dateTest :Date = new Date(2002,6, 6);

  stringList : Array<string> = [
    "Elem0",
    "Elem1",
    "Elem2",
    "Elem3",
    "Elem4",
    "Elem5",
    "Elem6",
    "Elem7",
    "Elem8",
    "Elem9",
  ];

  dateList : Array<Date> = [
    new Date(2002, 6, 6),
    new Date(2001, 1, 1),
    new Date(2000,4, 1),
    new Date(2012,12, 12),
    new Date(2009,3, 6 )
  ]
}
