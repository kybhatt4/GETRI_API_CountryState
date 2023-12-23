using GETRI_DFA_CountryState.Models;

namespace GETRI_DFA_CountryState.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountries();

        Country SearchCountry(int id);

        Country UpdateCountry(Country country);

        Country CreateCountry(Country country);

        bool DeleteCountry(int id);
    }
}
