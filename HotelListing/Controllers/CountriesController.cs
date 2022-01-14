using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CountriesController> logger;
        private readonly IMapper mapper;

        public CountriesController(IUnitOfWork unitOfWork, ILogger<CountriesController> logger, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() {
            var countries = await unitOfWork.CountryRepository.getAll();
            var results = mapper.Map<IList<CountryDTO>>(countries);
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> get(int id) {
            var country = await unitOfWork.CountryRepository.get(x => x.id == id, new List<string>{"hotels"});
            var result = mapper.Map<CountryDTO>(country);
            return Ok(result);
        }
    }
}
