using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public static bool operator ==(Category cat1, Category cat2)
        {
            return cat1.Id == cat2.Id;
        }

        public static bool operator !=(Category cat1, Category cat2)
        {
            return !(cat1 == cat2);
        }
    }
}
