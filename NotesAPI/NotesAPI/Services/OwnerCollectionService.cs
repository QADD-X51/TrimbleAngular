using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private static List<Owner> _owners = new List<Owner>
        {
            new Owner {Name = "Eu Nutu", Id = Guid.NewGuid()},
            new Owner {Name = "Toby Wider", Id = Guid.NewGuid()},
            new Owner {Name = "Daka Dusk", Id = Guid.NewGuid()}
        };

        public bool Create(Owner owner)
        {
            if(owner == null)
            {
                return false;
            }
            _owners.Add(owner);
            return true;
        }

        public bool Delete(Guid id)
        {
            int index = _owners.FindIndex(owner => owner.Id == id);

            if(index == -1)
            {
                return false;
            }

            _owners.RemoveAt(index);
            return true;
        }

        public Owner Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            return _owners;
        }

        public bool Update(Guid id, Owner owner)
        {
            int index = _owners.FindIndex(ow => ow.Id == id);
            if(index == -1)
            {
                return false;
            }

            owner.Id = id;
            _owners[index] = owner;
            return true;
        }
    }
}
