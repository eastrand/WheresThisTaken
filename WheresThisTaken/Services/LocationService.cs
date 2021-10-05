using WheresThisTaken.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;

namespace WheresThisTaken.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Models.Location> _locations;

        public LocationService(ILocationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _locations = database.GetCollection<Models.Location>(settings.LocationCollectionName);
        }

        public List<Models.Location> Get() =>
            _locations.Find(location => true).ToList();

        public Models.Location Create(Models.Location location)
        {
            _locations.InsertOne(location);
            return location;
        }

        public void Update(string id, Models.Location locationIn) =>
            _locations.ReplaceOne(location => location.Id == id, locationIn);

        public void Remove(Models.Location locationIn) =>
            _locations.DeleteOne(location => location.Id == locationIn.Id);

        public void Remove(string id) =>
            _locations.DeleteOne(location => location.Id == id);
        public List<Models.Location> GetRandom()
        {
            Location loco = new Location();
            var loc = _locations.AsQueryable().Sample(1).ToList();
            System.Diagnostics.Debug.WriteLine(loc.Count);
            return loc;

        }
    }
}