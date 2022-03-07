import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Dummycomponent1Component } from './dummycomponent1/dummycomponent1.component';
import { Dummycomponent2Component } from './dummycomponent2/dummycomponent2.component';



@NgModule({
  declarations: [
    Dummycomponent1Component,
    Dummycomponent2Component
  ],
  imports: [
    CommonModule
  ],
  exports:[
    Dummycomponent1Component,
    Dummycomponent2Component
  ]
})
export class Dummy1Module { }
