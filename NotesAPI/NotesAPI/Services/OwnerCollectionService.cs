using MongoDB.Bson;
using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private readonly IMongoCollection<Owner> _owner;

        public OwnerCollectionService(IMongoDBOwnerSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owner = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }

        public async Task<bool> Create(Owner owner)
        {
            await _owner.InsertOneAsync(owner);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _owner.DeleteOneAsync(ow => ow.Id == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> Get(Guid id)
        {
            var result = await _owner.FindAsync(ow => ow.Id == id);
            if (result.ToList().Count == 0)
            {
                throw new Exception("Not Found");
            }
            return result.ToList()[0];
        }

        public async Task<List<Owner>> GetAll()
        {
            var result = await _owner.FindAsync(ow => true);
            return result.ToList();
        }

        public async Task<bool> Update(Guid id, Owner owner)
        {
            owner.Id = id;
            var result = await _owner.ReplaceOneAsync(n => n.Id == id, owner);

            if (!result.IsAcknowledged || result.ModifiedCount == 0)
            {
                await _owner.InsertOneAsync(owner);
                return false;
            }

            return true;
        }
    }
}
