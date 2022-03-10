import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title: string = "";
  description: string = "";

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private service: NoteService) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(parameter =>
      (
        console.log(parameter['id'])
      ))
  }

  AddClick() {
    this.service.addNote(this.title,this.description);
  }

}
