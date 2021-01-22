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
    public class RequestTargetControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public RequestTargetControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task RequestTarget_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var title = "Test RequestTarget Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreateRequestTargetCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("/api/RequestTarget/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var savedRequestTargetResponse = await client.GetAsync(response.Headers.Location.AbsolutePath.ToString());

            var savedRequestTarget = JsonConvert.DeserializeObject<RequestTargetDto>(await savedRequestTargetResponse.Content.ReadAsStringAsync());

            savedRequestTarget.Title.Should().Be(title);
        }
    }
}