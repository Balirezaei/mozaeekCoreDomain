using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.RestAPI;
using Newtonsoft.Json;
using Xunit;

namespace MozaeekCore.IntegrationTest
{
    public class LableControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public LableControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Lable_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var json = JsonConvert.SerializeObject(new CreateLableCommand(){Title = "TestFrom Integration"});
            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");
            
            var response = await client.PostAsync("/api/lable/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);


        }
    }
}