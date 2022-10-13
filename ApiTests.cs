using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace URL_tests
{
    public class ApiTests
    {
        private const string BaseUrl = "https://shorturl.nakov.repl.co/api";
        private RestClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            this.client = new RestClient(BaseUrl);
            this.client.Options.Timeout = 3000;

        }
        [Test]
        public void Test_ShortUrlApi_ListShortUrls()
        {
            //arrange
            var request = new RestRequest("/urls", Method.Get);

            //act
            var response = client.Execute(request);

            //assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var urls = System.Text.Json.JsonSerializer.Deserialize<List<UrlResponse>>(response.Content);

            Assert.That(urls!=null, Is.True);
        }

        [Test]
        public void Test_ShortUrlApi_FindShortUrlByCode()
        {
            //arrange
            var request = new RestRequest("/urls/nak", Method.Get);

            //act
            var response = client.Execute(request);

            //assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var expectedUrl = new UrlResponse
            {
                Url = "https://nakov.com",
                ShortCode = "nak",
                ShortURL = "http://shorturl.nakov.repl.co/go/nak",
                DateCreated = "2021-02-17 14:41:33",
                Visits = 160
            };
            
            var responseUrl = JsonConvert.DeserializeObject<UrlResponse>(response.Content);

            AssertEqualObjects(expectedUrl, responseUrl);
        }

        private void AssertEqualObjects(object obj1, object obj2)
        {
            string obj1JSON = System.Text.Json.JsonSerializer.Serialize(obj1);
            string obj2JSON = System.Text.Json.JsonSerializer.Serialize(obj2);
            Assert.AreEqual(obj1JSON, obj2JSON);
        }
    }
}