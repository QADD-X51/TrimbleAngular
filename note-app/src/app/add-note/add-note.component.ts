import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteService } from '../services/note.service';
import { Category } from '../category';
import { FilterService } from '../services/filter.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title: string = "";
  description: string = "";
  idCategoryNote: string = ""
  categories : Array<Category>

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private service: NoteService, private serviceFilter: FilterService) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(parameter =>
      (
        console.log(parameter['id'])
      ))
      this.categories = this.serviceFilter.getCategories();
  }

  AddClick() {
    this.service.addNote(this.title,this.description, this.idCategoryNote).subscribe();
  }

}
