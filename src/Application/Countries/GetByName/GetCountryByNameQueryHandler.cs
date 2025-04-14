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
                u.capital_city AS CapitalCity,
                u.population AS Population
            FROM countries u
            WHERE u.Name = @Name
            """;

        using IDbConnection connection = factory.GetOpenConnection();

        CountryResponse? country = await connection.QueryFirstOrDefaultAsync<CountryResponse>(
            sql,
            query);

        if (country is null)
        {
            return Result.Failure<CountryResponse>(CountryErrors.NotFoundByName);
        }

        return country;
    }
}
