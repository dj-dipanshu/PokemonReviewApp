using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int CountryId);
        bool CountryExists(int Id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool Save();
    }
}
