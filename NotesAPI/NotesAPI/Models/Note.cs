using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class Note
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "BOOOOOM")]
        public string CategoryId { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "works")] 
        public Guid? OwnerId { get; set; } // the ? makes the value nullable, Required won't work if it isn't nullable
    }
}
