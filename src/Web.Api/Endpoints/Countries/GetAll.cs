using Application.Countries.GetAll;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Countries;

public class GetAll: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("countries", async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllCountriesQuery();

                Result<IReadOnlyCollection<CountryAllResponse>> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Countries);
    }
}
