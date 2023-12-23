using GETRI_DFA_CountryState.Models;

namespace GETRI_DFA_CountryState.DTO
{
    public class CreateStateDTO
    {
        public string State { get; set; } = null!;

        public int? CountryId { get; set; }

    }
}
