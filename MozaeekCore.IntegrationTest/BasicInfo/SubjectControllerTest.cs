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
    public class SubjectControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public SubjectControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Subject_should_create_successfully()
        {
            var client = _factory.CreateClient();
            var title = "Test Subject Integration " + new Random().Next(1, 1000);
            var json = JsonConvert.SerializeObject(new CreateSubjectCommand() { Title = title });

            var content = new StringContent(json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("/api/Subject/create", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var savedSubjectResponse = await client.GetAsync(response.Headers.Location.AbsolutePath.ToString());

            var savedSubject = JsonConvert.DeserializeObject<SubjectDto>(await savedSubjectResponse.Content.ReadAsStringAsync());

            savedSubject.Title.Should().Be(title);
        }
    }
}