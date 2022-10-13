using RestSharp;
using System.Net;
using System.Text.Json;

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

            var urls = JsonSerializer.Deserialize<List<UrlResponse>>(response.Content);

            Assert.That(urls!=null, Is.True);
        }

    }
}