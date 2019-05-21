using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApiDatabase.Models;
using Xunit;

namespace EFCoreWebAPI.Test
{
    public class ActorsControllerEndToEndTest
    {
        [Fact]
        public async void GetActorByIdSmokeTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpClient.GetAsync("api/actors/ById?id=101");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Actor actor = JsonConvert.DeserializeObject<Actor>(jsonString);
                Assert.NotNull(actor);
                Assert.Equal(actor.Id, 101);
                Assert.Equal(actor.FirstName, "SUSAN");
                Assert.Equal(actor.LastName, "DAVIS");
            }
        }
    }
}