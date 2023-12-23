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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository iCountryRepository;
        private readonly IMapper imapper;

        public CountryController(ICountryRepository _iCountryRepository, IMapper _imapper)
        {
            iCountryRepository = _iCountryRepository;
            imapper = _imapper;
        }

        [HttpGet("GetCoutryList")]
        public IActionResult GetCountryList()
        {
            return Ok(iCountryRepository.GetCountries());
        }

        [HttpPost("RegisterCountry")]
        public IActionResult CreateCountry(CreateCountryDTO countryDto)
        {
            return Ok(iCountryRepository.CreateCountry(imapper.Map<Country>(countryDto)));

        }

        [HttpGet("GetCountryById")]
        public IActionResult SearchProduct(int id)
        {
            var result = iCountryRepository.SearchCountry(id);
            return Ok(result);
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateProduct(Country country)
        {
            var result = iCountryRepository.UpdateCountry(country);
            return Ok(result);
        }

        [HttpDelete("DeleteCountry")]
        public IActionResult DeleteCountry(int id)
        {
            var result = iCountryRepository.DeleteCountry(id);
            return Ok(result);
        }
    }
}
