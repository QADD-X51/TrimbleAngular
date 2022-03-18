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
    public class CategoryController : ControllerBase
    {
        static List<Category> _categories = new List<Category> {
            new Category { Id="1", Name="To Do"},
            new Category { Id="2", Name="Done"},
            new Category { Id="3", Name="Doing"}
        };

        /// <summary>
        /// Gets the whole list of categories
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categories);
        }

        /// <summary>
        /// Gets only the categories with a certain ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetCategories(string id)
        {
            return Ok(_categories.Where(i => i.Id == id));
        }

        /// <summary>
        /// Adds a new category to the categories list
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddCategories([FromBody] Category category)
        {
            _categories.Add(category);
            return Ok(category);
        }

        /// <summary>
        /// Will delete all the categories with a specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult RemoveCategories(string id)
        {
            _categories.RemoveAll(c => c.Id == id);
            return Ok(_categories);
        }
    }
}
