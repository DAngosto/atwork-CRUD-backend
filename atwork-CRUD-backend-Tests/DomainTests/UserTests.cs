using atwork_CRUD_backend_Domain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace atwork_CRUD_backend_Tests.DomainTests
{
    public class UserTests
    {
        [Fact]
        public void User_Creation_ShouldCreateValidUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Email = "test@example.com",
                Password = "Test1234!",
                Company = "TestCompany",
                Phone = "1234567890"
            };

            // Assert
            Assert.Equal(userId, user.Id);
            Assert.Equal("test@example.com", user.Email);
            Assert.Equal("Test1234!", user.Password);
            Assert.Equal("TestCompany", user.Company);
            Assert.Equal("1234567890", user.Phone);
            Assert.Empty(user.Employees);
        }

        [Fact]
        public void User_CanAddEmployees()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@example.com",
                Password = "Test1234!",
                Company = "TestCompany",
                Phone = "1234567890"
            };

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Street",
                Phone = "9876543210",
                WellnessScore = 80,
                ProductivityScore = 90,
                CountryId = Guid.NewGuid(),
                UserId = user.Id
            };

            // Act
            user.Employees.Add(employee);

            // Assert
            Assert.Single(user.Employees);
            Assert.Contains(employee, user.Employees);
        }
    }
}
