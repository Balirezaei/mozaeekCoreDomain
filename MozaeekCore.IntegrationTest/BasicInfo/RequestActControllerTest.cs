using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.RestAPI;
using Newtonsoft.Json;
using Xunit;

namespace MozaeekCore.IntegrationTest
{
    public class RequestActControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public RequestActControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task RequestAct_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var title = "Test RequestAct Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreateRequestActCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("/api/RequestAct/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var savedRequestActResponse = await client.GetAsync(response.Headers.Location.AbsolutePath.ToString());

            var savedRequestAct = JsonConvert.DeserializeObject<RequestActDto>(await savedRequestActResponse.Content.ReadAsStringAsync());

            savedRequestAct.Title.Should().Be(title);
        }
    }
}