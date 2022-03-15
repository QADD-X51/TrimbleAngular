import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import { FormsModule } from '@angular/forms';

import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import { FilterComponent } from './filter/filter.component';
import { AddNoteComponent } from './add-note/add-note.component';
import { HomeComponent } from './home/home.component';
import { DummyrouteComponent } from './dummyroute/dummyroute.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpMockApiInterceptor } from './services/http-mock-api.interceptor';
import {MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    FilterComponent,
    AddNoteComponent,
    HomeComponent,
    DummyrouteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatCardModule,
    FormsModule,
    CommonModule,
    HttpClientModule,
    MatSelectModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpMockApiInterceptor,
    multi: true
  }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
