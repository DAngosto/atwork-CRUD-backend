using atwork_CRUD_backend_Application.DTOs.Shared;
using atwork_CRUD_backend_Domain.Repositories;
using Mapster;
using MediatR;

namespace atwork_CRUD_backend_Application.Queries.Shared
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, CountryDto[]>
    {
        private readonly ICountryRepository _countryRepository;

        public GetAllCountriesQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CountryDto[]> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAllAsync(cancellationToken);
            return await countries.BuildAdapter().AdaptToTypeAsync<CountryDto[]>();
        }
    }
}
