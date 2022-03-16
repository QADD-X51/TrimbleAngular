import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})

export class NoteComponent implements OnInit, OnChanges {

  notes: Array<Note>;

  @Input() selectedCategoryId: string;
  @Input() selectedSearchFilter: string;

  constructor( private service: NoteService) { }

  ngOnInit(): void {
    this.service.serviceCall();
    //this.notes = this.service.getNotes();
  }


  ngOnChanges(): void {

    this.service.getNotes().subscribe((notes:Array<Note>) => {this.notes = notes});

    console.log(this.selectedCategoryId);
    if (this.selectedCategoryId) {
      //this.notes = this.service.getFiltredNotes(this.selectedCategoryId);
      this.service.getFiltredNotes(this.selectedCategoryId).subscribe((notes:Array<Note>) => {this.notes = notes});
    }

    console.log(this.selectedSearchFilter);
    if(this.selectedSearchFilter){
      //this.notes = this.service.getSearchFiltered(this.selectedSearchFilter);
      this.service.getSearchFiltered(this.selectedSearchFilter).subscribe((notes:Array<Note>) => {this.notes = notes});
    }

  }

  public DeleteNote(target:string) {
    this.service.removeNote(target).subscribe();
    this.ngOnChanges();
  }

}
