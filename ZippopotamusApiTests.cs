using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace URL_tests
{
    public class ZippopotamusApiTests
    {
        private const string BaseUrl = "https://api.zippopotam.us";
        private RestClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            this.client = new RestClient(BaseUrl);
            this.client.Options.Timeout = 3000;

        }
        [Test]
        public void Test_Zippopotamus_Responses()
        {
            //arrange
            var request = new RestRequest("/bg/7000", Method.Get);

            //act
            var response = client.Execute(request);

            //assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var ActualResult = System.Text.Json.JsonSerializer.Deserialize<ZippopotamusResponse>(response.Content);
            var Places = new List<Place>()
            {
                new Place(){PlaceName = "Русе / Ruse" },
                new Place(){ Longitude = "25.9708" },
                new Place(){ State = "Русе / Ruse" },
                new Place(){ StateAbbreviation = "RSE" },
                new Place(){ Latitude = "43.8564" }
            };
            var expectedResponse = new ZippopotamusResponse("7000", "Bulgaria", "BG", Places);

            AssertEqualObjects(expectedResponse, ActualResult);

        }
        private void AssertEqualObjects(object obj1, object obj2)
        {
            string obj1JSON = System.Text.Json.JsonSerializer.Serialize(obj1);
            string obj2JSON = System.Text.Json.JsonSerializer.Serialize(obj2);
            Assert.AreEqual(obj1JSON, obj2JSON);
        }
    }
}
