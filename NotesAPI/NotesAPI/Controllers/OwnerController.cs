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
    }
}
