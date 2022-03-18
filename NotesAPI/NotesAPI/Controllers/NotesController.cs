using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public NotesController() { }

        static List<Note> _notes = new List<Note> { new Note { Id = Guid.NewGuid(), CategoryId = "3", OwnerId = Guid.NewGuid(), Title = "First Stage", Description = "First Note Description - Denial" },
        new Note { Id = Guid.NewGuid(), CategoryId = "3", OwnerId = Guid.NewGuid(), Title = "Second Stage", Description = "Second Note Description - Anger" },
        new Note { Id = Guid.NewGuid(), CategoryId = "3", OwnerId = Guid.NewGuid(), Title = "Third Stage", Description = "Third Note Description - Bargaining" },
        new Note { Id = Guid.NewGuid(), CategoryId = "2", OwnerId = Guid.NewGuid(), Title = "Fourth Stage", Description = "Fourth Note Description - Depression" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fifth Stage", Description = "Fifth Note Description - Acceptance" }
        };


        /// <summary>
        /// Gets all notes
        /// </summary>
        /// <return></return>

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }

        /// <summary>
        /// Get all notes of a certain owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("owner:{id}")]
        public IActionResult GetNotesByOwner(Guid id)
        {
            return Ok(_notes.Where(note => note.OwnerId == id));
        }

        /// <summary>
        /// Get all notes with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetNotesID(Guid id)
        {
            return Ok(_notes.Where(note => note.Id == id));
        }

        /// <summary>
        /// Creates a new note
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult CreateNotes([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(note);
        }
    }
}

