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
      description: "This is the description for the first note",
      categoryId: '1'
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note",
      categoryId: '2'
    },
    {
      id: "Id3",
      title: "Third note",
      description: "Test",
      categoryId: '3'
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
    let note: Note = { 
      id: "Id" + (parseInt(this.notes[this.notes.length - 1].id.substring(2)) + 1).toString,
      title: inputTitle,
      description: inputDescription,
      categoryId: '0'
    }

    this.notes.push(note);
  }

  getFiltredNotes(categoryId: string) {
    //   return this.notes.filter((note) => {
    //   note.categoryId === categoryId;
    // })
    return this.notes.filter(note => note.categoryId === categoryId);
  }

  getSearchFiltered(input: string) {
    return this.notes.filter(note => note.title.includes(input) === true);
  }
}
