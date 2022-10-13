using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace URL_tests
{

    internal class ZippopotamusResponse
    {
        public ZippopotamusResponse(string postcode, string country, string countryabbreviation, Place[]places)
        {
            this.PostCode = postcode;
            this.Country = country;
            this.CountryAbbreviation = countryabbreviation;
            this.Places = places;
        }
        public ZippopotamusResponse()
        {

        }

        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonPropertyName("places")]
        public Place[] Places { get; set; }


    }
    public class Place
    {
        public Place(string placename, string longtitude, string state, string stateabbreviation, string latitude)
        {
            this.PlaceName = placename;
            this.Longitude = longtitude;
            this.State = state;
            this.StateAbbreviation = stateabbreviation;
            this.Latitude = latitude;
        }
        public Place()
        {

        }
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

    }
}
