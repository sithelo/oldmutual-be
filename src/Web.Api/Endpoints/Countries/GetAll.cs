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

                Result<CountryResponse> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Countries);
    }
}
