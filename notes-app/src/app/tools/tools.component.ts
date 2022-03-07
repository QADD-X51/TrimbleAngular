import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  colorName : string = "cyan";
  inputField : string = "";

  constructor() { }

  ngOnInit(): void {
  }

  ChangeColor() : void{
    this.colorName = this.inputField;
  }
}
