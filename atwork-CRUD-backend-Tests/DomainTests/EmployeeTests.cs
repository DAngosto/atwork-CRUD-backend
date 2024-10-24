using atwork_CRUD_backend_Domain.Entities;
using System.Net.Mail;
using Assert = Xunit.Assert;

namespace atwork_CRUD_backend_Tests.DomainTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Creation_ShouldCreateValidEmployee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var countryId = Guid.NewGuid();

            var employee = new Employee
            {
                Id = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Street",
                Phone = "9876543210",
                WellnessScore = 75,
                ProductivityScore = 80,
                CountryId = countryId,
                UserId = userId
            };

            // Assert
            Assert.Equal(employeeId, employee.Id);
            Assert.Equal("John", employee.FirstName);
            Assert.Equal("Doe", employee.LastName);
            Assert.Equal("john.doe@example.com", employee.Email);
            Assert.Equal("123 Street", employee.Address);
            Assert.Equal("9876543210", employee.Phone);
            Assert.Equal(75, employee.WellnessScore);
            Assert.Equal(80, employee.ProductivityScore);
            Assert.Equal(countryId, employee.CountryId);
            Assert.Equal(userId, employee.UserId);
        }

        [Fact]
        public void Employee_Email_ShouldBeValid()
        {
            // Arrange
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "invalid-email",
                Address = "123 Street",
                Phone = "9876543210",
                WellnessScore = 75,
                ProductivityScore = 80,
                CountryId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            // Act
            var isValidEmail = IsValidEmail(employee.Email);

            // Assert
            Assert.False(isValidEmail, "The email should be invalid.");
        }

        [Fact]
        public void Employee_Email_ShouldPassWithValidEmail()
        {
            // Arrange
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Street",
                Phone = "9876543210",
                WellnessScore = 75,
                ProductivityScore = 80,
                CountryId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            // Act
            var isValidEmail = IsValidEmail(employee.Email);

            // Assert
            Assert.True(isValidEmail, "The email should be valid.");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
