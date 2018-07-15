using Newtonsoft.Json;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Dtos;
using Xunit;
using FluentAssertions;
using System.Net;
using Tutoring.Infrastructure.Commands.Users;

namespace Tutoring.Tests.EndToEnd.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "email2@email.com";
            var user = await GetUserAsync(email);
            user.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "e234@email.com";
            var response = await Client.GetAsync($"api/users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "test@email.com",
                Password = "secret",
                Username = "testUser",
                City = "Wrocław",
                Role = "user"
            };

            var payload = GetPayload(request);
            var response = await Client.PostAsync("api/users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"api/users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.Should().BeEquivalentTo(request.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
