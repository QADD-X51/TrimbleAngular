import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatButtonModule} from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { Dummy1Module } from './dummy1/dummy1.module';
import { ToolsComponent } from './tools/tools.component';
import { AddValuePipe } from './add-value.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ToolsComponent,
    AddValuePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    Dummy1Module
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
