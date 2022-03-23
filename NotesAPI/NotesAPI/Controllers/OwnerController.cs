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
    public class OwnerController : ControllerBase
    {
        IOwnerCollectionService _ownerCollectionService;

        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService ?? throw new ArgumentNullException(nameof(ownerCollectionService));
        }


        /// <summary>
        /// Gets all the owners
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetOwners()
        {
            return Ok(_ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Adds a new owner to the owner list
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if(!_ownerCollectionService.Create(owner))
            {
                return BadRequest("Owner can't be null");
            }
            return Ok(owner);
        }

        /// <summary>
        /// Updates an owner with a certain ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if(owner == null)
            {
                return BadRequest("Owner shall not be null");
            }

            if(!_ownerCollectionService.Update(id, owner))
            {
                return NotFound("Owner not found");
            }

            return Ok(_ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Delets the owner with the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult RemoveOwner(Guid id)
        {
            if(!_ownerCollectionService.Delete(id))
            {
                return NotFound("Owner not found");
            }

            return Ok(_ownerCollectionService.GetAll());
        }
    }
}
