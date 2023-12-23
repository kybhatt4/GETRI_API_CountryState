using GETRI_DFA_CountryState.Models;

namespace GETRI_DFA_CountryState.Repository
{
    public interface IStateRepository
    {
        IEnumerable<State> GetStates();

        State SearchState(int id);

        State UpdateState(State state);

        State CreateState(State state);

        bool DeleteState(int id);
    }
}
