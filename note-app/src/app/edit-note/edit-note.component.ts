import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../category';
import { Note } from '../note';
import { FilterService } from '../services/filter.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {

  title: string = "";
  id: string = "";
  description: string = "";
  idCategoryNote: string = ""
  categories : Array<Category>

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private service: NoteService, private serviceFilter: FilterService) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(parameter =>
      {
        let noteInfo: Note;
        this.service.getNote(parameter['id']).subscribe((notes:Note[]) => {noteInfo = notes[0]});

        this.id = parameter['id'];
        this.title = noteInfo.title;
        this.description = noteInfo.description;
        this.idCategoryNote = noteInfo.categoryId;
      })
      this.categories = this.serviceFilter.getCategories();
  }

  EditClick() {
    this.service.editNote(this.id ,this.title,this.description, this.idCategoryNote).subscribe();
  }
}
