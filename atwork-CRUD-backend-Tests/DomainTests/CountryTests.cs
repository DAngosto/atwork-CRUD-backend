using atwork_CRUD_backend_Domain.Entities;
using Assert = Xunit.Assert;

namespace atwork_CRUD_backend_Tests.DomainTests
{
    public class CountryTests
    {
        [Fact]
        public void Country_Creation_ShouldCreateValidCountry()
        {
            // Arrange
            var countryId = Guid.NewGuid();
            var country = new Country
            {
                Id = countryId,
                Name = "United States",
                Code = "US"
            };

            // Assert
            Assert.Equal(countryId, country.Id);
            Assert.Equal("United States", country.Name);
            Assert.Equal("US", country.Code);
        }
    }
}
