using MongoDB.Bson;
using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NoteCollectionName);

        }

        public async Task<List<Note>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<Note> Get(Guid id)
        {
            var result = await _notes.FindAsync(note => note.Id == id);
            if(result.ToList().Count == 0)
            {
                throw new Exception("Not Found");
            }
            return result.ToList()[0];
        }

        public async Task<bool> Create(Note note)
        {
            if(note.Id == Guid.Empty)
            {
                note.Id = Guid.NewGuid();
            }
            note.OwnerId = Guid.NewGuid();
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Update(Guid id, Note note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(n => n.Id == id, note);

            if (!result.IsAcknowledged || result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }

            return true;

        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Note>> GetNotesByOwner(Guid ownerId)
        {
            return (await _notes.FindAsync(note => note.OwnerId == ownerId)).ToList();
        }

        public async Task<bool> UpdateAdvanced(Guid ownerId, Guid noteId, Note note)
        {
            note.Id = noteId;
            note.OwnerId = ownerId;
            var result = await _notes.ReplaceOneAsync(n => n.Id == noteId && n.OwnerId == ownerId, note);

            if (!result.IsAcknowledged || result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteNoteAdvanced(Guid ownerId, Guid noteId)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == noteId && note.OwnerId == ownerId);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAllNotesOfUser(Guid id)
        {
            var result = await _notes.DeleteManyAsync(note => note.OwnerId == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

    }
}
