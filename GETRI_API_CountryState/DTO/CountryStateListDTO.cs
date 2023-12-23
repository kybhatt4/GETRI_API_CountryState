namespace GETRI_DFA_CountryState.DTO
{
    public class CountryStateListDTO
    {
        public int CountryId { get; set; }

        public string Name { get; set; } = null!;

        public List<StateDTO> LstState {  get; set; }
    }
}
