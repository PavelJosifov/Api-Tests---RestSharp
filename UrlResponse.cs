using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace URL_tests
{
    internal class UrlResponse
    {
        public UrlResponse(string url, string shortCode, string shortURL, string dateCreated, int visits)
        {
            this.Url = url;
            this.ShortCode = shortCode;
            this.ShortURL = shortURL;
            this.DateCreated = dateCreated;
            this.Visits = visits;
        }
        public UrlResponse()
        {

        }
        
            

        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }
        [JsonPropertyName("shortUrl")]
        public string ShortURL { get; set; }
        [JsonPropertyName("dateCreated")]
        public string DateCreated   { get; set; }
        [JsonPropertyName("visits")]
        public int Visits { get; set; }


    }
}