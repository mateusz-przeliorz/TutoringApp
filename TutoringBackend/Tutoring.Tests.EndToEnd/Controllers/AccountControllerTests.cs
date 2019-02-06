using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Commands.Users;
using Tutoring.Infrastructure.Dtos;
using Xunit;

namespace Tutoring.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {    
        [Fact]
        public async Task given_nonexistent_email_current_password_should_not_be_changed_and_user_should_not_exist()
        {
            var email = "nonexistent@email.com";
            
            var request = new ChangeUserPassword()
            {
                Email = email,
                NewPassword = "newpassword"
            };

            var payload = GetPayload(request);
            var response = await Client.PutAsync("api/account", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);

            response = await Client.GetAsync($"api/users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
