import { Injectable } from '@angular/core';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note"
    },
    {
      id: "Id3",
      title: "Third note",
      description: "Test"
    }
  ];

  constructor() { }

  serviceCall() {
    console.log("Note service was called!");
  }

  getNotes(): Note[] {
    return this.notes;
  }

  addNote(inputTitle: string, inputDescription:string) {
    let note: Note;
    note.id = "Id" + (parseInt(this.notes[this.notes.length - 1].id.substring(2)) + 1).toString;
    note.title = inputTitle;
    note.description = inputDescription;
    this.notes.push(note);
  }
}
