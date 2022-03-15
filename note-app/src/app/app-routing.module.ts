import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { DummyrouteComponent } from './dummyroute/dummyroute.component';
import { HomeComponent } from './home/home.component';
import { EditNoteComponent } from './edit-note/edit-note.component';

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch:"full" },
  { path: "add-note/:id", component: EditNoteComponent},
  { path: "add-note", component: AddNoteComponent},
  { path:"dummy-route/:id", component: DummyrouteComponent},
  { path: '**', redirectTo: ''}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
