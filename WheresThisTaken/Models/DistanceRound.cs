using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheresThisTaken.Model;

namespace WheresThisTaken.Models
{
    public class DistanceRound : IRound
    {
        Place Place { get; set; }

        public DistanceRound(Place place)
        {
            Place = place;
        }

        public int Score { get; set; }

        public Guess Guess { get; set; }


        public int CalculateScore()
        {
            GeoCoordinate PlacePos = new GeoCoordinate(Place.Geometry.position.Lat, Place.Geometry.position.Lng);
            GeoCoordinate GuessPos = new GeoCoordinate(Guess.lat, Guess.lng);
            double ThisScore = 20000 - (PlacePos.GetDistanceTo(GuessPos) / 1000);
            if (ThisScore < 0)
                ThisScore = 0;
            return Convert.ToInt32(ThisScore);
        }
        

    }

    public class Guess
    {
        public Guess(double lat, double lng)
        {
            this.lng = lng;
            this.lat = lat;
        }

        public double lng { get; set; }
        public double lat { get; set; }
    }
}
