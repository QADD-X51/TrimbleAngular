import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  // notes: Note[] = [
  //   {
  //     id: "Id1",
  //     title: "First note",
  //     description: "This is the description for the first note",
  //     categoryId: '1'
  //   },
  //   {
  //     id: "Id2",
  //     title: "Second note",
  //     description: "This is the description for the second note",
  //     categoryId: '2'
  //   },
  //   {
  //     id: "Id3",
  //     title: "Third note",
  //     description: "Test",
  //     categoryId: '3'
  //   }
  // ];

  readonly baseUrl= "https://localhost:4200";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  serviceCall() {
    console.log("Note service was called!");
  }

  getNotes(): Observable<Array<Note>> {
    return this.httpClient.get<Array<Note>>(this.baseUrl + "/notes", this.httpOptions);
  }

  getNote(ID:string){
    return this.httpClient.get<Array<Note>>(this.baseUrl + "/notes", this.httpOptions).pipe(map((notes:Array<Note>) =>
      { return notes.filter(note => note.id === ID)}));
  }

  getFiltredNotes(categoryId: string): Observable<Array<Note>> {
    return this.httpClient.get<Array<Note>>(this.baseUrl + "/notes",this.httpOptions).pipe(map((notes:Array<Note>) => 
      { return notes.filter(note => note.categoryId === categoryId); }));
  }

  addNote(inputTitle: string, inputDescription:string, inputCategory:string = '0') {
    
    let subscribeID = this.httpClient.get<Array<Note>>(this.baseUrl + "/notes",this.httpOptions).pipe(map((notes:Array<Note>) => 
    { return notes[notes.length - 1].id.substring(2); }));
    let lastID:string;

    subscribeID.subscribe((input:string) => {lastID = input});

    let note: Note = { 
      id: "Id" + (parseInt(lastID) + 1).toString(),
      title: inputTitle,
      description: inputDescription,
      categoryId: inputCategory
    }
    console.log(note.id);
    return this.httpClient.post(this.baseUrl + "/notes", note, this.httpOptions);
  }

  editNote(inputID: string,inputTitle: string, inputDescription:string, inputCategory:string = '0') {
    
    let note: Note = { 
      id: inputID,
      title: inputTitle,
      description: inputDescription,
      categoryId: inputCategory
    }

    return this.httpClient.put(this.baseUrl + "/notes/" + inputID, note ,this.httpOptions)
  }

  removeNote(inputID:string)
  {
    console.log(inputID);
    return this.httpClient.delete(this.baseUrl + '/notes/' + inputID, this.httpOptions);
  }

  //these funtions were used when notes was array was kept internally in TS

  // getNotes(): Note[] {
  //   return this.notes;
  // }

  // addNote(inputTitle: string, inputDescription:string) {
  //   let note: Note = { 
  //     id: "Id" + (parseInt(this.notes[this.notes.length - 1].id.substring(2)) + 1).toString,
  //     title: inputTitle,
  //     description: inputDescription,
  //     categoryId: '0'
  //   }

  //   this.notes.push(note);
  // }

  // getFiltredNotes(categoryId: string) {
  //   //   return this.notes.filter((note) => {
  //   //   note.categoryId === categoryId;
  //   // })
  //   return this.notes.filter(note => note.categoryId === categoryId);
  // }

  // getSearchFiltered(input: string) {
  //   return this.notes.filter(note => note.title.includes(input) === true);
  // }
}
