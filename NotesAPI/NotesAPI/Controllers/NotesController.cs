using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteCollectionService.GetAll());
        }

        /// <summary>
        /// Get all notes of a certain owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("owner:{id}")]
        public async Task<IActionResult> GetNotesByOwner(Guid id)
        {
            return Ok(await _noteCollectionService.GetNotesByOwner(id));
        }

        /// <summary>
        /// Get all notes with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotesID(Guid id)
        {
            try
            {
                return Ok(await _noteCollectionService.Get(id));
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
        public async Task<IActionResult> CreateNote([FromBody] Note note)
        {
            if(note == null)
            {
                return BadRequest("Note should not be null");
            }
            await _noteCollectionService.Create(note);
            return Ok(note);
        }

        /// <summary>
        /// Updates the note with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody]Note note)
        {
            if(note == null)
            {
                return BadRequest("Note should not be null");
            }

            if(!await _noteCollectionService.Update(id, note))
            {
                return NotFound("Note not found");
            }

            return Ok(note);
        }

        /// <summary>
        /// Deletes the note with that certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            if(!await _noteCollectionService.Delete(id))
            {
                return NotFound("Note not found");
            }

            return Ok("Note deleted");
        }

        /// <summary>
        /// Updates the note with a certain ID, of a certain owner's ID. Owner's ID comes first, than the note's.
        /// </summary>
        /// <param name="idOwner"></param>
        /// <param name="idNote"></param>
        /// <param name="note"></param>
        /// <returns></returns>

        [HttpPut("{idOwner}/{idNote}")]
        public async Task<IActionResult> UpdateNoteAdvanced(Guid idOwner, Guid idNote, [FromBody]Note note)
        {
            if (note == null)
            {
                return BadRequest("Note should not be null");
            }

            if (!await _noteCollectionService.UpdateAdvanced(idOwner, idNote, note))
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
        public async Task<IActionResult> DeleteNoteAdvanced(Guid idOwner, Guid idNote)
        {
            if (!await _noteCollectionService.DeleteNoteAdvanced(idOwner, idNote))
            {
                return NotFound("Note not found");
            }

            return Ok("Note deleted");
        }

        /// <summary>
        /// Deletes all notes of an owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("owner:{id}")]
        public async Task<IActionResult> DeleteAllNotesOfOwner(Guid id)
        {
            if (!await _noteCollectionService.DeleteAllNotesOfUser(id))
            {
                return NotFound("Notes not found");
            }

            return Ok("Notes deleted");
        }
    }
}

