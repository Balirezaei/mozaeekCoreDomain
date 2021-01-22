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
    public class RequestOrgControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public RequestOrgControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task RequestOrg_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var title = "Test RequestOrg Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreateRequestOrgCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("/api/RequestOrg/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var savedRequestOrgResponse = await client.GetAsync(response.Headers.Location.AbsolutePath.ToString());

            var savedRequestOrg = JsonConvert.DeserializeObject<RequestOrgDto>(await savedRequestOrgResponse.Content.ReadAsStringAsync());

            savedRequestOrg.Title.Should().Be(title);
        }
    }
}