using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public interface INoteCollectionService : ICollectionService<Note>
    {

        List<Note> GetNotesByOwner(Guid ownerId);

        public bool UpdateAdvanced(Guid ownerId, Guid noteId, Note note);

        public bool DeleteNoteAdvanced(Guid ownerId, Guid noteId);

        public bool DeleteAllNotesOfUser(Guid id);

    }
}
