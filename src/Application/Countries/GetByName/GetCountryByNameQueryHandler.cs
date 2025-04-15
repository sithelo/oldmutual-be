using System.Data;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.GetByName;

internal sealed class GetCountryByNameQueryHandler(IDbConnectionFactory factory)
    : IQueryHandler<GetCountryByNameQuery, CountryResponse>
{
    public async Task<Result<CountryResponse>> Handle(GetCountryByNameQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                u.id AS Id,
                u.name AS Name,
                u.flag AS Flag,
                u.city AS City,
                u.population AS Population
            FROM countries u
            WHERE u.Name = @Name
            """;

        using IDbConnection connection = factory.GetOpenConnection();

        CountryResult? countryResult = await connection.QueryFirstOrDefaultAsync<CountryResult>(
            sql, query);

        if (countryResult is null)
        {
            return Result.Failure<CountryResponse>(CountryErrors.NotFoundByName);
        }

        var country = new CountryResponse
        {
            Id = countryResult.Id,
            Name = countryResult.Name,
            Flag = countryResult.Flag,
            CountryDetails = new CountryDetails
            {
                Capital = countryResult.City,
                Population = countryResult.Population,
                Name = countryResult.Name,
            }
        };

        return country;
    }
}
