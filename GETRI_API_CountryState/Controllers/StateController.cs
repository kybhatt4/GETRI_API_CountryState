using AutoMapper;
using GETRI_DFA_CountryState.DTO;
using GETRI_DFA_CountryState.Models;
using GETRI_DFA_CountryState.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GETRI_DFA_CountryState.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository iStateRepository;
        private readonly ICountryRepository iCountryRepository;
        private readonly IMapper imapper;

        public StateController(IStateRepository _iStateRepository, ICountryRepository _iCountryRepository, IMapper _imapper)
        {
            iStateRepository = _iStateRepository;
            iCountryRepository = _iCountryRepository;
            imapper = _imapper;
        }

        [HttpGet("GetStateList")]
        public IActionResult GetStateList()
        {
            return Ok(iStateRepository.GetStates());
        }

        [HttpGet("GetAllCountriesWithStates")]
        public IActionResult GetAllCountryWithStates()
        {
            List<CountryStateListDTO> countryStateDtoList = new List<CountryStateListDTO>();
            var ListCountries = iCountryRepository.GetCountries();

            foreach (var country in ListCountries)
            {
                var countryItem = country.CountryId;
                var listAllStates = iStateRepository.GetStates();
                var listState = iStateRepository.GetStates().Where(x=>x.CountryId == countryItem);

                CountryStateListDTO countryStateDTO = new CountryStateListDTO();
                countryStateDTO.CountryId = country.CountryId;
                countryStateDTO.Name = country.Name;
                countryStateDTO.LstState = new List<StateDTO>();

                foreach (var state in listState)
                {
                    StateDTO stateDTO = new StateDTO();
                    stateDTO.StateId = state.StateId;
                    stateDTO.Name = state.Name;

                    countryStateDTO.LstState.Add(stateDTO);
                }

                countryStateDtoList.Add(countryStateDTO);
            }

            return Ok(countryStateDtoList);
        }

        [HttpPost("RegisterState")]
        public IActionResult CreateState(CreateStateDTO stateDto)
        {
            return Ok(iStateRepository.CreateState(imapper.Map<State>(stateDto)));
        }

        [HttpGet("GetStateById")]
        public IActionResult SearchState(int id)
        {
            var result = iStateRepository.SearchState(id);
            return Ok(result);
        }

        [HttpPut("UpdateState")]
        public IActionResult UpdateState(State state)
        {
            var result = iStateRepository.UpdateState(state);
            return Ok(result);
        }

        [HttpDelete("DeleteState")]
        public IActionResult DeleteState(int id)
        {
            var result = iStateRepository.DeleteState(id);
            return Ok(result);
        }
    }
}
