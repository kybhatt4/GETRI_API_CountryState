using GETRI_DFA_CountryState.EntityFramework;
using GETRI_DFA_CountryState.Models;
using System.Diagnostics.Metrics;

namespace GETRI_DFA_CountryState.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly GetricountryStateDbContext applicationDbContext;

        public StateRepository(GetricountryStateDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public State CreateState(State state)
        {
            try
            {
                var result = applicationDbContext.Add(state);
                applicationDbContext.SaveChanges();

                return result.Entity;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool DeleteState(int id)
        {
            try
            {
                var filteredData = applicationDbContext.States.Where(x => x.StateId == id).FirstOrDefault();
                var result = applicationDbContext.States.Remove(filteredData);
                applicationDbContext.SaveChanges();

                return result != null ? true : false;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }

        public IEnumerable<State> GetStates()
        {
            try
            {
                return applicationDbContext.States.ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public State SearchState(int id)
        {
            try
            {
                return applicationDbContext.States.Where(x => x.StateId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public State UpdateState(State state)
        {
            try
            {
                var result = applicationDbContext.States.Update(state);
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
