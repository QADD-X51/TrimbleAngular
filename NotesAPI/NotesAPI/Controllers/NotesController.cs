using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Services;
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
        INoteCollectionService _noteCollectionService;

        public NotesController(INoteCollectionService noteCollectionService) 
        {
            _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService)); //if right side of = is null, throw exception
        }


        /// <summary>
        /// Gets all notes
        /// </summary>
        /// <return></return>

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_noteCollectionService.GetAll());
        }

        /// <summary>
        /// Get all notes of a certain owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("owner:{id}")]
        public IActionResult GetNotesByOwner(Guid id)
        {
            return Ok(_noteCollectionService.GetNotesByOwner(id));
        }

        /// <summary>
        /// Get all notes with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetNotesID(Guid id)
        {
            try
            {
                return Ok(_noteCollectionService.Get(id));
            }
            catch(Exception e)
            {
                return NotFound("Note not found");
            }
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
            _noteCollectionService.Create(note);
            return Ok(_noteCollectionService.GetAll());
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

            if(!_noteCollectionService.Update(id, note))
            {
                return NotFound("Note not found");
            }

            return Ok(_noteCollectionService.GetAll());
        }

        /// <summary>
        /// Deletes the note with that certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            if(!_noteCollectionService.Delete(id))
            {
                return NotFound("Note not found");
            }

            return Ok(_noteCollectionService.GetAll());
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
                return BadRequest("Note should not be null");
            }

            if (!_noteCollectionService.UpdateAdvanced(idOwner, idNote, note))
            {
                return NotFound("Note not found");
            }

            return Ok(_noteCollectionService.GetAll());
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
            if (!_noteCollectionService.DeleteNoteAdvanced(idOwner, idNote))
            {
                return NotFound("Note not found");
            }

            return Ok(_noteCollectionService.GetAll());
        }

        /// <summary>
        /// Deletes all notes of an owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("owner:{id}")]
        public IActionResult DeleteAllNotesOfOwner(Guid id)
        {
            if(!_noteCollectionService.DeleteAllNotesOfUser(id))
            {
                return NotFound("Notes not found");
            }

            return Ok(_noteCollectionService.GetAll());
        }
    }
}

