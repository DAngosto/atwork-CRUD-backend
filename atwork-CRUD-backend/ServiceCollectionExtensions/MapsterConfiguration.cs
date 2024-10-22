using atwork_CRUD_backend_Application.DTOs.Employees;
using atwork_CRUD_backend_Domain.Entities;
using Mapster;

namespace atwork_CRUD_backend.ServiceCollectionExtensions
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Employee, EmployeeDto>.NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName} {src.SecondLastName}")
                .Map(dest => dest.CountryName, src => src.Country.Name)
                .Map(dest => dest.CountryCode, src => src.Country.Code);
        }
    }
}
