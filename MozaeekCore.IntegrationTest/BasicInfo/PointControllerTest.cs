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
    public class PointControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public PointControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Point_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var title = "Test Point Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreatePointCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("/api/Point/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var savedPointResponse = await client.GetAsync(response.Headers.Location.AbsolutePath.ToString());

            var savedPoint = JsonConvert.DeserializeObject<PointDto>(await savedPointResponse.Content.ReadAsStringAsync());

            savedPoint.Title.Should().Be(title);
        }
    }
}