using AutoMapper;
using FinalOfUber.DTOs.PaymentDTOs;
using FinalOfUber.DTOs.RatingDTOs;
using FinalOfUber.Models;
using FinalOfUber.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalOfUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public RatingsController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRating dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var e = await _unitofwork.Ride.GetById(dto.RideId);
            if (e == null)
            {
                return NotFound();
            }
            var r = mapper.Map<Rating>(dto);
            await _unitofwork.Rating.Add(r);
            await _unitofwork.Save();
            return Created();
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> get()
        {
            var e = await _unitofwork.Rating.Top();
            return Ok(e);
        }
    }
}
