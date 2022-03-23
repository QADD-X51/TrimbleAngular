using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public interface INoteCollectionService : ICollectionService<Note>
    {

        Task<List<Note>> GetNotesByOwner(Guid ownerId);

        public Task<bool> UpdateAdvanced(Guid ownerId, Guid noteId, Note note);

        public Task<bool> DeleteNoteAdvanced(Guid ownerId, Guid noteId);

        public Task<bool> DeleteAllNotesOfUser(Guid id);

    }
}
