using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace WheresThisTaken.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longditude { get; set; }

        [BsonElement("country_code")]
        public string Countrycode { get; set; }

        public static explicit operator Location(List<Location> v)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name + "," + Countrycode;
        }
    }
}
