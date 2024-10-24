using atwork_CRUD_backend_Application.DTOs.Auth;
using atwork_CRUD_backend_Domain.Entities;
using Bogus;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace atwork_CRUD_backend_Tests.IntegrationTests
{
    public class AuthControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public AuthControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Login_ShouldReturnOk_WhenCredentialsAreValid()
        {
            var client = _factory.CreateClient();

            var loginRequest = new LoginRequest
            {
                Email = "testuser@example.com",
                Password = "admin"
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Auth/login", jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginDto>(jsonResponse);

            Assert.NotNull(loginResponse);
            Assert.NotEqual(Guid.Empty, loginResponse!.UserId);

            Assert.False(string.IsNullOrWhiteSpace(loginResponse.Token), "Token was empty in the response");
            Assert.True(loginResponse.Token.Split('.').Length == 3, "Token does not have the expected structure of a JWT");
        }

        [Fact]
        public async Task Register_ShouldReturnOk_WhenRequestIsValid()
        {
            var client = _factory.CreateClient();

            var registerRequest = GenerateRandomRegisterRequest();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Auth/register", jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var registerResponse = JsonConvert.DeserializeObject<RegisterDto>(jsonResponse);

            Assert.NotNull(registerResponse);
            Assert.NotEqual(Guid.Empty, registerResponse!.UserId);

            Assert.False(string.IsNullOrWhiteSpace(registerResponse.Token), "Token was empty in the response");
            Assert.True(registerResponse.Token.Split('.').Length == 3, "Token does not have the expected structure of a JWT");
        }

        [Fact]
        public async Task RegisterAndLogin_ShouldReturnOk_WhenRequestIsValid()
        {
            var client = _factory.CreateClient();

            // Register
            var registerRequest = GenerateRandomRegisterRequest();
            var registerJsonContent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");

            var registerResponse = await client.PostAsync("/Auth/register", registerJsonContent);
            registerResponse.EnsureSuccessStatusCode();

            // Login
            var loginRequest = new LoginRequest
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password
            };
            var loginJsonContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            var loginResponse = await client.PostAsync("/Auth/login", loginJsonContent);
            loginResponse.EnsureSuccessStatusCode();

            var loginJsonResponse = await loginResponse.Content.ReadAsStringAsync();
            var loginResult = JsonConvert.DeserializeObject<RegisterDto>(loginJsonResponse);

            Assert.NotNull(loginResult);
            Assert.NotEqual(Guid.Empty, loginResult!.UserId);
            Assert.False(string.IsNullOrWhiteSpace(loginResult.Token), "Token was empty in the response");
            Assert.True(loginResult.Token.Split('.').Length == 3, "Token does not have the expected structure of a JWT");
        }

        [Fact]
        public async Task Register_ShouldReturnBadRequest_WhenEmailIsInvalid()
        {
            var client = _factory.CreateClient();

            var registerRequest = GenerateRandomRegisterRequest();
            registerRequest.Email = "invalid_email";
            var registerJsonContent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Auth/register", registerJsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("email parameter provided is not a valid email", jsonResponse);
        }

        [Fact]
        public async Task Login_ShouldReturnUnauthorized_WhenUserDoesNotExists()
        {
            var client = _factory.CreateClient();

            var loginRequest = GenerateRandomLoginRequest();
            var registerJsonContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Auth/login", registerJsonContent);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains(UserErrors.InvalidUsernameOrPassword(), jsonResponse);
        }

        private static RegisterRequest GenerateRandomRegisterRequest()
        {
            var faker = new Faker<RegisterRequest>()
                .RuleFor(r => r.Email, f => f.Internet.Email())
                .RuleFor(r => r.Password, f => f.Internet.Password())
                .RuleFor(r => r.Company, f => f.Company.CompanyName())
                .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber());
            return faker.Generate();
        }

        private static LoginRequest GenerateRandomLoginRequest()
        {
            var faker = new Faker<LoginRequest>()
                .RuleFor(r => r.Email, f => f.Internet.Email())
                .RuleFor(r => r.Password, f => f.Internet.Password());
            return faker.Generate();
        }
    }
}