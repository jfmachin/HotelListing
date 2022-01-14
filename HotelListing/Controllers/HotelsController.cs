using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CountriesController> logger;
        private readonly IMapper mapper;

        public HotelsController(IUnitOfWork unitOfWork, ILogger<CountriesController> logger, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() {
            var hotels = await unitOfWork.HotelRepository.getAll();
            var results = mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> get(int id) {
            var hotel = await unitOfWork.HotelRepository.get(x => x.id == id, new List<string>{ "country" });
            var result = mapper.Map<HotelDTO>(hotel);
            return Ok(result);
        }
    }
}
