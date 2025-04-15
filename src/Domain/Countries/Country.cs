using SharedKernel;

namespace Domain.Countries;

public sealed class Country : Entity
{
    private Country(Guid id, Name name, Flag flag, Name city, int population)
        : base(id)
    {
        Name = name;
        Flag = flag;
        City = city;
        Population = population;
    }

    private Country()
    {
    }

    public Name Name { get; private set; }

    public Flag Flag { get; private set; }

    public Name City { get; set; }
    
    public int Population { get; set; }


    public static Country Create(Name name, Flag flag, Name city, int population)
    {
        var country = new Country(Guid.NewGuid(), name, flag, city, population);

        country.Raise(new CountryCreatedDomainEvent(country.Id));

        return country;
    }
}
