using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private static List<Note> _notes = new List<Note>
        {
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };

        public bool Create(Note note)
        {
            _notes.Add(note);
            return true;
        }

        public bool Delete(Guid id)
        {
            int index = _notes.FindIndex(note => note.Id == id);
            if(index == -1)
            {
                return false;
            }
            _notes.RemoveAt(index);
            return true;
        }

        public Note Get(Guid id)
        {
            int index = _notes.FindIndex(note => note.Id == id);
            if (index == -1)
            {
                throw new Exception("Not Found");
            }
            return _notes[index];
        }

        public List<Note> GetAll()
        {
            return _notes;
        }

        public List<Note> GetNotesByOwner(Guid ownerId)
        {
            return _notes.FindAll(note => note.OwnerId == ownerId);
        }

        public bool Update(Guid id, Note note)
        {

            int index = _notes.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                return false;
            }

            note.Id = id;
            _notes[index] = note;
            return true;
        }

        public bool UpdateAdvanced(Guid ownerId, Guid noteId, Note note)
        {
            int index = _notes.FindIndex(n => n.Id == noteId && n.OwnerId == ownerId);
            if (index == -1)
            {
                return false;
            }

            note.Id = noteId;
            note.OwnerId = ownerId;
            _notes[index] = note;
            return true;
        }

        public bool DeleteNoteAdvanced(Guid ownerId, Guid noteId)
        {
            int index = _notes.FindIndex(n => n.Id == noteId && n.OwnerId == ownerId);
            if (index == -1)
            {
                return false;
            }

            _notes.RemoveAt(index);
            return true;
        }

        public bool DeleteAllNotesOfUser(Guid id)
        {
            if (_notes.RemoveAll(note => note.OwnerId == id) == 0)
            {
                return false;
            }

            return true;
        }
    }
}
