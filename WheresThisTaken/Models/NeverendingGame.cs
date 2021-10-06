using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using WheresThisTaken.Models;
using WheresThisTaken.Services;

namespace WheresThisTaken.Model
{
    public class NeverendingGame
    {
        PlaceService placeService = new PlaceService();
        int MaxRounds { get; set; }
        List<DistanceRound> Rounds = new List<DistanceRound>();

        public async Task<Place> RandomPlaceAsync() {
            ListDictionary cities = new ListDictionary();
            cities.Add("Oslo", "NO");
            cities.Add("Indianapolis", "US");
            cities.Add("Kalmar", "SE");
            cities.Add("Guadalajara", "MX");
            cities.Add("Alexandria", "EG");
            cities.Add("Santiago", "CL");
            cities.Add("Harare", "ZW");
            cities.Add("Lima", "PE");
            cities.Add("Kathmandu", "NP");
            cities.Add("Bogota", "CO");
            cities.Add("Marseille", "FR");
            cities.Add("Vancouver", "CA");
            cities.Add("Ankara", "TR");
            cities.Add("Casablanca", "MA");
            cities.Add("Bangkok", "TH");
            cities.Add("Canberra", "AU");
            cities.Add("Mumbai", "IN");
            cities.Add("Dar es salaam", "TZ");
            cities.Add("Taipei", "TW");
            cities.Add("Zurich", "CH");
            cities.Add("Novosibirsk", "RU");
            cities.Add("Kyoto", "JP");
            cities.Add("Barcelona", "ES");
            DictionaryEntry[] cityArr = new DictionaryEntry[cities.Count];
            cities.CopyTo(cityArr, 0);
            var Random = new Random();
            int whichcity = Random.Next();
            Place pl = await placeService.GetPlaceAsync(cityArr[whichcity].Key.ToString(), cityArr[whichcity].Value.ToString());
            return pl;
        }

        public void MakeGuess(double lat, double lng)
        {
            DistanceRound round = Rounds.Last();
            round.Guess = new Guess(lat, lng);
            round.CalculateScore();

        }
    }
}
