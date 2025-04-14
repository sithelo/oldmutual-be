using System.Data;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Countries.GetByName;
using Dapper;
using Domain.Countries;
using SharedKernel;

namespace Application.Countries.GetAll;

internal sealed class GetAllCountriesQueryHandler(IDbConnectionFactory factory)
    : IQueryHandler<GetAllCountriesQuery, IReadOnlyCollection<CountryAllResponse>>
{
    public async Task<Result<IReadOnlyCollection<CountryAllResponse>>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                u.name AS Name,
                u.flag AS Flag
            FROM countries
            """;

        using IDbConnection connection = factory.GetOpenConnection();

        List<CountryAllResponse> countries = (await connection.QueryAsync<CountryAllResponse>(
            sql,
            query)).AsList();

        

        return countries;
    }
}
