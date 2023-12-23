using GETRI_DFA_CountryState.EntityFramework;
using GETRI_DFA_CountryState.Models;

namespace GETRI_DFA_CountryState.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private readonly GetricountryStateDbContext applicationDbContext;

        public CountryRepository(GetricountryStateDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public Country CreateCountry(Country country)
        {
            try
            {
                var result = applicationDbContext.Add(country);
                applicationDbContext.SaveChanges();

                return result.Entity;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool DeleteCountry(int id)
        {
            var filteredData = applicationDbContext.Countries.Where(x => x.CountryId == id).FirstOrDefault();
            var result = applicationDbContext.Countries.Remove(filteredData);
            applicationDbContext.SaveChanges();

            return result != null ? true : false;
        }

        public IEnumerable<Country> GetCountries()
        {
            try
            {
                return applicationDbContext.Countries.ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public Country SearchCountry(int id)
        {
            try
            {
                return applicationDbContext.Countries.Where(x => x.CountryId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public Country UpdateCountry(Country country)
        {
            try
            {
                var result = applicationDbContext.Countries.Update(country);
                applicationDbContext.SaveChanges();

                return result.Entity;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
