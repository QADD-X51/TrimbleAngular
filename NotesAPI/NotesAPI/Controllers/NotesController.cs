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

        private static List<Note> _notes = new List<Note> 
        { 
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
            new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
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
        public IActionResult CreateNote([FromBody] Note note)
        {
            if(note == null)
            {
                return BadRequest("Note should not be null");
            }
            _notes.Add(note);
            return Ok(note);
        }

        /// <summary>
        /// Updates the note with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody]Note note)
        {
            if(note == null)
            {
                return BadRequest("Note should not be null");
            }

            int index = _notes.FindIndex(n => n.Id == id);

            if(index == -1)
            {
                //return NotFound("Note ID not found");
                return CreateNote(note);
            }

            note.Id = id;
            _notes[index] = note;
            return Ok(_notes);
        }

        /// <summary>
        /// Deletes the note with that certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            int index = _notes.FindIndex(n => n.Id == id);

            if(index == -1)
            {
                return NotFound("Note not found");
            }

            _notes.RemoveAt(index);
            return Ok(_notes);
        }

        /// <summary>
        /// Updates the note with a certain ID, of a certain owner's ID. Owner's ID comes first, than the note's.
        /// </summary>
        /// <param name="idOwner"></param>
        /// <param name="idNote"></param>
        /// <param name="note"></param>
        /// <returns></returns>

        [HttpPut("{idOwner}/{idNote}")]
        public IActionResult UpdateNoteAdvanced(Guid idOwner, Guid idNote, [FromBody]Note note)
        {
            if (note == null)
            {
                return BadRequest("Updated note should not be null");
            }

            int index = _notes.FindIndex(n => n.Id == idNote && n.OwnerId == idOwner);

            if (index == -1)
            {
                return NotFound("Note not found");
            }

            note.Id = idNote;
            note.OwnerId = idOwner;
            _notes[index] = note;
            return Ok(_notes);
        }

        /// <summary>
        /// Deletes a note with the input ID, of a certain owner's ID. Owner's ID comes first, than the note's.
        /// </summary>
        /// <param name="idOwner"></param>
        /// <param name="idNote"></param>
        /// <returns></returns>

        [HttpDelete("{idOwner}/{idNote}")]
        public IActionResult DeleteNoteAdvanced(Guid idOwner, Guid idNote)
        {
            int index = _notes.FindIndex(n => n.Id == idNote && n.OwnerId == idOwner);

            if (index == -1)
            {
                return NotFound("Note not found");
            }

            _notes.RemoveAt(index);
            return Ok(_notes);
        }

        /// <summary>
        /// Deletes all notes of an owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("owner:{id}")]
        public IActionResult DeleteAllNotesOfOwner(Guid id)
        {
            if(_notes.RemoveAll(note => note.OwnerId == id) == 0)
            {
                return NotFound("Owner has no notes");
            }

            return Ok(_notes);
        }
    }
}

