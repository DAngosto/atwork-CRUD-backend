using atwork_CRUD_backend_Application.DTOs.Auth;
using atwork_CRUD_backend_Application.DTOs.Employees;
using Bogus;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace atwork_CRUD_backend_Tests.IntegrationTests
{
    public class EmployeesControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public EmployeesControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Create_ShouldReturnCreated_WhenRequestIsValid()
        {
            var client = await GetAuthenticatedClientAsync();

            var createRequest = GenerateRandomCreateEmployeeRequest();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Employees", jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var employeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonResponse);

            Assert.NotNull(employeeDto);
            Assert.NotEqual(Guid.Empty, employeeDto.Id);
        }

        [Fact]
        public async Task GetEmployee_ShouldReturnOk_WhenEmployeeExists()
        {
            var client = await GetAuthenticatedClientAsync();

            var createRequest = GenerateRandomCreateEmployeeRequest();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("/Employees", jsonContent);
            createResponse.EnsureSuccessStatusCode();

            var jsonCreateResponse = await createResponse.Content.ReadAsStringAsync();
            var createdEmployeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonCreateResponse);

            var response = await client.GetAsync($"/Employees?employeeId={createdEmployeeDto!.Id}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var employeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonResponse);

            Assert.NotNull(employeeDto);
        }

        [Fact]
        public async Task Update_ShouldReturnOk_WhenRequestIsValid()
        {
            var client = await GetAuthenticatedClientAsync();

            var createRequest = GenerateRandomCreateEmployeeRequest();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("/Employees", jsonContent);
            createResponse.EnsureSuccessStatusCode();

            var jsonCreateResponse = await createResponse.Content.ReadAsStringAsync();
            var createdEmployeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonCreateResponse);

            var updateRequest = GenerateRandomUpdateEmployeeRequest(createdEmployeeDto!.Id);
            var updateJsonContent = new StringContent(JsonConvert.SerializeObject(updateRequest), Encoding.UTF8, "application/json");

            var updateResponse = await client.PutAsync("/Employees", updateJsonContent);
            updateResponse.EnsureSuccessStatusCode();

            var jsonUpdateResponse = await updateResponse.Content.ReadAsStringAsync();
            var updatedEmployeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonUpdateResponse);

            Assert.NotNull(updatedEmployeeDto);
            Assert.NotEqual(createdEmployeeDto, updatedEmployeeDto);
        }

        [Fact]
        public async Task DeleteEmployees_ShouldReturnNoContent_WhenEmployeeExists()
        {
            var client = await GetAuthenticatedClientAsync();

            var createRequest = GenerateRandomCreateEmployeeRequest();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

            var createResponse = await client.PostAsync("/Employees", jsonContent);
            createResponse.EnsureSuccessStatusCode();

            var jsonCreateResponse = await createResponse.Content.ReadAsStringAsync();
            var createdEmployeeDto = JsonConvert.DeserializeObject<EmployeeDto>(jsonCreateResponse);

            var deleteResponse = await client.DeleteAsync($"/Employees?employeeId={createdEmployeeDto!.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenEmployeesExist()
        {
            var client = await GetAuthenticatedClientAsync();

            var createRequest = GenerateRandomCreateEmployeeRequest();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");

            var createResponse = await client.PostAsync("/Employees", jsonContent);
            createResponse.EnsureSuccessStatusCode();

            var response = await client.GetAsync($"/Employees/GetAllFromUser?userId={createRequest.UserId}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var employeesList = JsonConvert.DeserializeObject<GetAllEmployeesFromUserDto>(jsonResponse);

            Assert.NotNull(employeesList);
            Assert.NotEmpty(employeesList.Data);
        }

        private async Task<HttpClient> GetAuthenticatedClientAsync()
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

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return client;
        }

        private static CreateEmployeeRequest GenerateRandomCreateEmployeeRequest()
        {
            var jobTitles = new[]
            {
                "Software Engineer",
                "Product Manager",
                "Designer",
                "Data Scientist",
                "System Administrator",
                "Marketing Specialist",
                "Sales Associate",
                "Project Manager",
                "Quality Assurance Engineer",
                "Business Analyst"
            };
            var faker = new Faker<CreateEmployeeRequest>()
                .RuleFor(r => r.UserId, Guid.Parse("9C7A736B-26A9-4100-A936-8CA9879857F3")) // Test user id set in CustomWebApplicationFactory.cs
                .RuleFor(r => r.FirstName, f => f.Person.FirstName)
                .RuleFor(r => r.LastName, f => f.Person.LastName)
                .RuleFor(r => r.SecondLastName, f => f.Person.LastName)
                .RuleFor(r => r.Email, f => f.Internet.Email())
                .RuleFor(r => r.JobTitle, f => f.PickRandom(jobTitles))
                .RuleFor(r => r.Address, f => f.Address.FullAddress())
                .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.Country, Guid.Parse("421F1CFB-BE71-4422-BE33-87C16A673A84")); // Test country id set in CustomWebApplicationFactory.cs
            return faker.Generate();
        }

        private static UpdateEmployeeRequest GenerateRandomUpdateEmployeeRequest(Guid employeeId)
        {
            var jobTitles = new[]
            {
                "Software Engineer",
                "Product Manager",
                "Designer",
                "Data Scientist",
                "System Administrator",
                "Marketing Specialist",
                "Sales Associate",
                "Project Manager",
                "Quality Assurance Engineer",
                "Business Analyst"
            };
            var faker = new Faker<UpdateEmployeeRequest>()
                .RuleFor(r => r.EmployeeId, employeeId)
                .RuleFor(r => r.FirstName, f => f.Person.FirstName)
                .RuleFor(r => r.LastName, f => f.Person.LastName)
                .RuleFor(r => r.SecondLastName, f => f.Person.LastName)
                .RuleFor(r => r.Email, f => f.Internet.Email())
                .RuleFor(r => r.JobTitle, f => f.PickRandom(jobTitles))
                .RuleFor(r => r.Address, f => f.Address.FullAddress())
                .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.Country, Guid.Parse("421F1CFB-BE71-4422-BE33-87C16A673A84")); // Test country id set in CustomWebApplicationFactory.cs
            return faker.Generate();
        }
    }
}