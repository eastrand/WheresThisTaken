using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WheresThisTaken.Services
{
    public class PlaceService
    {
        public string apikey = "AIzaSyCiawFuuSofmQhy53w-H7gtz2qWbFQDlNw";
        public async Task<string> GetCandidatesAsync(string cityname, string countrycode)
        {
            string thereturn = "";
            var client = new HttpClient();
            var uri = new Uri("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input="+ cityname + "," + countrycode + "&inputtype=textquery&key="+apikey);
            try
            { 
            var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var jsonData = (JObject)JsonConvert.DeserializeObject(result);
                    var status = jsonData["status"].Value<string>();

                    if (status != "ZERO_RESULTS")
                    {
                        var message = jsonData["candidates"]["place_id"].Value<string>();
                        System.Diagnostics.Debug.WriteLine(message);
                        return message;
                    }
                    else
                        thereturn = status;
                }
                else thereturn = "fail";
            }
            catch { thereturn = "Connection-error"; }
            return thereturn;
        }
    }
}
