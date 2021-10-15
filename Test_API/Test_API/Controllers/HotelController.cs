using AutoMapper;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitofWork _unitofwork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        public HotelController(IUnitofWork unitofwork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitofwork.hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. Please try again.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitofwork.hotels.Get(q=>q.Id==id);
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Something went wrong in {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. Please try again.");
            }
        }
    }
}
