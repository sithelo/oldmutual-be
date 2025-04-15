using Application.Countries.GetByName;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Countries;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("countries/{name}", async (
                string name,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetCountryByNameQuery(name);

                Result<CountryResponse> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Countries);
    }
}
