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
    public class OwnerController : ControllerBase
    {
        static List<Owner> _owners = new List<Owner>
        {
            new Owner {Name = "Eu Nutu", Id = Guid.NewGuid()},
            new Owner {Name = "Toby Wider", Id = Guid.NewGuid()},
            new Owner {Name = "Daka Dusk", Id = Guid.NewGuid()}
        };

        /// <summary>
        /// Gets all the owners
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetOwners()
        {
            return Ok(_owners);
        }

        /// <summary>
        /// Adds a new owner to the owner list
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            _owners.Add(owner);
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

            int index = _owners.FindIndex(ownr => ownr.Id == id);

            if(index == -1)
            {
                return NotFound("Owner not found");
            }

            owner.Id = id;
            _owners[index] = owner;

            return Ok(_owners);
        }

        /// <summary>
        /// Delets the owner with the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult RemoveOwner(Guid id)
        {
            int index = _owners.FindIndex(ownr => ownr.Id == id);

            if (index == -1)
            {
                return NotFound("Owner not found");
            }

            _owners.RemoveAt(index);
            return Ok(_owners);
        }
    }
}
